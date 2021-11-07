using System;
using UnityEngine;

/// <summary>
/// As described in Resources/Kyle2011.pdf
/// </summary>
public class RecoveryCalculation {
    /// <summary>
    /// Air flow rate in cm/s
    /// </summary>
    public double AirFlowRate = 2;
    /// <summary>
    /// Froth Height in cm
    /// </summary>
    public double FrothHeight = 10;
    /// <summary>
    /// Retention Time in minutes
    /// </summary>
    public double RetentionTime = 0.5;
    /// <summary>
    /// Power in W/m3
    /// </summary>
    public double Power = 1500;
    /// <summary>
    /// Zeta Potential in mV
    /// </summary>
    public double ZetaPotential = -15;
    /// <summary>
    /// Standard height value of cell OK-05-R. More info: Resources/Flotation-Cell-Design.pdf
    /// </summary>
    public double CellHeight = 0.84;
    /// <summary>
    /// Assumed for OK-05-R, since that is the cell with power ~= 2.5 kw
    /// </summary>
    public double CellDiameter = 1;

    private const double pi = 3.141592d;
    private const double waterDensity = 1000d; // kg/m3
    private const double airDensity = 1.2d; // kg/m3
    private const double waterViscosity = 0.001d; // Ns/m2
    private const double c = 2.988d * (10e8); // m/s... speed of light 11
    private const double gravity = 9.813f; //m/s2
    private double dblParticleDiam = 0.00007, dblImpellerDiam;
    private double dblTotalDens;
    public int ParticleRange = 130;
    /// <summary>
    /// Air fraction assumed based on figure 25 of Resources/Malm2019.pdf
    /// </summary>
    private double AirFraction = 0.1;
    private double dblSlurryFraction= 0.3, dblNBubble; //ask for correct values
    private double dblRateConst;
    private double dblDragBeta; // drag coefficient (Goren & O'Niell)
    private double dblH_c_Factor = 5d; // adjustable fitting parameter for dragbeta
    private bool ContactDistribChecked, BubbleSizeEnabled;
    private double dblU1Bulk, dblU2Bulk, dblEBulk;
    public int NumberOfCells = 4;

    // ===== Froth Parameters =====
    double dblB = 3.3d; // fitting parameter
    double dblAlpha = 0.01d; // fitting parameter
    double dblCoverage = 0.5d; // max particle coverage attached in froth
    double dblPFTransfer, dblP_i, dblPr;
    double dblEiw, dblEka;
    private double dblGrowthFactor; // ratio of bubble size in froth
    private double dblR_Water_max; // max. water rec. in froth (approximation)
    private int ri = 1; // counter for recovery plot marker color
    private int g; // counter for grade
    private double dblOvrRecovery;
    private bool blnCheck; // are all inputs valid?
    public double[] arrSizeGrade = new double[38];
    public double dblKinVisc = 1; // kinematic
    private double dblBubbleDiam;
    private double dblPAtt, dblPDet, dblPCol, dblFrothRecoveryFactor;
    public double[] arrRecovery, arrPDiam,
        arrRateK, arrPa, arrPc,
        arrPd , arrFR;
    public Feed feed;

    public double[] CalculateParticleRecoveries()
    {
        SetSizeOfArrays();
        CalculateSurfaceTension();
        double dblMassBP;
        double dblVolCell = pi * Math.Pow((CellDiameter / 2), 2) * CellHeight;
        dblKinVisc = waterViscosity / waterDensity;

        double dblVolImpZone = 0.1d; // set impeller
        dblParticleDiam = 0.000001; // (1 micron)*/
        for (int i = 0; i < ParticleRange; i++)
        {
            arrPDiam[i] = dblParticleDiam * 1000000; // 10^6 for microns
            arrRateK[i] = dblRateConst * dblFrothRecoveryFactor;
            arrRecovery[i] = CalculateRecoveryForParticleDiameter(dblParticleDiam);
            // return percentage
            arrPa[i] = dblPAtt * 100;
            arrPc[i] = dblPCol * 100;
            arrPd[i] = (1 - dblPDet) * 100;
            arrFR[i] = dblFrothRecoveryFactor * 100;

            // increment particle diam  
            dblParticleDiam *= 1.2d;
        }

        // This might need to return also the arrPDiam[] as if I understand this correctly the particle sizes don't go from 1-130 microns but up to 1.2^130*1 micron which is quite big.. :)
        // I couldn't get the plotter to work so didn't check if that would make a better picture..
        return arrRecovery;
    }

