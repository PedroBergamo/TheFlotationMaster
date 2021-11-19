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
    /// Froth Height in m
    /// </summary>
    public double FrothHeight = 0.1;
    /// <summary>
    /// Retention Time in minutes
    /// </summary>
    public double RetentionTime = 0.5;
    /// <summary>
    /// Power in W/m3
    /// </summary>
    public double Power = 1500;
    /// <summary>
    /// Zeta Potential in V
    /// </summary>
    public double ZetaPotential = -0.015;
    /// <summary>
    /// Standard height value of cell OK-05-R. More info: Resources/Flotation-Cell-Design.pdf
    /// </summary>
    public double CellHeight = 2;
    /// <summary>
    /// Assumed for OK-05-R, since that is the cell with power ~= 2.5 kw
    /// </summary>
    public double CellDiameter = 2;

    private const double pi = 3.141592d;
    private const double waterDensity = 1000d; // kg/m3
    private const double airDensity = 1.2d; // kg/m3
    private const double waterViscosity = 0.001d; // Ns/m2
    private const double c = 2.988d * (10e8); // m/s... speed of light 11
    private const double gravity = 9.813f; //m/s2
    /// <summary>
    /// particle diameter in meters
    /// </summary>
    private double dblParticleDiam = 0.0000071;
    /// <summary>
    /// Impeller diameter in meters
    /// </summary>
    private double dblImpellerDiam = 0.5;
    private double dblTotalDens;
    public int ParticleRange = 130;
    /// <summary>
    /// Air fraction assumed based on figure 25 of Resources/Malm2019.pdf
    /// </summary>
    private double AirFraction = 0.2;
    private double dblSlurryFraction = 0.2, dblNBubble;
    private double dblRateConst;
    private double dblDragBeta; // drag coefficient (Goren & O'Niell)
    private double dblH_c_Factor = 5d; // adjustable fitting parameter for dragbeta
    private bool ContactDistribChecked, BubbleSizeEnabled;
    private double dblU1Bulk, dblU2Bulk, dblEBulk;
    public int NumberOfCells = 4;
    double dblDetach_F = 1d; // adjustable parameter for fitting

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
    public double dblKinVisc; // kinematic
    public double dblBulkZone = 0.5;
    public double dblEMean;
    private double EImpeller;
    /// <summary>
    /// bubble diameter given in mm
    /// </summary>
    public double BubbleDiameter;
    public bool BubbleDiameterGiven = false;
    private double dblPAtt, dblPDet, dblPCol, dblFrothRecoveryFactor;
    public double[] arrRecovery, arrPDiam,
        arrRateK, arrPa, arrPc,
        arrPd, arrFR;
    public Feed feed;
    private double SurfaceTension;

    public void SetUpCalculation(){
        SurfaceTension = CalculateSurfaceTension();
        EImpeller = CalculateEnergyDissipation();
        BubbleDiameter = BubbleDiameterInMeters();
        SetSizeOfArrays();
        dblKinVisc = waterViscosity / waterDensity;
    }
    public void CalculateParticleRecoveries()
    {
        SetUpCalculation();
        double dblVolImpZone = 0.1d; // set impeller
        double dblVolCell = pi * Math.Pow((CellDiameter / 2), 2) * CellHeight;
        double dblMassBP;

        dblParticleDiam = 0.000001; // (1 micron)
        double Increment = 0.000001;
        for (int i = 0; i < ParticleRange; i++)
        {            
            PopulateArrays(i);
            // increment particle diam  
            dblParticleDiam += Increment;
        }
    }

    private void PopulateArrays(int i)
    {
        arrRecovery[i] = CalculateRecoveryForParticleDiameter(dblParticleDiam);
        arrPDiam[i] = dblParticleDiam * 1000000; // 10^6 for microns
        arrRateK[i] = dblRateConst * dblFrothRecoveryFactor;
        // return percentage
        arrPa[i] = dblPAtt * 100;
        arrPc[i] = dblPCol * 100;
        arrPd[i] = (1 - dblPDet) * 100;
        arrFR[i] = dblFrothRecoveryFactor * 100;
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
        dblFrothRecoveryFactor = FrothRecoveryFactor(dblParticleDiam);
        double rate = RateConstant();
        double dblRecovery_ci = 1 - Math.Pow(1 + rate * RetentionTime, (double)-1); // eq 32 (Do & Yoon)
        double dblRecovery_I = dblRecovery_ci * dblFrothRecoveryFactor / (dblRecovery_ci * dblFrothRecoveryFactor + 1 - dblRecovery_ci);
        double Recovery = 1 - Math.Pow(1d - dblRecovery_I, NumberOfCells); // eq 6.2 finch & dobby
        double result = Recovery * 100;
        return result;
    }

    private double RateConstant() {
        //===== Cell Calculations =====
        double dblVolParticle = 4 / 3 * pi * Math.Pow(dblParticleDiam / 2, 3);
        double dblMassParticle = feed.Density * dblVolParticle;


        // ===== Kinetic Energy of Attachment =====
        dblU1Bulk = 0.4 * Math.Pow(dblEBulk, 4 / 9) *
            Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * (feed.Density / 1);

        double dblKineticEAttach = 0.5d * dblMassParticle * dblU1Bulk /
            Math.Pow(dblDragBeta, 2);

        double dblKineticEDetach = 0.5d * dblMassParticle * Math.Pow((dblDetach_F * dblParticleDiam +
            BubbleDiameter) * Math.Sqrt(EImpeller /dblKinVisc),2);
        double dblBeta = Beta(dblParticleDiam);
        double dblWorkAdhesion = CalculateDensityOfBubbles(dblParticleDiam, dblBeta, dblVolParticle, out dblNBubble);

        // ===== Probabilities =====
        double energyBarrier = EnergyBarrier() * -1;
        dblPAtt = Math.Exp(energyBarrier / dblKineticEAttach);
        double dblRe = Math.Sqrt(dblU2Bulk) * BubbleDiameter / dblKinVisc; // bubble Reynold's number
        dblPCol = Math.Pow(Math.Tan(Math.Sqrt(3d / 2d * (1 + 3d / 16d * dblRe / (1 + 0.2d * Math.Pow(dblRe, 0.56d)))) *
            (dblParticleDiam / BubbleDiameter)), 2);
        dblPCol = CheckIfBiggerthanOne(dblPCol);
        dblEBulk = dblBulkZone * dblEMean;
        dblEiw = gravity / (4 * pi) * Math.Pow(Math.Pow(waterViscosity, 3) / dblEBulk, 0.25d);
        double dblVolBubble = Math.Pow((4 / 3) * pi * (BubbleDiameter / 2), 3); //vol 1 bubb.
        double dblMassBubble = airDensity * dblVolBubble;
        dblEka = Math.Pow(dblMassBubble * dblU2Bulk - 2 * Math.Pow(BubbleDiameter /
            dblParticleDiam, 2) * dblMassParticle * dblU1Bulk, 2) / (100 * (dblMassBubble + 2 *
            Math.Pow(BubbleDiameter / dblParticleDiam, 2) * dblMassParticle));
        dblP_i = 13 * Math.Sqrt(9 * Math.Pow(waterViscosity, 2) / (BubbleDiameter * SurfaceTension * dblTotalDens));
        dblPr = Math.Exp(-dblEiw / dblEka);
        dblPFTransfer = dblP_i * (1 - dblPr);

        dblPDet = Math.Exp(-(dblWorkAdhesion + dblKineticEAttach) / dblKineticEDetach);
        double result = dblBeta * dblNBubble * dblPAtt * dblPCol * (1 - dblPDet) * 60; // x60 to make 1/min;
        return result;
    }
    /// <summary>
    /// values obtained from Resources/Kyle2011.pdf figure 4
    /// </summary>
    /// <returns></returns>
    public double EnergyBarrier()
    {
        
        double EnergyBarrier;        
            double dblH = 1d * Math.Pow(10d, -11); // separation between bubb & part
            double VT1 = VT(dblH);
            dblH += dblH;
            double VT2 = VT(dblH);
        
        while (VT1 < VT2) {
            dblH += 1d * Math.Pow(10d, -9);
            VT1 = VT(dblH);
            // increments H0 to find correct value
        }
        dblDragBeta = 0.37d * Math.Pow(dblParticleDiam / 2d / dblH / dblH_c_Factor, 0.83d); // h_c_factor is adjustable

        EnergyBarrier = VT1;
        if (EnergyBarrier < 0)
        {
            return 0;
        }
        else
        {
            return EnergyBarrier;
        }

       
    }

    private double K131()
    {
        double contactAngle = feed.CheckContactAngle(dblParticleDiam);
        double a, b_k;
        if (contactAngle < 86.89d)
        {
            a = 2.732 * Math.Pow(10, -21);
            b_k = 0.04136d;
        }
        else if (86.889 <= contactAngle && contactAngle < 92.28)
        {
            a = 4.888d * Math.Pow(10d, -44);
            b_k = 0.6441d;
        }
        else
        {
            a = 6.327d * Math.Pow(10d, (double)-27);
            b_k = 0.2172;
        }
        return a * Math.Exp(b_k * contactAngle);
    }

    private double VT(double dblH0)
    {
        double dblA132_s, dblK132_s, dblK131, a, b_k;
        double dblA11 = 3d * Math.Pow(10d, -19); // Hamaker
        double dblA22 = 0d; //
        double dblA33 = 4.38d * Math.Pow(10d, -20); //
        double dblK232 = 4.07d * Math.Pow(10d, -18); // Hydrophobic force constant
        dblK132_s = Math.Sqrt(K131() * dblK232);
        dblA132_s = (Math.Sqrt(dblA11) - Math.Sqrt(dblA33)) * (Math.Sqrt(dblA22) - Math.Sqrt(dblA33));
        
        double b = 3d * Math.Pow(10d, -17); // correct for retardation effects (most mat'ls)
        double l = 3.3d * Math.Pow(10d, 15d); // correction for retardation effects (water, !!change for other media)

        double dblDielectric = 86.5;
        double dblPermitivity = 8.854 * Math.Pow(10, -12); ///Test values
        double dblKappa = 1d / (9.6d * Math.Pow(10d, -8)); // inverse Debye Length
        double dblBubbleZ = 0.03;

        // coefficients of eq 14,15,16 - for efficiency of calculation
        double Ce = pi * (dblPermitivity * dblDielectric * (dblParticleDiam * BubbleDiameter / 4d)
           * (Math.Pow(ZetaPotential, 2d) + Math.Pow(dblBubbleZ, 2d))) / (dblParticleDiam / 2d + BubbleDiameter / 2d);
        double Cd = -(dblA132_s * (dblParticleDiam * BubbleDiameter / 4d)) / (6d * (dblParticleDiam / 2d + BubbleDiameter / 2d));
        double Ch = -(dblParticleDiam * BubbleDiameter / 4d * dblK132_s) / (6d * (dblParticleDiam / 2d + BubbleDiameter / 2d));

        // equation 14 using H0(Do & Yoon)
        double dblVE = Ce * (2d * ZetaPotential * dblBubbleZ / (Math.Pow(ZetaPotential, 2d) + Math.Pow(dblBubbleZ, 2d))
            * Math.Log((1d + Math.Exp(-dblKappa * dblH0)) / (1d - Math.Exp(-dblKappa * dblH0))) + Math.Log(1d -
            Math.Exp(-2 * dblKappa * dblH0)));

        double dblVD = Cd / dblH0 * (1d - (1d + 2d * b * l) / (1d + b * c / dblH0)); // equation 15 using H0(Do & Yoon)
        double dblVH = Ch / dblH0; // equation 16 using H0(Do & Yoon)
        return dblVE + dblVD + dblVH; // extended DLVO theory
    }

    private double CalculateSurfaceTension()
    {
        SurfaceTension SF = new SurfaceTension();
        SF.FrotherConcentrate = 192; //following example in didactic/Kyle2011.pdf
        SF.ChosenReagent = SF.MIBC;
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

    public double Rmax() {
        double dblA0 = Math.Pow(BubbleDiameter, 2);
        double dblCoalesceFactor = 2d;
        double Af = Math.Pow((Math.Sqrt(AirFlowRate * waterViscosity / (waterDensity * gravity)) *
        Math.Tan(Math.Atan(Math.Sqrt(airDensity * gravity * dblA0 / (AirFlowRate * waterViscosity)))
         - FrothHeight / 2 * Math.Sqrt(waterDensity * gravity * AirFlowRate) / SurfaceTension)), 2);
        double Rmax = Math.Sqrt(Math.Exp(dblCoalesceFactor * Math.Sqrt(Af / dblA0) - dblCoalesceFactor));
        return Rmax;
    }

    public double FrothRecoveryFactor(double dblParticleDiam)
    {
        // ===== Froth Recovery =====
        int dblCoverageFactor = 2;
        double dblFilmThick = 3d / 4d * (0.33d / (1d - 0.33d)) * BubbleDiameter;
        double dblCoarsenTime = 4 * waterViscosity * FrothHeight / (waterDensity * gravity * Math.Pow(dblFilmThick, 2d));
        double dblL = waterViscosity / (airDensity * 0.015d); // 1.5 cm/s froth velocity
        double dblRmax = Rmax();
        double dblR_Attachment = dblRmax * Math.Exp(-dblCoverageFactor * (6 * FrothHeight / BubbleDiameter) * (1 - dblRmax) * Math.Pow((dblParticleDiam / BubbleDiameter),2));//part of eq.30
        dblR_Water_max = 0.33d * dblCoarsenTime * (6 * AirFlowRate) / (BubbleDiameter / dblRmax) * Math.Exp(-FrothHeight / dblL); //half of eq. 30
        if (dblR_Water_max > 1)
        {
            dblR_Water_max = 1;
        }
        double dblR_Entrainment = dblR_Water_max * Math.Exp(-0.0325d * (feed.Density - waterDensity) - 0.063d * dblParticleDiam); //half of eq. 30
        double dblFrothRecoveryFactor = dblR_Entrainment + dblR_Attachment;//eq. 30
        return dblFrothRecoveryFactor;
    }

    double Beta(double dblParticleDiam)
    {
        double dblU2Bulk = 2 * Math.Pow(dblEBulk * BubbleDiameter, 2 / 3);
        double dblCollisionDiam = dblParticleDiam + BubbleDiameter;
        return Math.Pow(2, 3 / 2) * Math.Pow(pi, 0.5) * Math.Pow(dblCollisionDiam, 2) * Math.Sqrt(dblU1Bulk + dblU2Bulk);
    }

    /// <summary>
    /// returns the bubble diameter in meters
    /// </summary>
    /// <returns></returns>
    public double BubbleDiameterInMeters() {
        if (BubbleDiameterGiven == false)
        {
            double adjustingParameter = 70;
            double result = Math.Pow(2.11 * SurfaceTension / (waterDensity * Math.Pow(EImpeller, 0.66)), 0.6);
            return result / adjustingParameter;
        } else
        {
            return BubbleDiameter / 1000;
        }
    }

    private double CalculateDensityOfBubbles(double dblParticleDiam, double dblBeta, double dblVolParticle, out double dblNBubble)
    {
        double dblVolBubble = 4 / 3 * pi * Math.Pow(BubbleDiameter / 2, 3);
        dblNBubble = AirFraction / dblVolBubble;
        double dblNParticle = (1 - AirFraction) * dblSlurryFraction / dblVolParticle;
        double dblZBubbParticle = dblBeta * dblNBubble * dblNParticle;
        return SurfaceTension * pi * Math.Pow(dblParticleDiam / 2, 2) *
            (1 - Math.Pow(Math.Cos(feed.CheckContactAngle(dblParticleDiam) * (pi / 180)), 2));
    }

    private double CalculateEnergyDissipation()
    {   
        double dblImpellerZone = 15;
        dblTotalDens = AirFraction * airDensity + (1 - AirFraction) *
        dblSlurryFraction * feed.Density + (1 - dblSlurryFraction) * waterDensity;
        dblEMean = Power / dblTotalDens;
        double dblEBulk = dblBulkZone * dblEMean;
        return dblImpellerZone * dblEMean;
    }

    private double U2Mean(double dblEMean)
    {
        return 2 * Math.Pow(dblEMean * BubbleDiameter, 2 / 3);
    }

    private double U1Mean(double dblEMean, double dblParticleDiam)
    {
        return Math.Pow(0.4 * Math.Pow(dblEMean, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * Math.Pow(feed.Density / waterDensity - 1, 2 / 3), 2);
    }
}
