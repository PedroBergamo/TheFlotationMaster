using System;
using UnityEngine;

public class RecoveryCalculation {
    /// <summary>
    /// Air flow rate in cm/s
    /// </summary>
    public double AirFlowRate;
    /// <summary>
    /// Froth Height in cm
    /// </summary>
    public double FrothHeight;

    private const double pi = 3.141592d;
    private const double waterDensity = 1000d; // kg/m3
    private const double airDensity = 1.2d; // kg/m3
    private const double waterViscosity = 0.001d; // Ns/m2
    private const double c = 2.988d * (10e8); // m/s... speed of light 11
    private const double gravity = 9.813f; //m/s2
    private double dblParticleDiam, dblImpellerDiam;
    private double dblParticleDens, dblTotalDens, dblFeedGrade;
    private double dblCellDiam, dblCellHeight, dblRetTime;
    private double surfaceTension, dblContactAngle;
    private double dblParticleZ, dblBubbleZ, dblDielectric, dblPermitivity;
    private double dblVolCell, dblAirFraction, dblSlurryFraction;
    private double dblEnergyBarrier;
    private double dblRateConst, dblRecovery;
    private double dblDragBeta; // drag coefficient (Goren & O'Niell)
    private double dblH_c_Factor = 5d; // adjustable fitting parameter for dragbeta
    private bool ContactDistribChecked, BubbleSizeEnabled;
    private double dblU1Bulk, dblU2Bulk, dblEBulk;
    public int NumberOfCells = 1;

    // ===== Froth Parameters =====
    double dblB = 3.3d; // fitting parameter
    double dblAlpha = 0.01d; // fitting parameter
    double dblCoverage = 0.5d; // max particle coverage attached in froth
    double dblPFTransfer, dblP_i, dblPr;
    double dblEiw, dblEka;
    double dblRmax;
    // !! see global declarations for more froth parameters !!
    private double dblGrowthFactor; // ratio of bubble size in froth
    private double dblR_Water_max; // max. water rec. in froth (approximation)
    private int ri = 1; // counter for recovery plot marker color
    private int g; // counter for grade
    private double dblOvrRecovery;
    private bool blnCheck; // are all inputs valid?
    //public double[] arrPa = new double[37], arrPc = new double[37], arrPd = new double[37], arrFR = new double[37];
    public double[] arrSizeGrade = new double[38];
    public double dblKinVisc = 1; // kinematic
    private double dblBubbleDiam;