    private void SetSizeOfArrays()
    {
        arrRecovery = new double[ParticleRange];
        arrPDiam = new double[ParticleRange];
        arrRateK = new double[ParticleRange];
        arrPa = new double[ParticleRange];
        arrPc = new double[ParticleRange];
        arrPd = new double[ParticleRange];
        arrFR = new double[ParticleRange];
    }

    public double CalculateRecoveryForParticleDiameter(double ParticleDiam)
    {
        dblParticleDiam = ParticleDiam;
        dblFrothRecoveryFactor = FrothRecoveryFactor(dblParticleDiam, BubbleDiameter());
        double rate = RateConstant();
        double dblRecovery_ci = 1 - Math.Pow(1 + rate * RetentionTime, (double)-1); // eq 32 (Do & Yoon)
        double dblRecovery_I = dblRecovery_ci * dblFrothRecoveryFactor / (dblRecovery_ci * dblFrothRecoveryFactor + 1 - dblRecovery_ci);
        double Recovery = 1 - Math.Pow(1d - dblRecovery_I, NumberOfCells); // eq 6.2 finch & dobby
        return Recovery * 100;
    }

    private double RateConstant() {
        //===== Cell Calculations =====
        double dblVolParticle = 4 / 3 * pi * Math.Pow(dblParticleDiam / 2, 3);
        double dblMassParticle = feed.Density * dblVolParticle;
        dblBubbleDiam = BubbleDiameter();

        // ===== Kinetic Energy of Attachment =====
        double dblKineticEAttach = 0.5d * dblMassParticle;
        double dblKineticEDetach = 0.5d * dblMassParticle;
        double dblBeta = Beta(dblParticleDiam);
        double dblWorkAdhesion = CalculateDensityOfBubbles(dblParticleDiam, dblBeta, dblVolParticle, out dblNBubble);

        // ===== Probabilities =====
        double energyBarrier = EnergyBarrier() * -1;
        dblPAtt = Math.Exp(energyBarrier / dblKineticEAttach);
        double dblRe = Math.Sqrt(dblU2Bulk) * dblBubbleDiam / dblKinVisc; // bubble Reynold's number
        dblPCol = Math.Pow(Math.Tan(Math.Sqrt(3d / 2d * (1 + 3d / 16d * dblRe / (1 + 0.2d * Math.Pow(dblRe, 0.56d)))) * (dblParticleDiam / dblBubbleDiam)), 2);
        dblPCol = CheckIfBiggerthanOne(dblPCol);
        dblEiw = gravity / (4 * pi) * Math.Pow(Math.Pow(waterViscosity, 3) / dblEBulk, 0.25d);
        double dblMassBubble = 1;
        dblEka = Math.Pow(dblMassBubble * dblU2Bulk - 2 * Math.Pow(dblBubbleDiam / dblParticleDiam, 2) * dblMassParticle * dblU1Bulk, 2) / (100 * (dblMassBubble + 2 * Math.Pow(dblBubbleDiam / dblParticleDiam, 2) * dblMassParticle));
        dblP_i = 13 * Math.Sqrt(9 * Math.Pow(waterViscosity, 2) / (dblBubbleDiam * CalculateSurfaceTension() * dblTotalDens));
        dblPr = Math.Exp(-dblEiw / dblEka);
        dblPFTransfer = dblP_i * (1 - dblPr);

        dblPDet = Math.Exp(-(dblWorkAdhesion + dblKineticEAttach) / dblKineticEDetach);
        double result = dblBeta * dblNBubble * dblPAtt * dblPCol * (1 - dblPDet) * 60; // x60 to make 1/min;
        return result;
    }

