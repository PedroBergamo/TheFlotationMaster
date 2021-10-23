using System;
using UnityEngine;

public class RecoveryCalculation{

    public double dblAddRec, dblAddK, dblAddPa, dblAddPc, dblAddPd, dblAddFR, dblR_Water_avg;
    private const double pi = 3.141592d;
    private const double waterDensity = 1000d; // kg/m3
    private const double airDensity = 1.2d; // kg/m3
    private const double waterViscosity = 0.001d; // Ns/m2
    private const double c = 2.988d * (10e8); // m/s... speed of light 11
    private const double gravity = 9.813f; //m/s2
    private double dblSpPower, dblSGasRate;
    private double dblParticleDiam, dblImpellerDiam;
    private double dblParticleDens, dblTotalDens, dblFeedGrade;
    private double dblCellDiam, dblCellHeight, dblNumCells, dblRetTime;
    private double dblSurfaceTension, dblContactAngle, dblFrothHeight;
    private double dblParticleZ, dblBubbleZ, dblDielectric, dblPermitivity;
    private double dblVolCell, dblAirFraction, dblSlurryFraction;
    private double dblEnergyBarrier, dblFrotherConc;
    private double dblRateConst, dblRecovery;
    private double dblDragBeta; // drag coefficient (Goren & O'Niell)
    private double dblH_c_Factor = 5d; // adjustable fitting parameter for dragbeta
    private bool ContactDistribChecked, BubbleSizeEnabled;

    // ===== Froth Parameters =====
    double dblR_Entrainment, dblR_Attachment, dblFrothRecoveryFactor; // entrainment and attachment recoveries
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
    public double[] arrPa = new double[37], arrPc = new double[37], arrPd = new double[37], arrFR = new double[37];
    public double[] arrGrMineral = new double[38], arrGrMiddling = new double[38], arrGrGangue = new double[38]; // store recoveries
    public double[] arrSizeGrade = new double[38];
    private double dblEImpeller;