    public double[] CalculateParticleRecoveries(Feed feed)
    {
        CalculateSurfaceTension();
        double[] arrRecovery = new double[101], arrPDiam = new double[101], arrRateK = new double[101];
        dblContactAngle = feed.ContactAngle;
        dblParticleDens = feed.Density * 1000d; // x1000 for kg/m^3
        double dblMassBP;
        double dblVolImpZone = 0.1d; // set impeller
        double dblParticleDiam = 0.000001; // (1 micron)*/
        var loopTo = 100;
        for (int i = 0; i <= loopTo; i++)
        {
            double dblAddRec, dblAddK, dblAddPa, dblAddPc, dblAddPd, dblAddFR, dblR_Water_avg;
            double dblVolParticle = 4 / 3 * pi * Math.Pow(dblParticleDiam / 2, 3);
            double dblVolBP = 1;
            double dblMassParticle = dblParticleDens * dblVolParticle;
            double dblMassTotal = dblVolCell * dblTotalDens;
            dblBubbleDiam = BubbleDiameter();
            double dblNumAttached = dblCoverage * 4 * (dblBubbleDiam / dblParticleDiam);
            double dblBeta = Beta(dblParticleDiam);
            double dblNBubble;
            double dblWorkAdhesion = CalculateDensityOfBubbles(dblParticleDiam, dblBeta, dblVolParticle, out dblNBubble);
            double dblEnergyBarrier = 1;

            // ===== Kinetic Energy of Attachment =====
            double dblKineticEAttach = 0.5d * dblMassParticle;
            double dblKineticEDetach = 0.5d * dblMassParticle;
            // ===== Probabilities =====
            double dblPAtt = Math.Exp(-dblEnergyBarrier / dblKineticEAttach); // prob. of attachment
            double dblPDet = Math.Exp(-(dblWorkAdhesion + dblKineticEAttach) / dblKineticEDetach);
            double dblRe = Math.Sqrt(dblU2Bulk) * dblBubbleDiam / dblKinVisc; // bubble Reynold's number
            double dblPCol = Math.Pow(Math.Tan(Math.Sqrt(3d / 2d * (1 + 3d / 16d * dblRe / (1 + 0.2d * Math.Pow(dblRe, 0.56d)))) * (dblParticleDiam / dblBubbleDiam)), 2);
            // prob.
            // collision(default, modified);
            dblPCol = CheckIfBiggerthanOne(dblPCol);
            dblEiw = gravity / (4 * pi) * Math.Pow(Math.Pow(waterViscosity, 3) / dblEBulk, 0.25d);
            double dblMassBubble = 1;
            dblEka = Math.Pow(dblMassBubble * dblU2Bulk - 2 * Math.Pow(dblBubbleDiam / dblParticleDiam, 2) * dblMassParticle * dblU1Bulk, 2) / (100 * (dblMassBubble + 2 * Math.Pow(dblBubbleDiam / dblParticleDiam, 2) * dblMassParticle));
            dblP_i = 13 * Math.Sqrt(9 * Math.Pow(waterViscosity, 2) / (dblBubbleDiam * surfaceTension * dblTotalDens));
            dblPr = Math.Exp(-dblEiw / dblEka);
            dblPFTransfer = dblP_i * (1 - dblPr);
            double dblFrothRecoveryFactor = FrothRecoveryFactor(dblParticleDiam, dblBubbleDiam);
            // ===== Rate Constant =====
            dblRateConst = dblBeta * dblNBubble * dblPAtt * dblPCol * (1 - dblPDet) * 60;
            // x60 to make 1/min
            double dblRecovery_ci = 1 - Math.Pow(1 + dblRateConst * dblRetTime, (double)-1); // eq 32 (Do & Yoon)
            double dblRecovery_I = dblRecovery_ci * dblFrothRecoveryFactor / (dblRecovery_ci * dblFrothRecoveryFactor + 1 - dblRecovery_ci);
            // eq 6.2 finch & dobby
            dblRecovery = 1 - Math.Pow(1d - dblRecovery_I, NumberOfCells);
            dblAddRec = dblRecovery;
            dblAddK = dblRateConst;
            dblAddPa = dblPAtt;
            dblAddPc = dblPCol;
            dblAddPd = dblPDet;
            dblAddFR = dblFrothRecoveryFactor;
            dblR_Water_avg = dblR_Water_max;

            // ===== Output Results =====
            arrRecovery[i] = dblAddRec * 100; // 100 for percent
            arrPDiam[i] = dblParticleDiam * 1000000; // 10^6 for microns
            arrRateK[i] = dblAddK * dblAddFR;
            //arrPa[i] = dblAddPa * 100;
            //arrPc[i] = dblAddPc * 100;
            //arrPd[i] = (1 - dblAddPd) * 100;
            //arrFR[i] = dblAddFR * 100;
            dblParticleDiam = dblParticleDiam * 1.2d; // increment particle diam                                                         // ==== store recov for grade calc ====
        }
        return arrRecovery;
    }

    private void CalculateSurfaceTension()
    {
        SurfaceTension SF = new SurfaceTension();
        SF.FrotherConcentrate = 192; //following example in didactic/Kyle2011.pdf
        SF.ChosenReagent = SF.Pentanol;
        surfaceTension = SF.CalculateSurfaceTension();
    }

    private static double CheckIfBiggerthanOne(double dblPCol)
    {
        if (dblPCol >= 1)
        {
            dblPCol = 1;
        }
        return dblPCol;
    }