    public double EnergyBarrier() {
        double dblBubbleZ = 1, dblDielectric = 1, dblPermitivity = 1; ///Test values
        double dblA132_s, dblK132_s, dblK131, a, b_k;
        double dblA11 = 3d * Math.Pow(10d, -19); // Hamaker
        double dblA22 = 0d; //
        double dblA33 = 4.38d * Math.Pow(10d, -20); //
        double dblK232 = 4.07d * Math.Pow(10d, -18); // Hydrophobic force constant
        double dblKappa = 1d / (9.6d * Math.Pow(10d, -8)); // inverse Debye Length
        double b = 3d * Math.Pow(10d, -17); // correct for retardation effects (most mat'ls)
        double l = 3.3d * Math.Pow(10d, 15d); // correction for retardation effects (water, !!change for other media)
        double dblH0 = 1d * Math.Pow(10d, -11); // separation between bubb & part

        double dblH = 0d, dblH1 = 0;
        double Ce, Cd, Ch; // coefficients of eq 14,15,16 - for efficiency of calculation

        if (feed.ContactAngle < 86.89d)
        {
            a = 2.732 * Math.Pow(10, -21);
            b_k = 0.04136d;
        }
        else if (86.889 <= feed.ContactAngle && feed.ContactAngle < 92.28)
        {
            a = 4.888d * Math.Pow(10d, -44);
            b_k = 0.6441d;
        }
        else {
            a = 6.327d * Math.Pow(10d, (double)-27);
            b_k = 0.2172;
        }
        dblK131 = a * Math.Exp(b_k * feed.ContactAngle);
        dblK132_s = Math.Sqrt(dblK131 * dblK232);
        dblA132_s = (Math.Sqrt(dblA11) - Math.Sqrt(dblA33)) * (Math.Sqrt(dblA22) - Math.Sqrt(dblA33));
        Ce = pi * (dblPermitivity * dblDielectric * (dblParticleDiam * dblBubbleDiam / 4d)
            * (Math.Pow(ZetaPotential, 2d) + Math.Pow(dblBubbleZ, 2d))) / (dblParticleDiam / 2d + dblBubbleDiam / 2d);

        Cd = -(dblA132_s * (dblParticleDiam * dblBubbleDiam / 4d)) / (6d * (dblParticleDiam / 2d + dblBubbleDiam / 2d));
        Ch = -(dblParticleDiam * dblBubbleDiam / 4d * dblK132_s) / (6d * (dblParticleDiam / 2d + dblBubbleDiam / 2d));
        int x = 0;
        double dblVT, dblVT1;
        double dblVE, dblVD, dblVH; // total free energy of
        double dblVE1, dblVD1, dblVH1; // second state of above variables
       // do
        {
            dblH0 = dblH1 + 1d * Math.Pow(10d, -9);
            // equation 14 using H0(Do & Yoon)
            dblVE = Ce * (2d * ZetaPotential * dblBubbleZ / (Math.Pow(ZetaPotential, 2d) + Math.Pow(dblBubbleZ, 2d))
                * Math.Log((1d + Math.Exp(-dblKappa * dblH0)) / (1d - Math.Exp(-dblKappa * dblH0))) + Math.Log(1d -
                Math.Exp(-2 * dblKappa * dblH0)));

            dblVD = Cd / dblH0 * (1d - (1d + 2d * b * l) / (1d + b * c / dblH0)); // equation 15 using H0(Do & Yoon)
            dblVH = Ch / dblH0; // equation 16 using H0(Do & Yoon)
            dblVT = dblVE + dblVD + dblVH; // extended DLVO theory

            dblH1 = dblH0 + 1d * Math.Pow(10d, -11);

            // equation 14 using H1(Do & Yoon)
            dblVE1 = Ce * (2d * ZetaPotential * dblBubbleZ /
                (Math.Pow(ZetaPotential, 2d) + Math.Pow(dblBubbleZ, 2d)) *
                Math.Log((1d + Math.Exp(-dblKappa * dblH1)) / (1d
                - Math.Exp(-dblKappa * dblH1))) + Math.Log(1d - Math.Exp((double)-2 * dblKappa * dblH1)));

            dblVD1 = Cd / dblH1 * (1 - (1d + 2d * b * l) / (1 + b * c / dblH1)); // equation 15 using H1(Do & Yoon)
            dblVH1 = Ch / dblH1; // equation 16 using H1(Do & Yoon();
            dblVT1 = dblVE1 + dblVD1 + dblVH1; // extended DLVO theory 2nd state 302       
        }
      //  while (dblVT < dblVT1);
        dblH = dblH0;
        dblDragBeta = 0.37d * Math.Pow(dblParticleDiam / 2d / dblH / dblH_c_Factor, 0.83d); // h_c_factor is adjustable
        double EnergyBarrier = dblVT;
        if (EnergyBarrier < 0)
        {
            return 0;
        }
        else {
            return EnergyBarrier;
        }
    }

    private double CalculateSurfaceTension()
    {
        SurfaceTension SF = new SurfaceTension();
        SF.FrotherConcentrate = 192; //following example in didactic/Kyle2011.pdf
        SF.ChosenReagent = SF.Pentanol;
        return SF.CalculateSurfaceTension();
    }

    private static double CheckIfBiggerthanOne(double dblPCol)
    {
        if (dblPCol >= 1)
        {
            dblPCol = 1;
        }
        return dblPCol;
    }