    public double[] CalculateParticleRecoveries(Feed feed)
    {
        double[] arrRecovery = new double[101], arrPDiam = new double[101], arrRateK = new double[101];

        dblContactAngle = feed.ContactAngle;
        dblParticleDens = feed.Density * 1000d; // x1000 for kg/m^3

        // ====begin similar code as maincalc==== 342
        double dblMassBP;
        double dblVolImpZone = 0.1d; // set impeller
        //zone[1d / 10d];
        double gammaMIBC, gammaPPG400, gammaOctanol, gammaPentanol;
        double kMIBC, kPPG400, kOctanol, kPentanol;


        double dblParticleDiam = 0.000001; // (1 micron)*/
        var loopTo = 100;
        for (int i = 0; i <= loopTo; i++)
        {
            dblAddRec = 0;
            dblAddK = 0;
            dblAddPa = 0;
            dblAddPc = 0;
            dblAddPd = 0;
            dblAddFR = 0;
            dblR_Water_avg = 0;

            double dblEMean, dblEBulk;
            CalculateEnergyDissipation(out dblEMean, out dblEBulk);
            double dblCollisionDiam = dblParticleDiam + BubbleDiameter();
            double dblVolParticle = 4 / 3 * pi * Math.Pow(dblParticleDiam / 2, 3);
            double dblVolBubble = 4 / 3 * pi * Math.Pow(BubbleDiameter() / 2, 3);
            double dblVolBP = 1;
            double dblMassParticle = dblParticleDens * dblVolParticle;
            double dblMassTotal = dblVolCell * dblTotalDens;
            double dblU1Bulk, dblU2Bulk;
            double dblNumAttached = dblCoverage * 4 * (BubbleDiameter() / dblParticleDiam);
            double dblKinVisc = 1; // kinematic
            dblU1Bulk = 0.4 * Math.Pow(dblEBulk, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * (dblParticleDens / 1);
            dblU2Bulk = 2 * Math.Pow(dblEBulk * BubbleDiameter(), 2 / 3);
            U1Mean(dblKinVisc, dblEMean, dblParticleDiam);
            U2Mean(dblEMean);
            double dblBeta = Math.Pow(2, 3 / 2) * Math.Pow(pi, 0.5) * Math.Pow(dblCollisionDiam, 2) * Math.Sqrt(dblU1Bulk + dblU2Bulk);
            double dblNBubble;
            double dblWorkAdhesion, dblKineticEAttach, dblKineticEDetach;
            CalculateDensityOfBubbles(out dblWorkAdhesion, dblParticleDiam, dblBeta, dblVolParticle, dblVolBubble, out dblNBubble);

                // ===== Energy Barrier =====

                if (dblEnergyBarrier <= 0)
                {

                    dblEnergyBarrier = 0;

                    // ===== Kinetic Energy of Attachment =====

                    dblKineticEAttach = 0.5 * dblMassParticle;
                    dblKineticEDetach = 0.5 * dblMassParticle;


                    // ===== Probabilities =====

                    double dblPAtt, dblPDet, dblPCol, dblRe;

                    dblPAtt = Math.Exp(-dblEnergyBarrier / dblKineticEAttach);
                    // prob. of attachment*/
                    dblPDet = Math.Exp(-(dblWorkAdhesion + dblKineticEAttach) / dblKineticEDetach);

                    // ===== Kinetic Energy of Attachment =====
                    dblKineticEAttach = 0.5d * dblMassParticle;

                    dblKineticEDetach = 0.5d * dblMassParticle;


                // ===== Probabilities =====
                double dblBubbleDiam = BubbleDiameter();

                    dblPAtt = Math.Exp(-dblEnergyBarrier / dblKineticEAttach); // prob. of attachment
                    dblPDet = Math.Exp(-(dblWorkAdhesion + dblKineticEAttach) / dblKineticEDetach);
                    // prob. of
                    dblRe = Math.Sqrt(dblU2Bulk) * dblBubbleDiam / dblKinVisc; // bubble Reynold's number
                    dblPCol = Math.Pow(Math.Tan(Math.Sqrt(3d / 2d * (1 + 3d / 16d * dblRe / (1 + 0.2d * Math.Pow(dblRe, 0.56d)))) * (dblParticleDiam / dblBubbleDiam)), 2);
                    // prob.
                    // collision(default, modified);
                    if (dblPCol >= 1)
                    {
                        dblPCol = 1;
                    }

                    dblEiw = gravity / (4 * pi) * Math.Pow(Math.Pow(waterViscosity, 3) / dblEBulk, 0.25d);
                    double dblMassBubble = 1;
                    dblEka = Math.Pow(dblMassBubble * dblU2Bulk - 2 * Math.Pow(dblBubbleDiam / dblParticleDiam, 2) * dblMassParticle * dblU1Bulk, 2) / (100 * (dblMassBubble + 2 * Math.Pow(dblBubbleDiam / dblParticleDiam, 2) * dblMassParticle));
                    dblP_i = 13 * Math.Sqrt(9 * Math.Pow(waterViscosity, 2) / (dblBubbleDiam * dblSurfaceTension * dblTotalDens));
                    dblPr = Math.Exp(-dblEiw / dblEka);
                    dblPFTransfer = dblP_i * (1 - dblPr);

                    // ===== Froth Recovery =====
                    /// ===start new froth rec model
                    int dblCoverageFactor = 2;
                    double dblAf;
                    double dblA0;
                    double dblCoarsenTime;
                    double dblFilmThick;
                    double dblCoalesceFactor = 2d;
                    double dblL;
                    dblFilmThick = 3d / 4d * (0.33d / (1d - 0.33d)) * dblBubbleDiam;
                    dblCoarsenTime = 4 * waterViscosity * dblFrothHeight / (waterDensity * gravity * Math.Pow(dblFilmThick, 2d));
                    dblL = waterViscosity / (airDensity * 0.015d); // 1.5 cm/s froth velocity
                    dblA0 = Math.Pow(dblBubbleDiam, 2);
                    dblAf = Math.Pow(Math.Sqrt(dblSGasRate * waterViscosity / (waterDensity * gravity)) * Math.Tan(Math.Sqrt(Math.Tan(airDensity * gravity * dblA0 / (dblSGasRate * waterViscosity))) - dblFrothHeight / 2 * Math.Sqrt(waterDensity * gravity * dblSGasRate) / dblSurfaceTension), 2);
                    dblRmax = Math.Sqrt(Math.Exp(dblCoalesceFactor * Math.Sqrt(dblAf / dblA0) - dblCoalesceFactor));
                    dblR_Attachment = dblRmax * Math.Exp(-dblCoverageFactor * (6 * dblFrothHeight / dblBubbleDiam) * (1 - dblRmax) * (dblParticleDiam / dblBubbleDiam));

                    dblR_Water_max = 0.33d * dblCoarsenTime * (6 * dblSGasRate) / (dblBubbleDiam / dblRmax) * Math.Exp(-dblFrothHeight / dblL);
                    if (dblR_Water_max > 1)
                    {
                        dblR_Water_max = 1;
                    }

                    dblR_Entrainment = dblR_Water_max * Math.Exp(-0.0325d * (dblParticleDens - waterDensity) - 0.063d * dblParticleDiam);
                    dblFrothRecoveryFactor = dblR_Entrainment + dblR_Attachment;

                    // ===== Rate Constant =====
                    double dblRecovery_ci;
                    double dblRecovery_I;
                    dblRateConst = dblBeta * dblNBubble * dblPAtt * dblPCol * (1 - dblPDet) * 60;
                    // x60 to make 1/min
                    dblRecovery_ci = 1 - Math.Pow(1 + dblRateConst * dblRetTime, (double)-1); // eq 32 (Do & Yoon)
                    dblRecovery_I = dblRecovery_ci * dblFrothRecoveryFactor / (dblRecovery_ci * dblFrothRecoveryFactor + 1 - dblRecovery_ci);
                    // eq 6.2 finch & dobby

                    dblRecovery = 1 - Math.Pow(1d - dblRecovery_I, dblNumCells);

                    dblAddRec = dblRecovery;
                    dblAddK = dblRateConst;
                    dblAddPa = dblPAtt;
                    dblAddPc = dblPCol;
                    dblAddPd = dblPDet;
                    dblAddFR = dblFrothRecoveryFactor;
                    dblR_Water_avg = dblR_Water_max;

                // ===== Output Results =====
                    Debug.Log(dblRecovery);
                Debug.Log(i);
                    arrRecovery[i] = dblAddRec * 100; // 100 for percent
                    arrPDiam[i] = dblParticleDiam * 1000000; // 10^6 for microns
                    arrRateK[i] = dblAddK * dblAddFR;
                    //arrPa[i] = dblAddPa * 100;
                    //arrPc[i] = dblAddPc * 100;
                    //arrPd[i] = (1 - dblAddPd) * 100;
                    //arrFR[i] = dblAddFR * 100;
                    dblParticleDiam = dblParticleDiam * 1.2d; // increment particle diam 3
                                                              // ==== store recov for grade calc ====
                }                                      
        }
        return arrRecovery;
    }

    private double BubbleDiameter() {
        if (BubbleSizeEnabled == false)
        {
            return Math.Pow(2.11 * dblSurfaceTension / (waterDensity * Math.Pow(dblEImpeller, 0.66)), 0.6);
        } else
    {
        return dblParticleDiam / 1000;
    }
    }

    private void CalculateDensityOfBubbles(out double dblWorkAdhesion, double dblParticleDiam, double dblBeta, double dblVolParticle, double dblVolBubble, out double dblNBubble)
    {
        // ===== Calc # Density of Bubbles =====

        double dblNParticle;
        dblNBubble = dblAirFraction / dblVolBubble;
        dblNParticle = (1 - dblAirFraction) * dblSlurryFraction / dblVolParticle;
        double dblZBubbParticle = dblBeta * dblNBubble * dblNParticle;
        dblWorkAdhesion = dblSurfaceTension * pi * Math.Pow(dblParticleDiam / 2, 2) * (1 - Math.Pow(Math.Cos(dblContactAngle * (pi / 180)), 2));
    }

    private void CalculateEnergyDissipation(out double dblEMean, out double dblEBulk)
    {
        // ===== Energy Dissipation =====

        double dblBulkZone, dblImpellerZone, dblDetach_F = 1; // 2 compartment model (Lu)
       
        dblBulkZone = 1;
        dblImpellerZone = 1;
        dblTotalDens = dblAirFraction * airDensity + (1 - dblAirFraction) *
        dblSlurryFraction * dblParticleDens + (1 - dblSlurryFraction) * waterDensity;
        dblEMean = dblSpPower / dblTotalDens;
        dblEBulk = dblBulkZone * dblEMean;
        dblEImpeller = dblImpellerZone * dblEMean;
    }

    private double U2Mean(double dblEMean)
    {
        return 2 * Math.Pow(dblEMean * BubbleDiameter(), 2 / 3);
    }

    private double U1Mean(double dblKinVisc, double dblEMean, double dblParticleDiam)
    {
        return Math.Pow(0.4 * Math.Pow(dblEMean, 4 / 9) * Math.Pow(dblParticleDiam, 7 / 9) * Math.Pow(dblKinVisc, (double)-1 / 3) * Math.Pow(dblParticleDens / waterDensity - 1, 2 / 3), 2);
    }
    
}