    double FrothRecoveryFactor(double dblParticleDiam, double dblBubbleDiam)
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
            FrothHeight / 2 * Math.Sqrt(waterDensity * gravity * AirFlowRate) / surfaceTension), 2);
        dblRmax = Math.Sqrt(Math.Exp(dblCoalesceFactor * Math.Sqrt(dblAf / dblA0) - dblCoalesceFactor));
        double dblR_Attachment = dblRmax * Math.Exp(-dblCoverageFactor * (6 * FrothHeight / dblBubbleDiam) * (1 - dblRmax) * (dblParticleDiam / dblBubbleDiam));
        dblR_Water_max = 0.33d * dblCoarsenTime * (6 * AirFlowRate) / (dblBubbleDiam / dblRmax) * Math.Exp(-FrothHeight / dblL);
        if (dblR_Water_max > 1)
        {
            dblR_Water_max = 1;
        }
        double dblR_Entrainment = dblR_Water_max * Math.Exp(-0.0325d * (dblParticleDens - waterDensity) - 0.063d * dblParticleDiam);
        double dblFrothRecoveryFactor = dblR_Entrainment + dblR_Attachment;
        return dblFrothRecoveryFactor;
    }

    double Beta(double dblParticleDiam)
    {
        double dblEBulk = 1;
        double dblU1Bulk = 0.4 * Math.Pow(dblEBulk, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * (dblParticleDens / 1);
        double dblU2Bulk = 2 * Math.Pow(dblEBulk * dblBubbleDiam, 2 / 3);
        double dblCollisionDiam = dblParticleDiam + dblBubbleDiam;
        return Math.Pow(2, 3 / 2) * Math.Pow(pi, 0.5) * Math.Pow(dblCollisionDiam, 2) * Math.Sqrt(dblU1Bulk + dblU2Bulk);
    }

    private double BubbleDiameter() {
        if (BubbleSizeEnabled == false)
        {
            double EImpeller = CalculateEnergyDissipation();
            return Math.Pow(2.11 * surfaceTension / (waterDensity * Math.Pow(EImpeller, 0.66)), 0.6);
        } else
        {
            return dblParticleDiam / 1000;
        }
    }

    private double CalculateDensityOfBubbles(double dblParticleDiam, double dblBeta, double dblVolParticle, out double dblNBubble)
    {
        double dblVolBubble = 4 / 3 * pi * Math.Pow(dblBubbleDiam / 2, 3);
        dblNBubble = dblAirFraction / dblVolBubble;
        double dblNParticle = (1 - dblAirFraction) * dblSlurryFraction / dblVolParticle;
        double dblZBubbParticle = dblBeta * dblNBubble * dblNParticle;
        return surfaceTension * pi * Math.Pow(dblParticleDiam / 2, 2) *
            (1 - Math.Pow(Math.Cos(dblContactAngle * (pi / 180)), 2));
    }

    private double CalculateEnergyDissipation()
    {
        double dblDetach_F = 1; // 2 compartment model (Lu)       
        double dblBulkZone = 1;
        double dblImpellerZone = 1;
        dblTotalDens = dblAirFraction * airDensity + (1 - dblAirFraction) *
        dblSlurryFraction * dblParticleDens + (1 - dblSlurryFraction) * waterDensity;
        double SpPower = 1;
        double dblEMean = SpPower / dblTotalDens;
        double dblEBulk = dblBulkZone * dblEMean;
        return dblImpellerZone * dblEMean;
    }

    private double U2Mean(double dblEMean)
    {
        return 2 * Math.Pow(dblEMean * dblBubbleDiam, 2 / 3);
    }

    private double U1Mean(double dblEMean, double dblParticleDiam)
    {
        return Math.Pow(0.4 * Math.Pow(dblEMean, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * Math.Pow(dblParticleDens / waterDensity - 1, 2 / 3), 2);
    }
}