    public double FrothRecoveryFactor(double dblParticleDiam, double dblBubbleDiam)
    {
        // ===== Froth Recovery =====
        int dblCoverageFactor = 2;
        double dblCoalesceFactor = 2d;
        double dblFilmThick = 3d / 4d * (0.33d / (1d - 0.33d)) * dblBubbleDiam;
        double dblCoarsenTime = 4 * waterViscosity * FrothHeight / (waterDensity * gravity * Math.Pow(dblFilmThick, 2d));
        double dblL = waterViscosity / (airDensity * 0.015d); // 1.5 cm/s froth velocity
        double dblA0 = Math.Pow(dblBubbleDiam, 2);
        double dblAf = Math.Pow(Math.Sqrt(AirFlowRate * waterViscosity / (waterDensity * gravity)) *
            Math.Tan(Math.Sqrt(Math.Tan(airDensity * gravity * dblA0 / (AirFlowRate * waterViscosity))) -
            FrothHeight / 2 * Math.Sqrt(waterDensity * gravity * AirFlowRate) / CalculateSurfaceTension()), 2);
        double dblRmax = Math.Sqrt(Math.Exp(dblCoalesceFactor * Math.Sqrt(dblAf / dblA0) - dblCoalesceFactor));
        double dblR_Attachment = dblRmax * Math.Exp(-dblCoverageFactor * (6 * FrothHeight / dblBubbleDiam) * (1 - dblRmax) * (dblParticleDiam / dblBubbleDiam));
        dblR_Water_max = 0.33d * dblCoarsenTime * (6 * AirFlowRate) / (dblBubbleDiam / dblRmax) * Math.Exp(-FrothHeight / dblL);
        if (dblR_Water_max > 1)
        {
            dblR_Water_max = 1;
        }
        double dblR_Entrainment = dblR_Water_max * Math.Exp(-0.0325d * (feed.Density - waterDensity) - 0.063d * dblParticleDiam);
        double dblFrothRecoveryFactor = dblR_Entrainment + dblR_Attachment;
        return dblFrothRecoveryFactor;
    }

    double Beta(double dblParticleDiam)
    {
        double dblEBulk = 1;
        double dblU1Bulk = 0.4 * Math.Pow(dblEBulk, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * (feed.Density / 1);
        double dblU2Bulk = 2 * Math.Pow(dblEBulk * dblBubbleDiam, 2 / 3);
        double dblCollisionDiam = dblParticleDiam + dblBubbleDiam;
        return Math.Pow(2, 3 / 2) * Math.Pow(pi, 0.5) * Math.Pow(dblCollisionDiam, 2) * Math.Sqrt(dblU1Bulk + dblU2Bulk);
    }

    private double BubbleDiameter() {
        // Does this return a sensible value? It's something like 18cm which seems big? Perhaps check that the functions are returning values on the right scale (and the correct units) to pinpoint if there is an issue somewhere.
        if (BubbleSizeEnabled == false)
        {
            double EImpeller = CalculateEnergyDissipation();
            return Math.Pow(2.11 * CalculateSurfaceTension() / (waterDensity * Math.Pow(EImpeller, 0.66)), 0.6);
        } else
        {
            return dblParticleDiam / 1000;
        }
    }

    private double CalculateDensityOfBubbles(double dblParticleDiam, double dblBeta, double dblVolParticle, out double dblNBubble)
    {
        double dblVolBubble = 4 / 3 * pi * Math.Pow(dblBubbleDiam / 2, 3);
        dblNBubble = AirFraction / dblVolBubble;
        double dblNParticle = (1 - AirFraction) * dblSlurryFraction / dblVolParticle;
        double dblZBubbParticle = dblBeta * dblNBubble * dblNParticle;
        return CalculateSurfaceTension() * pi * Math.Pow(dblParticleDiam / 2, 2) *
            (1 - Math.Pow(Math.Cos(feed.ContactAngle * (pi / 180)), 2));
    }

    private double CalculateEnergyDissipation()
    {
        double dblDetach_F = 1; // 2 compartment model (Lu)       
        double dblBulkZone = 1;
        double dblImpellerZone = 1;
        dblTotalDens = AirFraction * airDensity + (1 - AirFraction) *
        dblSlurryFraction * feed.Density + (1 - dblSlurryFraction) * waterDensity;
        double dblEMean = Power / dblTotalDens;
        double dblEBulk = dblBulkZone * dblEMean;
        return dblImpellerZone * dblEMean;
    }

    private double U2Mean(double dblEMean)
    {
        return 2 * Math.Pow(dblEMean * dblBubbleDiam, 2 / 3);
    }

    private double U1Mean(double dblEMean, double dblParticleDiam)
    {
        return Math.Pow(0.4 * Math.Pow(dblEMean, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * Math.Pow(feed.Density / waterDensity - 1, 2 / 3), 2);
    }
}
