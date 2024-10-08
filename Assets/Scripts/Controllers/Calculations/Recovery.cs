/*using System;
using static System.Math; // imports math class to use math functions without qualification

public partial class MainWindow
{
    private const double pi = 3.141592d;
    private const double waterDensity = 1000d; // kg/m3
    private const double airDensity = 1.2d; // kg/m3
    private const double waterViscosity = 0.001d; // Ns/m2
   // private const double c = 2.988d * Pow(10d, 8d); // m/s... speed of light 11 Const gravity As Double = 9.813 'm/s2
    private double dblSpPower, dblSGasRate;
    private double dblBubbleDiam, dblParticleDiam, dblImpellerDiam;
    private double dblParticleDens, dblTotalDens, dblFeedGrade;
    private double dblCellDiam, dblCellHeight, dblNumCells, dblRetTime;
    private double dblSurfaceTension, dblContactAngle, dblFrothHeight;
    private double dblParticleZ, dblBubbleZ, dblDielectric, dblPermitivity;
    private double dblVolCell, dblAirFraction, dblSlurryFraction;
    private double dblEnergyBarrier, dblFrotherConc;
    private double dblRateConst, dblRecovery;
    private double dblDragBeta; // drag coefficient (Goren & O'Niell)
    private double dblH_c_Factor = 5d; // adjustable fitting parameter for dragbeta
    private bool ContactDistribChecked;
    /*
        Input:
        (higher floats smaller particles)

    private double dblGrowthFactor; // ratio of bubble size in froth
    private double dblR_Water_max, dblR_Water_avg; // max. water rec. in froth (approximation)
    private int ri = 1; // counter for recovery plot marker color
    private int g; // counter for grade
    private double dblOvrRecovery;
    private bool blnCheck; // are all inputs valid?
    public double[] arrRecovery = new double[38], arrPDiam = new double[38], arrRateK = new double[38]; // storage arrays 31 Public arrPa(37), arrPc(37), arrPd(37), arrFR(37) As Double
    public double[] arrGrMineral = new double[38], arrGrMiddling = new double[38], arrGrGangue = new double[38]; // store recoveries
    public double[] arrSizeGrade = new double[38];

}
/*private void CalcButton_Click(object sender, EventArgs e)
{
    if (FeedGradeOption.Enabled == true)
    {
        FeedGradeCalc();
    }
    else
    {
        MainCalculation();
    }
}

private void Button_ContactDistrib_Click(object sender, EventArgs e)
{
    ContactDist.ShowDialog();
}

private void Button_FeedGrade_Click(object sender, EventArgs e)
{
    FeedGrade.ShowDialog();
}

private void Button_SizeDist_Click(object sender, EventArgs e)
{
    SizeDist.ShowDialog();
}


// this function adds a tooltip to each series on each graph
public object AddToolTip()
{

    myToolTip = "Specific Power = " + dblSpPower + ControlChars.NewLine + "Gas Rate = " + dblSGasRate + ControlChars.NewLine + "Bubble Diameter = " + Strings.Format((object)dblBubbleDiam, "#.####") + ControlChars.NewLine + "Particle S.G. = " + dblParticleDens / 1000d + ControlChars.NewLine + "Air Fraction = " + dblAirFraction + ControlChars.NewLine + "Slurry Fraction = " + dblSlurryFraction + ControlChars.NewLine + ;




    /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 3753


    Input:
     "Frother = " & ComboBox_Frother.Text & ControlChars.NewLine & _ 85 "Frother Concentration = " & dblFrotherConc & ControlChars. NewLine & _
     "Contact Angle = " & dblContactAngle & ControlChars.NewLine & _ 87 "Dielectric Constant = " & dblDielectric & ControlChars.NewLine &_


/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 4030


Input:
 "Particle Zeta Potential = " & dblParticleZ & ControlChars. NewLine & _
 "Bubble Zeta Potential = " & dblBubbleZ & ControlChars.NewLine & _
 "Permitivity = " & dblPermitivity & ControlChars.NewLine & _
 "Cell Diameter = " & dblCellDiam & ControlChars.NewLine & _
 "Cell Height = " & dblCellHeight & ControlChars.NewLine & _
 "Impeller Diameter = " & dblImpellerDiam & ControlChars.NewLine &_


/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 4429


Input:
 "Number of Cells = " & dblNumCells & ControlChars.NewLine &



/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 4491


Input:
 "Retention Time = " & dblRetTime & ControlChars.NewLine & _
 "Froth Height = " & dblFrothHeight & ControlChars.NewLine &


/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 4615


Input:
 "Growth Factor = " & dblGrowthFactor & ControlChars.NewLine


/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 4677


Input:
 "Max. Water Rec. = " & Format(dblR_Water_max, "#.####")

Chart_Rec2.Series(ri).ToolTip = myToolTip;
Chart_RecLinear.Series(ri).ToolTip = myToolTip;
ChartK.Series(ri).ToolTip = myToolTip;
Chart_Pa.Series(ri).ToolTip = Chart_Pc.Series(ri).ToolTip == Chart_Pd.Series(ri).ToolTip == Chart_FRec.Series(ri).ToolTip;
myToolTip();
myToolTip();
myToolTip();
;

/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 5052


Input:
= myToolTip


return default;
}




public object ContactAngleDist()
{
    if (ContactDistribChecked == true)
    {
        if (dblParticleDiam < 0.000015d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD15.Text);
        }
        else if (dblParticleDiam < 0.000025d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD25.Text) - Val;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 8862


            Input:
            (ContactDist.TextBox_CD25.Text) - Val(ContactDist.TextBox_CD15.Text)) _ 187 * ((0.000025 - dblParticleDiam) / 0.00001))


        }
        // interpolates contact angle between entered values

        else if (dblParticleDiam < 0.000038d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD38.Text) - Val;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 9147


            Input:
            (ContactDist.TextBox_CD38.Text) - Val(ContactDist.TextBox_CD25.Text)) _ 191 * ((0.000038 - dblParticleDiam) / 0.000013))


        }
        else if (dblParticleDiam < 0.000045d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD45.Text) - Val;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 9381


            Input:
            (ContactDist.TextBox_CD45.Text) - Val(ContactDist.TextBox_CD38.Text)) _ 195 * ((0.000045 - dblParticleDiam) / 0.000007))


        }
        else if (dblParticleDiam < 0.000075d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD75.Text) - Val;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 9615


            Input:
            (ContactDist.TextBox_CD75.Text) - Val(ContactDist.TextBox_CD45.Text)) _ 199 * ((0.000075 - dblParticleDiam) / 0.00003))


        }
        else if (dblParticleDiam < 0.000106d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD106.Text) - Val;
            ;
            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 9849


            Input:
            (ContactDist.TextBox_CD106.Text) - Val(ContactDist.TextBox_CD75.Text)) _ 203 * ((0.000106 - dblParticleDiam) / 0.000031))


        }
        else if (dblParticleDiam < 0.00015d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD150.Text) - Val;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 10084


            Input:
            (ContactDist.TextBox_CD150.Text) - Val(ContactDist.TextBox_CD106.Text)) _ 207 * ((0.00015 - dblParticleDiam) / 0.000044))


        }
        else if (dblParticleDiam < 0.00018d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD180.Text) - Val;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 10323


            Input:
            (ContactDist.TextBox_CD180.Text) - Val(ContactDist.TextBox_CD150.Text)) _ 211 * ((0.00018 - dblParticleDiam) / 0.00003))


        }
        else if (dblParticleDiam < 0.00025d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD250.Text) - Val;
            ;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 10557


            Input:
            (ContactDist.TextBox_CD250.Text) - Val(ContactDist.TextBox_CD180.Text)) _ 215 * ((0.00025 - dblParticleDiam) / 0.00007))


        }
        else if (dblParticleDiam < 0.000425d)
        {
            dblContactAngle = Val(ContactDist.TextBox_CD425.Text) - Val;
            ;

            /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 10792


            Input:
            (ContactDist.TextBox_CD425.Text) - Val(ContactDist.TextBox_CD250.Text)) _ 219 * ((0.000425 - dblParticleDiam) / 0.000175))


        }
        else
        {
            dblContactAngle = 0d;
        }

        if (dblContactAngle >= 88.7d)
        {
            dblContactAngle = 88.7d;
        }
    }

    return default;
}

public object EnergyBarrier()
{
    object dblA132_s, dblK132_s, dblK131, a, b_k;
    double dblA11 = 3d * Pow(10d, -19); // Hamaker
    double dblA22 = 0d; //
    double dblA33 = 4.38d * Pow(10d, -20); //
    double dblK232 = 4.07d * Pow(10d, -18); // Hydrophobic force constant
    double dblKappa = 1d / (9.6d * Pow(10d, -8)); // inverse Debye Length
    double dblVT, dblVE, dblVD, dblVH; // total free energy of
    default
/* Cannot convert InvocationExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
at ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.WithRemovedRedundantConversionOrNullAsync(InvocationExpressionSyntax conversionNode, ISymbol invocationSymbol) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\ExpressionNodeVisitor.cs:line 821
at ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.ConvertInvocationAsync(InvocationExpressionSyntax node, ISymbol invocationSymbol) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\ExpressionNodeVisitor.cs:line 876
at ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.VisitInvocationExpression(InvocationExpressionSyntax node) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\ExpressionNodeVisitor.cs:line 858
at ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.ConvertHandledAsync[T](VisualBasicSyntaxNode vbNode, SourceTriviaMapKind sourceTriviaMap) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\CommentConvertingVisitorWrapper.cs:line 48

Input:
Global.Microsoft.VisualBasic.interaction, electrostatic, van-der waals, hydrophobic force


;
    double dblVT1, dblVE1, dblVD1, dblVH1; // second state of above variables
    double b = 3d * Pow(10d, -17); // correct for retardation effects (most mat'ls)
    double l = 3.3d * Pow(10d, 15d); // correction for retardation effects (water, !!change for other media)
    double dblH0 = 1d * Pow(10d, -11); // separation between bubb & part 244 Dim dblH1 As Double 'for incrementing
    double dblH = 0d;
    double Ce, Cd, Ch; // coefficients of eq 14,15,16 - for efficiency of calculation

    // ===== Get Textbox Value =====
    dblDielectric = Val(TextBox_DielectricConst.Text);
    dblPermitivity = Val(TextBox_Permitivity.Text) * Pow(10d, -12); // 10^12 for right
    units();

    // ===== Calc Barrier =====
    if (dblContactAngle < 86.89d)
        ;

    /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 12289


    Input:
    254 a = 2.732 * 10 ^ -21


    b_k = 0.04136d;

    /* Cannot convert ElseIfStatementSyntax, CONVERSION ERROR: Conversion for ElseIfStatement not implemented, please report this issue in 'ElseIf 86.889 <= Me.dblCont...' at character 12332


    Input:
     ElseIf 86.889 <= Me.dblContactAngle < 92.28 Then


    a = 4.888d * Pow(10d, (double)-44);
    b_k = 0.6441d;
    double();
/* Cannot convert InvocationExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
at ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.WithRemovedRedundantConversionOrNullAsync(InvocationExpressionSyntax conversionNode, ISymbol invocationSymbol) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\ExpressionNodeVisitor.cs:line 821
at ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.ConvertInvocationAsync(InvocationExpressionSyntax node, ISymbol invocationSymbol) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\ExpressionNodeVisitor.cs:line 876
at ICSharpCode.CodeConverter.CSharp.ExpressionNodeVisitor.VisitInvocationExpression(InvocationExpressionSyntax node) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\ExpressionNodeVisitor.cs:line 858
at ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.ConvertHandledAsync[T](VisualBasicSyntaxNode vbNode, SourceTriviaMapKind sourceTriviaMap) in D:\a\CodeConverter\CodeConverter\CodeConverter\CSharp\CommentConvertingVisitorWrapper.cs:line 48

Input:
Global.Microsoft.VisualBasic.Constants



    /* Cannot convert ElseStatementSyntax, CONVERSION ERROR: Conversion for ElseStatement not implemented, please report this issue in 'Else' at character 12468


    Input:
    Else


    a = 6.327d * Pow(10d, (double)-27); /* TODO ERROR: Skipped SkippedTokensTrivia
261 /* TODO ERROR: Skipped SkippedTokensTrivia
b_k = 0.2172

    /* Cannot convert EndBlockStatementSyntax, CONVERSION ERROR: Conversion for EndIfStatement not implemented, please report this issue in 'End If' at character 12515


    Input:
     End If

    dblK131 = a * Math.Exp(b_k * dblContactAngle);
    dblK132_s = Math.Sqrt(dblK131 * dblK232);
    dblA132_s = (Sqrt(dblA11) - Sqrt(dblA33)) * (Sqrt(dblA22) - Sqrt(dblA33));
    Ce = pi * (dblPermitivity * dblDielectric * (dblParticleDiam * dblBubbleDiam / 4d) * (Pow(dblParticleZ, 2d) + Pow(dblBubbleZ, 2d))) / (dblParticleDiam / 2d + dblBubbleDiam / 2d);

    Cd = -(dblA132_s * (dblParticleDiam * dblBubbleDiam / 4d)) / (6d * (dblParticleDiam / 2d + dblBubbleDiam / 2d));
    Ch = -(dblParticleDiam * dblBubbleDiam / 4d * dblK132_s) / (6d * (dblParticleDiam / 2d + dblBubbleDiam / 2d));
    int x = 0;
    while (x == 0)
    {
        // equation 14 using H0(Do & Yoon)
        dblVE = Ce * (2d * dblParticleZ * dblBubbleZ / (Pow(dblParticleZ, 2d) +
        Pow(dblBubbleZ, 2d)) * Log((1d + Exp(-dblKappa * dblH0)) /
        (1d - Exp(-dblKappa * dblH0))) + Log(1d - Exp(-2 * dblKappa * dblH0)));


        dblVD = Cd / dblH0 * (1d - (1d + 2d * b * l) / (1d + b * c / dblH0)); // equation 15 using H0(Do & Yoon)
        dblVH = Ch / dblH0; // equation 16 using H0(Do & Yoon)
        dblVT = dblVE + dblVD + dblVH; // extended DLVO theory
        dblH1 = dblH0 + 1d * Pow(10d, -11);

        // equation 14 using H1(Do & Yoon)
        dblVE1 = Ce * (2d * dblParticleZ * dblBubbleZ / (Pow(dblParticleZ, 2d) + Pow(dblBubbleZ, 2d)) *
    Math.Log((1d + Math.Exp(-dblKappa * dblH1)) / (1d - Math.Exp(-dblKappa * dblH1))) +
Math.Log(1d - Math.Exp((double)-2 * dblKappa * dblH1)));


        dblVD1 = Cd / dblH1 * (1 - (1d + 2d * b * l) / (1 + b * c / dblH1)); // equation 15 using H1(Do & Yoon)
        dblVH1 = Ch / dblH1; // equation 16 using H1(Do & Yoon();
        dblVT1 = dblVE1 + dblVD1 + dblVH1; // extended DLVO theory 2nd state 302
        if (dblVT > dblVT1)
        {
            dblH = dblH0;
            dblDragBeta = 0.37d * Pow(dblParticleDiam / 2d / dblH / dblH_c_Factor, 0.83d); // h_c_factor is adjustable
            dblEnergyBarrier = dblVT;
            x = 1;
        }
        else
        {
            dblH0 = dblH1 + 1d * Pow(10d, -9);
        } // increments H0 to find correct value 310 End If
    }

    return default;
}

public object FeedGradeCalc() // used when user inputs multiple feeds 316
{
    double[] arrContactAngles = new double[4], arrFeedFractions = new double[4];
    double[] arrDensities = new double[4], arrGrades = new double[4];
    double dblFGRecovery = 0d;
    int x; // counter for 3 feeds
    double dblMidRec, dblMinRec, dblGangRec;
    arrContactAngles[1] = Val(FeedGrade.TextBox_MineralContactAngle.Text);
    arrContactAngles[2] = Val(FeedGrade.TextBox_MiddlingsContactAngle.Text);
    arrContactAngles[3] = Val(FeedGrade.TextBox_GangueContactAngle.Text);
    arrFeedFractions[1] = Val(FeedGrade.TextBox_MineralFraction.Text);
    arrFeedFractions[2] = Val(FeedGrade.TextBox_MiddlingsFraction.Text);
    arrFeedFractions[3] = Val(FeedGrade.TextBox_GangueFraction.Text);
    arrDensities[1] = Val(FeedGrade.TextBox_MineralDensity.Text);
    arrDensities[2] = Val(FeedGrade.TextBox_MiddlingsDensity.Text);
    arrDensities[3] = Val(FeedGrade.TextBox_GangueDensity.Text);
    arrGrades[1] = arrGrades[2] == arrGrades[3] == ;
    Val(FeedGrade.TextBox_MineralGrade.Text); /* TODO ERROR: Skipped SkippedTokensTrivia
Val/* TODO ERROR: Skipped SkippedTokensTrivia
(FeedGrade.TextBox_MiddlingsGrade.Text) Val(FeedGrade.TextBox_GangueGrade.Text)
    for (x = 1; x <= 3; x++)
    {
        dblContactAngle = arrContactAngles[x];
        dblParticleDens = arrDensities[x] * 1000d; // x1000 for kg/m^3

        // ====begin similar code as maincalc==== 342
        double dblVolBubble, dblVolParticle, dblVolBP;
        double dblMassBubble, dblMassParticle, dblMassBP, dblMassTotal;
        double dblCollisionDiam, dblNumAttached;
        double dblKinVisc; // kinematic
        viscosity();
        double dblBulkZone, dblImpellerZone, dblDetach_F; // 2 compartment model (Lu)
        double dblVolImpZone = 0.1d; // set impeller
        zone[1d / 10d];
        double dblEMean, dblEBulk, dblEImpeller = default; // energy
        dissipations();
        double dblU1Bulk, dblU2Bulk, dblU1Mean, dblU2Mean;
        double dblBeta, dblNParticle, dblNBubble, dblZBubbParticle;
        double dblWorkAdhesion, dblKineticEAttach, dblKineticEDetach;
        double gammaMIBC, gammaPPG400, gammaOctanol, gammaPentanol;
        double kMIBC, kPPG400, kOctanol, kPentanol;
        double dblPAtt, dblPDet, dblPCol, dblRe;
        // probabilities

        double[] arrBRecovery = new double[38], arrBPDiam = new double[38], arrBRateK = new double[38]; // storage arrays for bubble dist
        double[] arrBPa = new double[38], arrBPc = new double[38], arrBPd = new double[38], arrBFR = new double[38];
        dblBulkZone = 0.5d;
        dblImpellerZone = 15d;
        dblDetach_F = 1d; // adjustable parameter for fitting

        // ===== Froth Parameters =====
        double dblR_Entrainment, dblR_Attachment, dblFrothRecoveryFactor; // entrainment and attachment recoveries
        double dblB = 3.3d; // fitting parameter
        double dblAlpha = 0.01d; // fitting parameter
        double dblCoverage = 0.5d; // max particle coverage attached in froth
        double dblPFTransfer, dblP_i, dblPr;
        double dblEiw, dblEka;
        double dblRmax;
        // !! see global declarations for more froth parameters !!


        // ===== Get Textbox Values =====
        dblSpPower = Val(TextBox_SpecificPower.Text) * 1000; // x1000 for w/m^3
        dblSGasRate = Val(TextBox_SpecificAir.Text) / 100; // /100 for m/s
                                                           // dblParticleDens = Val(TextBox_ParticleDensity.Text) * 1000 'x1000 for
        kg( / Math.Pow(m, 3));
        dblAirFraction = Val(TextBox_AirFraction.Text);
        dblSlurryFraction = Val(TextBox_SlurryFraction.Text);
        dblImpellerDiam = Val(TextBox_ImpellerDiameter.Text);
        // dblContactAngle = Val(TextBox_ContactAngle.Text)
        dblParticleZ = Val(TextBox_ParticleZ.Text);
        dblBubbleZ = Val(TextBox_BubbleZ.Text);
        dblCellHeight = Val(TextBox_CellHeight.Text);
        dblCellDiam = Val(TextBox_CellDiameter.Text);
        dblNumCells = Val(TextBox_NumCells.Text);
        dblRetTime = Val(TextBox_RetentionTime.Text);
        dblFrothHeight = Val(TextBox_FrothHeight.Text);
        dblFrotherConc = Val(TextBox_FrotherConc.Text);
        gammaMIBC = 0.000005d; // mol/m^2
        gammaPPG400 = 0.000001d; // mol/m^2
        gammaOctanol = 0.000008d; // mol/m^2
        gammaPentanol = 0.000006d; // mol/m^2
        kMIBC = 230d; // M^-1
        kPPG400 = 1700000d; // M^-1
        kOctanol = 2200d; // M^-1
        kPentanol = 55d; // M^-1
        if (ComboBox_Frother.Text == "MIBC")
        {
            dblFrotherConc = Conversions.ToDouble(dblFrotherConc / dblSurfaceTension == 0.07243d - 8.314d * (273.15d + 23d) * gammaMIBC * Log(kMIBC * dblFrotherConc + 1d));
        }
        else if (ComboBox_Frother.Text == "PPG 400")
        {
            dblFrotherConc = dblFrotherConc / 134170d; // convert ppm to mol/L
            dblSurfaceTension = 0.07243d - 8.314d * (273.15d + 23d) * gammaPPG400 * Log(kPPG400 * dblFrotherConc + 1d);
        }
        else if (ComboBox_Frother.Text == "Octanol")
        {
            dblFrotherConc = dblFrotherConc / 130230d; // convert ppm to mol/L
            dblSurfaceTension = 0.07243d - 8.314d * (273.15d + 23d) * gammaOctanol * Log(kOctanol * dblFrotherConc + 1d);
        }
        else if (ComboBox_Frother.Text == "Pentanol")
        {
            dblFrotherConc = dblFrotherConc / 88150d; // convert ppm to mol/L
            dblSurfaceTension = 0.07243d - 8.314d * (273.15d + 23d) * gammaPentanol;
            ;
        else
        {
            dblSurfaceTension = 0.07243d;
        } // pure water @ 23°C

        TextBox_SurfaceTension.Text = Strings.Format((object)(dblSurfaceTension * 1000d), "##.##"); /* TODO ERROR: Skipped SkippedTokensTrivia

        CheckInputs(); // call function check for input values
        if (blnCheck == false)
        {
            ;


            // ===== BEGIN MULTIPARTICLE LOOP =====
            dblParticleDiam = 0.000001d; // (1 micron)
            int i;
            double dblAddRec, dblAddK, dblAddPa, dblAddPc, dblAddPd, dblAddFR;
            for (i = 0; i <= 37; i++) // particle loop
            {
                dblAddRec = 0d;
                dblAddK = 0d;
                dblAddPa = 0d;
                dblAddPc = 0d;
                dblAddPd = 0d;
                dblAddFR = 0d;
                dblR_Water_avg = 0d;


                // ===== Energy Dissipation =====

                dblTotalDens = dblAirFraction * airDensity + (1d - dblAirFraction) * dblSlurryFraction * dblParticleDens + (1d - dblSlurryFraction) * waterDensity;

                dblEMean = dblSpPower / dblTotalDens;
                dblEBulk = dblBulkZone * dblEMean;
                dblEImpeller = dblImpellerZone * dblEMean; /* TODO ERROR: Skipped SkippedTokensTrivia

                if (TextBox_BubbleSize.Enabled == false)
                {
                    dblBubbleDiam = Pow(2.11d * dblSurfaceTension / (waterDensity * Pow(dblEImpeller, 0.66d)), 0.6d);
                }
                else
                {
                    dblBubbleDiam = Val(TextBox_BubbleSize.Text) / 1000;
                };

                // ===== Cell Calculations =====
                dblCollisionDiam = dblParticleDiam + dblBubbleDiam; // avg
                diam();
                dblVolParticle = 4d / 3d * pi * Pow(dblParticleDiam / 2d, 3d); // vol 1 part.
                dblVolBubble = 4d / 3d * pi * Pow(dblBubbleDiam / 2d, 3d); // vol 1 bubb.
                dblVolBP = 1d; /* 
aggregate
                this.dblVolCell();
                dblKinVisc();
                dblMassParticle = dblParticleDens * dblVolParticle; // mass 1
                part.dblMassBubble = airDensity * dblVolBubble; // mass 1
                bubb.dblMassBP = dblMassBubble + dblMassParticle; // mass of 1
                BP(aggregate);
                dblMassTotal = dblVolCell * dblTotalDens;
                dblNumAttached = dblCoverage * 4d * (dblBubbleDiam / dblParticleDiam);
                // num of particles attached to one bubble
                dblVolBubble(+dblVolParticle);
                ;


                // ===== Velocities by Dissipation =====
                dblU1Bulk = 0.4d * Pow(dblEBulk, 4d / 9d) * Pow(dblParticleDiam, 7d / 9d) * Pow(dblKinVisc, (double)-1 / 3d) * (dblParticleDens / );
                attachment();
                dblU2Bulk = 2d * Pow(dblEBulk * dblBubbleDiam, 2d / 3d);
                dblU1Mean = Pow(0.4d * Pow(dblEMean, 4d / 9d) * Pow(dblParticleDiam, 7d / 9d) * Pow(dblKinVisc, (double)-1 / 3d) * Pow(dblParticleDens / waterDensity - 1d, 2d / 3d), 2d);

                dblU2Mean = 2d * Pow(dblEMean * dblBubbleDiam, 2d / 3d); /* TODO ERROR: Skipped SkippedTokensTrivia

                dblBeta = Pow(2d, 3d / 2d) * Pow(pi, 0.5d) * Pow(dblCollisionDiam, 2d) * Sqrt(dblU1Bulk + dblU2Bulk);
                // from Abrahamson model
                using (bulk) /* TODO ERROR: Skipped SkippedTokensTrivia

                {

                    // ===== Calc # Density of Bubbles =====
                    dblNBubble = dblAirFraction / dblVolBubble;
                    dblNParticle = (1d - dblAirFraction) * dblSlurryFraction / dblVolParticle;
                    dblZBubbParticle = dblBeta * dblNBubble * dblNParticle;
                    dblWorkAdhesion = dblSurfaceTension * pi * Pow(dblParticleDiam / 2d, 2d) * (1d - Pow(Cos(dblContactAngle * (pi / 180d)), 2d));
                    // calc work of adhesion for 1 particle

                    // ===== Energy Barrier =====
                    EnergyBarrier(); // calls function to calc energy barrier
                    if (dblEnergyBarrier <= 0d)
                    {
                        dblEnergyBarrier = 0d;
                    }

                    // ===== Kinetic Energy of Attachment =====
                    dblKineticEAttach = 0.5d * dblMassParticle;
                    ;

                    dblKineticEDetach = 0.5d * dblMassParticle;
                    ;

                    dblKinVisc();

                    // ===== Probabilities =====
                    dblPAtt = Exp(-dblEnergyBarrier / dblKineticEAttach); // prob. of attachment
                    dblPDet = Exp(-(dblWorkAdhesion + dblKineticEAttach) / dblKineticEDetach);
                    // prob. of
                    detachment();

                     '===== Kinetic Energy of Attachment =====
                     dblKineticEAttach = 0.5 * dblMassParticle
                    ^ 2)
                     dblKineticEDetach = 0.5 * dblMassParticle
                    (dblParticleDiam _
                     + dblBubbleDiam) * Sqrt(dblEImpeller /
                    dblKinVisc)) ^ 2

                     '===== Probabilities =====
                     dblPAtt = Exp(-dblEnergyBarrier / dblKineticEAttach) 'prob. of attachment
                     dblPDet = Exp(-(dblWorkAdhesion + dblKineticEAttach) _
                     / dblKineticEDetach) 'prob. of
                    detachment
                     dblRe = Sqrt(dblU2Bulk) * dblBubbleDiam / dblKinVisc 'bubble Reynold's number

                     dblPCol = Tanh(Sqrt(3 / 2 * (1 + (3 / 16 * dblRe) / (1 + 0.2 * dblRe ^ 0.56))) _
                     * (dblParticleDiam / dblBubbleDiam)) ^ 2 'prob.
                    collision, modified Luttrell and Yoon


                    if (dblPCol >= 1){
                    return dblU1Bulk / (dblDragBeta
                    * (dblDetach_F *  1 }



                     dblEiw = gravity / (4 * pi) * (waterViscosity ^ 3 / dblEBulk) ^ 0.25
                     dblEka = (dblMassBubble * dblU2Bulk - 2 * (dblBubbleDiam /
                    dblParticleDiam) ^ 2 * dblMassParticle * dblU1Bulk) ^ 2 _
                     / (100 * (dblMassBubble + 2 * (dblBubbleDiam / dblParticleDiam) ^ 2 * dblMassParticle))

                     dblP_i = 13 * Sqrt((9 * waterViscosity ^ 2) / (dblBubbleDiam * dblSurfaceTension * dblTotalDens))
                     dblPr = Exp(-dblEiw / dblEka)
                     dblPFTransfer = dblP_i * (1 - dblPr)


                     '===== Froth Recovery =====
                     '''===start new froth rec model
                     Dim dblCoverageFactor = 2
                     Dim dblAf As Double
                     Dim dblA0 As Double
                     Dim dblCoarsenTime As Double
                     Dim dblFilmThick As Double
                     Dim dblCoalesceFactor As Double = 2
                     Dim dblL As Double

                     dblFilmThick = 3 / 4 * (0.33 / (1 - 0.33)) * dblBubbleDiam
                     dblCoarsenTime = (4 * waterViscosity * dblFrothHeight) /
                    (waterDensity * gravity * dblFilmThick ^ 2)
                     dblL = waterViscosity / (airDensity * 0.015) '1.5 cm/s froth velocity


                     dblA0 = (dblBubbleDiam) ^ 2

                     dblAf = (Sqrt(dblSGasRate * waterViscosity / (waterDensity * gravity)) * Tan(Atan(Sqrt(airDensity * gravity * dblA0 / (dblSGasRate * waterViscosity))) _
                     - dblFrothHeight / 2 * Sqrt(waterDensity * gravity *
                    dblSGasRate) / dblSurfaceTension)) ^ 2

                     dblRmax = Sqrt(Exp(dblCoalesceFactor * Sqrt(dblAf / dblA0) - dblCoalesceFactor))

                     dblR_Attachment = dblRmax * Exp(-dblCoverageFactor * (6 * dblFrothHeight / (dblBubbleDiam)) _
                     * (1 - dblRmax) * (dblParticleDiam / dblBubbleDiam)
                    ^ 2)


                     dblR_Water_max = (0.33 * dblCoarsenTime * (6 * dblSGasRate) / (dblBubbleDiam / dblRmax)) * Exp(-dblFrothHeight / dblL)

                     If dblR_Water_max > 1 Then
                     dblR_Water_max = 1
                     End If

                     dblR_Entrainment = dblR_Water_max * Exp(-0.0325 * (dblParticleDens - waterDensity) - 0.063 * dblParticleDiam)

                     dblFrothRecoveryFactor = dblR_Entrainment + dblR_Attachment




                     '===== Rate Constant =====
                     Dim dblRecovery_ci As Double
                     Dim dblRecovery_I As Double


                     dblRateConst = dblBeta * dblNBubble * dblPAtt * dblPCol _
                     * (1 - dblPDet) * 60 'x60 to make 1/min
                     dblRecovery_ci = 1 - (1 + dblRateConst * dblRetTime) ^ (-1) 'eq 32 (Do & Yoon)

                     dblRecovery_I = dblRecovery_ci * dblFrothRecoveryFactor / (dblRecovery_ci * _
                     dblFrothRecoveryFactor + 1 - dblRecovery_ci)
                    'eq 6.2 finch & dobby

                     dblRecovery = 1 - (1 - dblRecovery_I) ^ dblNumCells

                     ''==== grade vs recov ====
                     'Dim dblGRec_ci, dblGRec_i, dblGRec As Double 'grade v rec variables
                     'Dim dblGradeRet As Double = 0.5
                     'Dim f As Integer
                     'For f = 1 To 29
                     ' dblGRec_ci = 1 - (1 + dblRateConst * dblGradeRet) ^ (-1)

                     ' dblGRec_i = dblGRec_ci * dblFrothRecoveryFactor / (dblGRec_ci * _
                     ' dblFrothRecoveryFactor + 1 - dblGRec_ci)

                     ' dblGRec = 1 - (1 - dblGRec_i) ^ dblNumCells
                     ' arrRecGrade(x, i, f) = dblGRec

                     ' dblGradeRet = dblGradeRet * 2 '~~29 iterations
                     'Next f


                    '========!!!!!!!!! insert condtional code here for hydrophobic coagulation and water recovery
                     'if dblParticleDiam < specified size (~ < 15 micron)
                     'then multiply by some factors or use equations
                     ' changes recovery for that size fraction

                     dblAddRec = dblRecovery
                     dblAddK = dblRateConst
                     dblAddPa = dblPAtt
                     dblAddPc = dblPCol
                     dblAddPd = dblPDet
                     dblAddFR = dblFrothRecoveryFactor
                    dblR_Water_avg = dblR_Water_max 0

                     '===== Output Results =====

                     arrRecovery(i) = dblAddRec * 100 '100 for percent
                     arrPDiam(i) = dblParticleDiam * 1000000 '10^6 for microns
                     arrRateK(i) = dblAddK * dblAddFR
                     arrPa(i) = dblAddPa * 100


                    arrPc(i) = dblAddPc * 100
                     arrPd(i) = (1 - dblAddPd) * 100
                     arrFR(i) = dblAddFR * 100

                     dblParticleDiam = dblParticleDiam * 1.2 'increment particle diam 3
                     '==== store recov for grade calc ====
                     If x = 1 Then
                     arrGrMineral(i) = arrRecovery(i)
                     ElseIf x = 2 Then
                     arrGrMiddling(i) = arrRecovery(i)
                     Else
                     arrGrGangue(i) = arrRecovery(i)
                     End If

                     Next i

                     '===== Graphs =====
                     ChartK.Series.Add(ri)
                     ChartK.Series(ri).ChartType = SeriesChartType.Line
                     Chart_Rec2.Series.Add(ri)
                     Chart_Rec2.Series(ri).ChartType = SeriesChartType.Line
                     Chart_RecLinear.Series.Add(ri)
                     Chart_RecLinear.Series(ri).ChartType = SeriesChartType.Line
                     Chart_Pa.Series.Add(ri)
                     Chart_Pa.Series(ri).ChartType = SeriesChartType.Line 5 Chart_Pc.Series.Add(ri)
                     Chart_Pc.Series(ri).ChartType = SeriesChartType.Line 7 Chart_Pd.Series.Add(ri)
                     Chart_Pd.Series(ri).ChartType = SeriesChartType.Line 9 Chart_FRec.Series.Add(ri)
                     Chart_FRec.Series(ri).ChartType = SeriesChartType.Line
                     Chart_Grade.Series.Add(ri)
                     Chart_Grade.Series(ri).ChartType = SeriesChartType.Line

                     Dim n As Integer
                     For n = 0 To
                     ChartK.Series(ri).Points.AddXY(arrPDiam(n), arrRateK(n))
                     Chart_Rec2.Series(ri).Points.AddXY(arrPDiam(n), arrRecovery(n))
                     Chart_RecLinear.Series(ri).Points.AddXY(arrPDiam(n), arrRecovery(n))
                     Chart_Pa.Series(ri).Points.AddXY(arrPDiam(n), arrPa(n))
                     Chart_Pc.Series(ri).Points.AddXY(arrPDiam(n), arrPc(n))
                     Chart_Pd.Series(ri).Points.AddXY(arrPDiam(n), arrPd(n))
                     Chart_FRec.Series(ri).Points.AddXY(arrPDiam(n), arrFR(n))
                     Next

                     Call

                     ri =

                     Call SizeDistribution()

                     dblFGRecovery = dblFGRecovery + dblOvrRecovery * arrFeedFractions(x) / 100

                     If x = 1 Then
                     dblMinRec = dblOvrRecovery
                    5 ElseIf x = 2 Then
                    6 dblMidRec = dblOvrRecovery
                    AddToolTip() 'adds info to the graphs
                    ri + 1 'increment series number and color


                     Else
                     dblGangRec = dblOvrRecovery
                     End If

                     Next x


                     ''==== plot grade v pdiam ====
                     Dim m As Integer

                     For m = 0 To
                     arrSizeGrade(m) = (arrGrMineral(m) * arrFeedFractions(1) + arrGrMiddling (m) * arrFeedFractions(2) * 0.5) / _
                     (arrGrMineral(m) * arrFeedFractions(1) + arrGrMiddling
                    (m) * arrFeedFractions(2) + _
                     arrGrGangue(m) * arrFeedFractions(3)) * 100
                     Chart_Grade.Series(ri - 1).Points.AddXY(arrPDiam(m), arrSizeGrade(m))
                     Next


                     '===== Temp Outputs for Debugging =====
                     'MsgBox("Some Outputs Temporary for Debugging")
                     If dblOvrRecovery > 0 Then
                     Label_RecoveryOutput.Text = Format(dblFGRecovery, "#.###" & " %") 9 End If

                     label_VolCellOutput.Text = Format(dblVolCell, "#.###") & " m3"
                     label_WaterRecOut.Text = Format(dblR_Water_avg * 100, "#.###") & " %"
                     Dim dblProductGrade, dblOvrMineralRec As Double
                     dblProductGrade = (dblMinRec * arrGrades(1) * arrFeedFractions(1) +
                    dblMidRec * arrGrades(2) * arrFeedFractions(2) + dblGangRec * arrGrades(3) * arrFeedFractions(3)) _
                     / (dblMinRec * arrFeedFractions(1) + dblMidRec *
                    arrFeedFractions(2) + dblGangRec * arrFeedFractions(3))
                     dblOvrMineralRec = (dblMinRec * arrGrades(1) * arrFeedFractions(1) + dblMidRec * arrGrades(2) * arrFeedFractions(2) + dblGangRec * arrGrades(3) * arrFeedFractions(3)) _
                     / (arrGrades(1) * arrFeedFractions(1) + arrGrades(2) * arrFeedFractions(2) + arrGrades(3) * arrFeedFractions(3))

                     Label_FeedGrade.Text = FeedGrade.TextBox_OvrFeedGrade.Text & " %"
                     Label_ProductGrade.Text = Format(dblProductGrade, "#.##") & " %"
                     Label_ProductRecovery.Text = Format(dblOvrMineralRec, "#.##") & " %"
                     Label_MineralRec.Text = Format(dblMinRec, "#.##") & " %"
                     Label_MiddlingsRec.Text = Format(dblMidRec, "#.##") & " %"
                     Label_GangueRec.Text = Format(dblGangRec, "#.##") & " %"
                     End Function
                     Public Function MainCalculation() 'used for single component feed, 100% grade 7
                     Dim dblVolBubble, dblVolParticle, dblVolBP As Double
                     Dim dblMassBubble, dblMassParticle, dblMassBP, dblMassTotal As Double
                     Dim dblCollisionDiam, dblNumAttached As Double
                     Dim dblKinVisc As Double 'kinematic viscosity
                     Dim dblBulkZone, dblImpellerZone, dblDetach_F As Double '2 compartment model
                    (Lu)
                     Dim dblVolImpZone As Double = 0.1 'set impeller zone 1 /10
                     Dim dblEMean, dblEBulk, dblEImpeller As Double 'energy dissipations
                     Dim dblU1Bulk, dblU2Bulk, dblU1Mean, dblU2Mean As Double
                     Dim dblBeta, dblNParticle, dblNBubble, dblZBubbParticle As Double


                     Dim dblWorkAdhesion, dblKineticEAttach, dblKineticEDetach As Double 8 Dim gammaMIBC, gammaPPG400, gammaOctanol, gammaPentanol As Double 9 Dim kMIBC, kPPG400, kOctanol, kPentanol As Double
                     Dim dblPAtt, dblPDet, dblPCol, dblRe As Double
                    'probabilities


                     dblBulkZone = 0.5
                     dblImpellerZone = 15
                     dblDetach_F = 1 'adjustable parameter for fitting

                     '===== Froth Parameters =====
                     Dim dblR_Entrainment, dblR_Attachment, dblFrothRecoveryFactor As Double 'entrainment and attachment recoveries
                     Dim dblB As Double = 3.3 'fitting parameter
                     Dim dblAlpha As Double = 0.01 'fitting parameter
                     Dim dblCoverage As Double = 0.5 'max particle coverage attached in froth
                     Dim dblPFTransfer, dblP_i, dblPr As Double
                     Dim dblEiw, dblEka As Double
                     Dim dblRmax As Double
                     '!! see global declarations for more froth parameters !! 6

                     '===== Get Textbox Values =====
                     dblSpPower = Val(TextBox_SpecificPower.Text) * 1000 'x1000 for w/m^3
                     dblSGasRate = Val(TextBox_SpecificAir.Text) / 100 '/100 for m/s
                     dblParticleDens = Val(TextBox_ParticleDensity.Text) * 1000 'x1000 for kg/m^3
                     dblAirFraction = Val(TextBox_AirFraction.Text)
                     dblSlurryFraction = Val(TextBox_SlurryFraction.Text)
                     dblImpellerDiam = Val(TextBox_ImpellerDiameter.Text)
                     dblContactAngle = Val(TextBox_ContactAngle.Text)
                     dblParticleZ = Val(TextBox_ParticleZ.Text)
                     dblBubbleZ = Val(TextBox_BubbleZ.Text)
                     dblCellHeight = Val(TextBox_CellHeight.Text)
                     dblCellDiam = Val(TextBox_CellDiameter.Text)
                     dblNumCells = Val(TextBox_NumCells.Text)
                     dblRetTime = Val(TextBox_RetentionTime.Text)
                     dblFrothHeight = Val(TextBox_FrothHeight.Text)
                     dblFrotherConc = Val(TextBox_FrotherConc.Text)

                     gammaMIBC = 0.000005 'mol/m^2
                     gammaPPG400 = 0.000001 'mol/m^2
                     gammaOctanol = 0.000008 'mol/m^2
                     gammaPentanol = 0.000006 'mol/m^2
                     kMIBC = 230 'M^-1
                     kPPG400 = 1700000 'M^-1
                     kOctanol = 2200 'M^-1
                     kPentanol = 55 'M^-1

                     If ComboBox_Frother.Text = "MIBC"
                     dblFrotherConc = dblFrotherConc /
                     dblSurfaceTension = 0.043 - 8.314 * (2.15 + 23) * gammaMIBC * Log
                    (kMIBC * dblFrotherConc + 1)
                     ElseIf ComboBox_Frother.Text = "PPG 400" Then
                     dblFrotherConc = dblFrotherConc / 134170 'convert ppm to mol/L
                     dblSurfaceTension = 0.043 - 8.314 * (2.15 + 23) * gammaPPG400 * Log (kPPG400 * dblFrotherConc + 1)
                     ElseIf ComboBox_Frother.Text = "Octanol" Then
                     dblFrotherConc = dblFrotherConc / 130230 'convert ppm to mol/L
                     dblSurfaceTension = 0.043 - 8.314 * (2.15 + 23) * gammaOctanol * Log
                    Then
                     'convert ppm to mol/L


                       (kOctanol * dblFrotherConc + 1)
                     ElseIf ComboBox_Frother.Text = "Pentanol" Then
                     dblFrotherConc = dblFrotherConc / 8 'convert ppm to mol/L
                     dblSurfaceTension = 0.043 - 8.314 * (2.15 + 23) * gammaPentanol * Log(kPentanol * dblFrotherConc + 1)
                     Else
                     dblSurfaceTension = 0.043 'pure water @ 23°C
                     End If
                     TextBox_SurfaceTension.Text = Format(dblSurfaceTension * 1000, "##.##") 1
                     Call CheckInputs() 'call
                     If blnCheck = False Then
                     Exit Function 'if inputs
                     End If

                     '===== BEGIN MULTIPARTICLE LOOP =====
                     dblParticleDiam = 0.000001 '(1 micron)

                     Dim i As Integer
                     Dim dblAddRec, dblAddK, dblAddPa, dblAddPc, dblAddPd, dblAddFR As Double 2
                     For i = 0 To  'particle loop


                     dblAddRec = 0
                     dblAddK = 0
                     dblAddPa = 0
                     dblAddPc = 0
                     dblAddPd = 0
                     dblAddFR = 0
                     dblR_Water_avg = 0

                     Call ContactAngleDist()

                     '===== Energy Dissipation =====

                     dblTotalDens = dblAirFraction * airDensity + _
                     (1 - dblAirFraction) * dblSlurryFraction * dblParticleDens _
                     + (1 - dblSlurryFraction) * waterDensity
                     dblEMean = dblSpPower / dblTotalDens
                     dblEBulk = dblBulkZone * dblEMean
                     dblEImpeller = dblImpellerZone * dblEMean
                     If TextBox_BubbleSize.Enabled = False Then
                     dblBubbleDiam = (2.11 * dblSurfaceTension / (waterDensity *
                    dblEImpeller ^ 0.)) ^ 0.6
                     Else
                     dblBubbleDiam = Val(TextBox_BubbleSize.Text) / 1000
                     End If

                     dblNumAttached = dblCoverage * 4 * (dblBubbleDiam / dblParticleDiam) ^ 2 'num of particles attached to one bubble


                     '===== Cell Calculations =====
                     dblCollisionDiam = (dblParticleDiam + dblBubbleDiam) 'avg diam of collision
                     dblVolParticle = (4 / 3) * pi * (dblParticleDiam / 2) ^ 3 'vol 1 part. 7 dblVolBubble = (4 / 3) * pi * (dblBubbleDiam / 2) ^ 3 'vol 1 bubb.


                     dblVolBP = dblVolBubble + dblVolParticle 'vol of 1 BP aggregate
                     dblVolCell = pi * (dblCellDiam / 2) ^ 2 * dblCellHeight 0 dblKinVisc = waterViscosity / waterDensity
                     dblMassParticle = dblParticleDens * dblVolParticle 'mass 1 part. 2 dblMassBubble = airDensity * dblVolBubble 'mass 1 bubb.
                     dblMassBP = dblMassBubble + dblMassParticle 'mass of 1 BP aggregate
                     dblMassTotal = dblVolCell * dblTotalDens 5

                     '===== Velocities by Dissipation =====
                     dblU1Bulk = (0.4 * (dblEBulk ^ (4 / 9)) * (dblParticleDiam ^ (7 / 9)) _
                     * (dblKinVisc ^ (-1 / 3)) * (dblParticleDens / _
                     waterDensity - 1) ^ (2 / 3)) ^ 2 'for attachment
                     dblU2Bulk = 2 * (dblEBulk * dblBubbleDiam) ^ (2 / 3)
                     dblU1Mean = (0.4 * (dblEMean ^ (4 / 9)) * (dblParticleDiam ^ (7 / 9)) _
                     * (dblKinVisc ^ (-1 / 3)) * (dblParticleDens / _
                     waterDensity - 1) ^ (2 / 3)) ^ 2
                     dblU2Mean = 2 * (dblEMean * dblBubbleDiam) ^ (2 / 3) 8
                     dblBeta = (2 ^ (3 / 2)) * (pi ^ 0.5) * (dblCollisionDiam ^ 2) * _
                     Sqrt(dblU1Bulk + dblU2Bulk) 'from Abrahamson model
                    using bulk dissipation

                     '===== Calc # Density of Bubbles =====
                     dblNBubble = dblAirFraction / dblVolBubble
                     dblNParticle = (1 - dblAirFraction) * dblSlurryFraction / dblVolParticle
                      dblZBubbParticle = dblBeta * dblNBubble * dblNParticle

                     dblWorkAdhesion = dblSurfaceTension * pi * (dblParticleDiam / 2) ^ 2 _
                     * (1 - Cos(dblContactAngle * (pi / 1)) ^ 2)
                    'calc work of adhesion for 1 particle

                     '===== Energy Barrier =====
                     Call EnergyBarrier() 'calls function to calc energy barrier 8
                     If dblEnergyBarrier <= 0 Then
                     dblEnergyBarrier = 0
                     End If

                     '===== Kinetic Energy of Attachment =====
                     dblKineticEAttach = 0.5 * dblMassParticle
                    2)
                     dblKineticEDetach = 0.5 * dblMassParticle
                    (dblParticleDiam _
                     + dblBubbleDiam) * Sqrt(dblEImpeller / dblKinVisc))
                    ^2

                     '===== Probabilities =====
                     dblPAtt = Exp(-dblEnergyBarrier / dblKineticEAttach) 'prob. of attachment
                     dblPDet = Exp((-dblWorkAdhesion + dblKineticEAttach) _
                     / dblKineticEDetach) 'prob. of
                    detachment
                     dblRe = Sqrt(dblU2Bulk) * dblBubbleDiam / dblKinVisc 'bubble Reynold
                    's number

                     dblPCol = Tanh(Sqrt(3 / 2 * (1 + (3 / 16 * dblRe) / (1 + 0.2 * dblRe ^ 0.56))) _
                    * dblU1Bulk / (dblDragBeta ^
                    * (dblDetach_F *


                     * (dblParticleDiam / dblBubbleDiam)) ^ 2 'prob. collision, modified Luttrell and Yoon

                     If dblPCol >= 1 Then
                     dblPCol = 1
                     End If

                     dblEiw = gravity / (4 * pi) * (dblKinVisc ^ 3 / dblEBulk) ^ 0.25
                     dblEka = (dblMassBubble * dblU2Bulk - 2 * (dblBubbleDiam /
                    dblParticleDiam) ^ 2 * dblMassParticle * dblU1Bulk) ^ 2 _
                     / (100 * (dblMassBubble + 2 * (dblBubbleDiam / dblParticleDiam) ^ 2 * dblMassParticle))

                     dblP_i = 13 * Sqrt((9 * waterViscosity ^ 2) / (dblBubbleDiam * dblSurfaceTension * dblTotalDens))
                     dblPr = Exp(-dblEiw / dblEka)
                     dblPFTransfer = dblP_i * (1 - dblPr)


                     '===== Froth Recovery =====
                     '''===start new froth rec model
                     Dim dblCoverageFactor = 2
                     Dim dblAf As Double
                     Dim dblA0 As Double
                     Dim dblCoarsenTime As Double
                     Dim dblFilmThick As Double
                     Dim dblCoalesceFactor As Double = 2
                     Dim dblL As Double

                     dblFilmThick = 3 / 4 * (0.33 / (1 - 0.33)) * dblBubbleDiam
                     dblCoarsenTime = (4 * waterViscosity * dblFrothHeight) / (waterDensity *
                    gravity * dblFilmThick ^ 2)
                     dblL = waterViscosity / (airDensity * 0.015) '2 cm/s froth velocity


                     dblA0 = (dblBubbleDiam) ^ 2

                     dblAf = (Sqrt(dblSGasRate * waterViscosity / (waterDensity * gravity)) * Tan(Atan(Sqrt(airDensity * gravity * dblA0 / (dblSGasRate * waterViscosity))) _ 0 - dblFrothHeight / 2 * Sqrt(waterDensity * gravity *
                    dblSGasRate) / dblSurfaceTension)) ^ 2

                     dblRmax = Sqrt(Exp(dblCoalesceFactor * Sqrt(dblAf / dblA0) - dblCoalesceFactor))

                     dblR_Attachment = dblRmax * Exp(-dblCoverageFactor * (6 * dblFrothHeight
                    / (dblBubbleDiam)) _
                     * (1 - dblRmax) * (dblParticleDiam / dblBubbleDiam) ^ 2)


                     dblR_Water_max = (0.33 * dblCoarsenTime * (6 * dblSGasRate) / (dblBubbleDiam / dblRmax)) * Exp(-dblFrothHeight / dblL)

                     If dblR_Water_max > 1 Then
                     dblR_Water_max = 1
                     End If

                     dblR_Entrainment = dblR_Water_max * Exp(-0.0325 * (dblParticleDens - waterDensity) - 0.063 * dblParticleDiam)


                     dblFrothRecoveryFactor = dblR_Entrainment + dblR_Attachment 7

                     '===== Rate Constant =====
                     Dim dblRecovery_ci As Double
                     Dim dblRecovery_I As Double

                     dblRateConst = dblBeta * dblNBubble * dblPAtt * dblPCol _ 4 * (1 - dblPDet) * 60 'x60 to make 1/min

                     dblRecovery_ci = 1 - (1 + dblRateConst * dblRetTime) ^ (-1) 'eq 32 (Do & Yoon)

                     dblRecovery_I = dblRecovery_ci * dblFrothRecoveryFactor / (dblRecovery_ci * _
                     dblFrothRecoveryFactor + 1 - dblRecovery_ci)
                    'eq 6.2 finch & dobby

                     dblRecovery = 1 - (1 - dblRecovery_I) ^ dblNumCells



                     '========!!!!!!!!! insert condtional code here for hydrophobic coagulation
                     'if dblParticleDiam < specified size (~ < 15 micron)
                     'then multiply by some factors or use equations
                     ' changes recovery for that size fraction

                     dblAddRec = dblRecovery
                     dblAddK = dblRateConst
                     dblAddPa = dblPAtt
                     dblAddPc = dblPCol
                     dblAddPd = dblPDet
                     dblAddFR = dblFrothRecoveryFactor 9 dblR_Water_avg = dblR_Water_max 9

                     '===== Output Results =====

                     arrRecovery(i) = dblAddRec * 100 '100 for percent
                     arrPDiam(i) = dblParticleDiam * 1000000 '10^6 for microns
                     arrRateK(i) = dblAddK * dblAddFR
                     arrPa(i) = dblAddPa * 100
                     arrPc(i) = dblAddPc * 100
                     arrPd(i) = (1 - dblAddPd) * 100
                     arrFR(i) = dblAddFR * 100

                     dblParticleDiam = dblParticleDiam * 1.2 'increment particle diam 9
                     Next i



                     '===== Graphs =====
                     ChartK.Series.Add(ri)
                     ChartK.Series(ri).ChartType = SeriesChartType.Line
                     Chart_Rec2.Series.Add(ri)
                     Chart_Rec2.Series(ri).ChartType = SeriesChartType.Line
                     Chart_RecLinear.Series.Add(ri)
                     Chart_RecLinear.Series(ri).ChartType = SeriesChartType.Line
                     Chart_Pa.Series.Add(ri)
                     Chart_Pa.Series(ri).ChartType = SeriesChartType.Line


                     Chart_Pc.Series.Add(ri)
                     Chart_Pc.Series(ri).ChartType = SeriesChartType.Line 9 Chart_Pd.Series.Add(ri)
                     Chart_Pd.Series(ri).ChartType = SeriesChartType.Line 9 Chart_FRec.Series.Add(ri)
                     Chart_FRec.Series(ri).ChartType = SeriesChartType.Line 9 Chart_Grade.Series.Add(ri)
                     Chart_Grade.Series(ri).ChartType = SeriesChartType.Line 1000
                     Dim n As Integer
                     For n = 0 To
                     ChartK.Series(ri).Points.AddXY(arrPDiam(n), arrRateK(n))
                     Chart_Rec2.Series(ri).Points.AddXY(arrPDiam(n), arrRecovery(n))
                     Chart_RecLinear.Series(ri).Points.AddXY(arrPDiam(n), arrRecovery(n))
                     Chart_Pa.Series(ri).Points.AddXY(arrPDiam(n), arrPa(n))
                     Chart_Pc.Series(ri).Points.AddXY(arrPDiam(n), arrPc(n))
                     Chart_Pd.Series(ri).Points.AddXY(arrPDiam(n), arrPd(n))
                     Chart_FRec.Series(ri).Points.AddXY(arrPDiam(n), arrFR(n))
                     Next

                     Call

                     ri =

                     Call SizeDistribution()


                     '===== Temp Outputs for Debugging =====
                     'MsgBox("Some Outputs Temporary for Debugging")
                     If dblOvrRecovery > 0 Then
                     Label_RecoveryOutput.Text = Format(dblOvrRecovery, "#.###") 3 End If

                     label_VolCellOutput.Text = Format(dblVolCell, "#.###") & " m3"
                     label_WaterRecOut.Text = Format(dblR_Water_avg * 100, "#.###") & " %"


                     End Function
                     Public Function SizeDistribution()
                     Dim s15, s425, s250, s1, s150, s106, s, s45, s, s25 As Double
                    'txtbx valu
                     Dim f15, f425, f250, f1, f150, f106, f, f45, f, f25 As Double 'fraction
                     Dim r15, r425, r250, r1, r150, r106, r, r45, r, r25 As Double 'recovery

                     s425
                     s250
                     s1
                     s150
                     s106
                     s = Val(SizeDist.TextBox_.Text)
                     s45 = Val(SizeDist.TextBox_45.Text)
                     s = Val(SizeDist.TextBox_.Text)
                     s25 = Val(SizeDist.TextBox_25.Text)
                     s15 = Val(SizeDist.TextBox_15.Text)

                     f425 = s425 - s250
                     f250 = s250 - s1
                     f1 = s1 - s150
                    AddToolTip() 'adds info to the graphs
                    ri + 1 'increment series number and color
                    = Val(SizeDist.TextBox_425.Text) = Val(SizeDist.TextBox_250.Text) = Val(SizeDist.TextBox_1.Text) = Val(SizeDist.TextBox_150.Text) = Val(SizeDist.TextBox_106.Text)


                    f150 = s150 - s106
                    f106 = s106 - s
                     f = s - s45
                    f45 = s45 - s
                     f = s - s25
                     f25 = s25 - s15
                     f15 = s15

                    r15 = arrRecovery(15) / 100
                    r25 = arrRecovery(18) / 100
                    r = arrRecovery(20) / 100
                    r45 = arrRecovery(21) / 100
                    r = (arrRecovery(23) + arrRecovery(24)) / 2 / 100
                     r106 = (arrRecovery(25) + arrRecovery(26)) / 2 / 100
                     r150 = (arrRecovery(27) + arrRecovery(28)) / 2 / 100
                     r1 = (arrRecovery(28) + arrRecovery(29)) / 2 / 100
                     r250 = (arrRecovery(30) + arrRecovery(31)) / 2 / 100
                     r425 = arrRecovery(33) / 100


                     dblOvrRecovery = f15 * r15 + f25 * r25 + f * r +
                    f106 * r106 _
                     + f150 * r150 + f1 * r1 + f250 * r250 + f425 * r425

                     End Function


                     'save button also writes to file
                     Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e
                    As System.EventArgs) Handles SaveToolStripMenuItem.Click

                     Dim saveFileDialog1 As New SaveFileDialog()

                     saveFileDialog1.Filter = "Text File (.txt)|*.txt|Word Document (.doc)|*.doc| Word 07 Document (.docx)|*.docx" 'these are the file type options shown in the dialog
                     saveFileDialog1.Title = "Save File"
                     saveFileDialog1.ShowDialog() ' If the file name is not an empty string open it for saving

                     If saveFileDialog1.FileName <> "" Then

                     Dim fs As System.IO.FileStream = CType _
                     (saveFileDialog1.OpenFile(), System.IO.FileStream) ' Saves file as
                    type selected in the dialog box via FileStream created by OpenFile method. 10 fs.Close() 'closes the text file

                     Dim fName As System.IO.StreamWriter
                     fName = My.Computer.FileSystem.OpenTextFileWriter(fs.Name, True)
                    'prepares to write to "fs" which was just created by the user 10
                     fName.WriteLine("Inputs") 'writes to the file
                     fName.WriteLine("----------------")
                     fName.WriteLine(" Specific Power = " & dblSpPower)
                     fName.WriteLine(" Gas Rate = " & dblSGasRate)
                     fName.WriteLine(" Particle S.G. = " & dblParticleDens / 1000) 'divide
                     get get back into SG
                     fName.WriteLine(" Air Fraction = " & dblAirFraction)
                     fName.WriteLine(" Slurry Fraction = " & dblSlurryFraction)
                    f45 * r45 + f * r +


                     'fName.WriteLine(" Feed Grade = " & dblgrade?) 01 fName.WriteLine()
                     fName.WriteLine("
                     fName.WriteLine("
                     fName.WriteLine("
                     fName.WriteLine("Particle Zeta Potential = " & dblParticleZ)
                    Surface Tension = " & dblSurfaceTension) Contact Angle = " & dblContactAngle) Dielectric Constant = " & dblDielectric)
                     fName.WriteLine("
                     fName.WriteLine("
                     fName.WriteLine()
                     fName.WriteLine("
                     fName.WriteLine("
                     fName.WriteLine("Impeller Diameter = " & dblImpellerDiam)  fName.WriteLine("Number of Cells = " & dblNumCells)
                     fName.WriteLine(" Retention Time = " & dblRetTime)
                     fName.WriteLine(" Froth Height = " & dblFrothHeight)
                     fName.WriteLine(" Growth Factor = " & dblGrowthFactor)
                     fName.WriteLine("Max. Water Rec. = " & dblR_Water_max)
                     fName.WriteLine()
                     fName.WriteLine()
                     fName.WriteLine("Outputs")
                     fName.WriteLine("----------------")
                     fName.WriteLine("Cell Volume = " & Format(dblVolCell, "#.####"))
                     fName.WriteLine("Recovery = " & Format(dblOvrRecovery, "#.####"))
                     fName.WriteLine()
                     fName.WriteLine()
                     fName.WriteLine()
                     fName.WriteLine("SimuFloat " & Now) 'adds the date and time at the
                    bottom

                     fName.Close() 'closes the text file

                     End If

                     End Sub
                     Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e
                    As System.EventArgs) Handles AboutToolStripMenuItem.Click
                     AboutBox1.ShowDialog() 'shows the about box
                     End Sub
                     Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e
                    As System.EventArgs) Handles ExitToolStripMenuItem.Click
                     Me.Close() 'closes the form
                     End Sub
                     Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e
                    As System.EventArgs) Handles HelpToolStripMenuItem.Click
                     Help1.ShowDialog() 'shows the help box
                     End Sub
                     'Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e
                    As System.EventArgs) Handles PrintToolStripMenuItem.Click
                     ' Dim printDialog1 As New PrintDialog()

                     ' printDialog1.ShowDialog()
                     'End Sub


                     'enable text input via checkboxes
                     Private Sub CheckBox_AirFrac_CheckedChanged(ByVal sender As System.Object,
                    Bubble Zeta Potential = " & dblBubbleZ)
                    Permitivity = " & dblPermitivity)
                    Cell Diameter = " & dblCellDiam)
                    Cell Height = " & dblCellHeight)


                       ByVal
                    e As



                     Else
                     TextBox_AirFraction.Enabled = False  End If
                    System.EventArgs) Handles CheckBox_AirFrac.CheckedChanged If TextBox_AirFraction.Enabled = False Then
                    TextBox_AirFraction.Enabled = True

                     End Sub
                     Private Sub CheckBox_BubbleSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox_BubbleSize.CheckedChanged
                     If TextBox_BubbleSize.Enabled = False Then
                     TextBox_BubbleSize.Enabled = True
                     Else
                     TextBox_BubbleSize.Enabled = False
                     End If
                     End Sub
                     Private Sub CheckBox_BubbleZeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox_BubbleZeta.CheckedChanged
                     If TextBox_BubbleZ.Enabled = False Then
                     TextBox_BubbleZ.Enabled = True
                     Else
                     TextBox_BubbleZ.Enabled = False
                     End If
                     End Sub
                     Private Sub CheckBox_ContactDistrib_CheckedChanged(ByVal sender As System.Object
                    , ByVal e As System.EventArgs) Handles CheckBox_ContactDistrib.CheckedChanged
                     CheckBox_FeedGrade.Checked = False

                     If Button_ContactDistrib.Enabled = False Then
                     Button_ContactDistrib.Enabled = True
                     Else
                     Button_ContactDistrib.Enabled = False  End If
                     If TextBox_ContactAngle.Enabled = False Then
                     TextBox_ContactAngle.Enabled = True
                     Else
                     TextBox_ContactAngle.Enabled = False
                     End If
                     End Sub
                     Private Sub CheckBox_DielectricConst_CheckedChanged(ByVal sender As System. Object, ByVal e As System.EventArgs) Handles CheckBox_DielectricConst. CheckedChanged
                     If TextBox_DielectricConst.Enabled = False Then
                     TextBox_DielectricConst.Enabled = True
                     Else
                     TextBox_DielectricConst.Enabled = False
                     End If
                     End Sub
                     Private Sub CheckBox_FeedGrade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox_FeedGrade.CheckedChanged
                     CheckBox_ContactDistrib.Checked = False

                     If Button_FeedGrade.Enabled = False Then
                     Button_FeedGrade.Enabled = True
                     Else
                     Button_FeedGrade.Enabled = False 01 End If



                     If TextBox_ParticleDensity.Enabled = False Then
                     TextBox_ParticleDensity.Enabled = True
                     Else
                     TextBox_ParticleDensity.Enabled = False 07 End If

                     If TextBox_ContactAngle.Enabled = False Then
                     TextBox_ContactAngle.Enabled = True
                     Else
                     TextBox_ContactAngle.Enabled = False
                     End If
                     End Sub
                     Private Sub CheckBox_SlurryFrac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox_SlurryFrac.CheckedChanged
                     If TextBox_SlurryFraction.Enabled = False Then
                     TextBox_SlurryFraction.Enabled = True
                     Else
                     TextBox_SlurryFraction.Enabled = False
                     End If
                     End Sub
                     Private Sub CheckBox_Permitivity_CheckedChanged(ByVal sender As System.Object,
                    ByVal e As System.EventArgs) Handles CheckBox_Permitivity.CheckedChanged
                     If TextBox_Permitivity.Enabled = False Then
                     TextBox_Permitivity.Enabled = True
                     Else
                     TextBox_Permitivity.Enabled = False 27 End If
                     End Sub


                     'Keypress subs for disallowing letters in textboxes
                     'Allows 034589 - . backspace delete
                     Private Sub TextBox_BubbleZeta_KeyPress(ByVal sender As Object, ByVal e As
                    System.Windows.Forms.KeyPressEventArgs) Handles TextBox_BubbleZ.KeyPress
                     Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If
                     End Sub
                     Private Sub TextBox_ContactAngle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_ContactAngle.KeyPress 42 Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If
                     End Sub
                     Private Sub TextBox_NumCell_KeyPress(ByVal sender As Object, ByVal e As System.
                    Windows.Forms.KeyPressEventArgs) Handles TextBox_NumCells.KeyPress
                     Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True


                        End If
                     End Sub
                     Private Sub TextBox_RetTime_KeyPress(ByVal sender As Object, ByVal e As System.
                    Windows.Forms.KeyPressEventArgs) Handles TextBox_RetentionTime.KeyPress
                     Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If
                     End Sub
                     Private Sub TextBox_SG_KeyPress(ByVal sender As Object, ByVal e As System. Windows.Forms.KeyPressEventArgs) Handles TextBox_ParticleDensity.KeyPress
                     Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If
                     End Sub
                     Private Sub TextBox_SpecificAir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_SpecificAir.KeyPress
                     Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If
                     End Sub
                     Private Sub TextBox_SpecificPower_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_SpecificPower.KeyPress
                     Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If

                     End Sub
                     Private Sub TextBox_SurfaceTension_KeyPress(ByVal sender As Object, ByVal e As
                    System.Windows.Forms.KeyPressEventArgs) Handles TextBox_SurfaceTension.KeyPress  Dim allowedChars As String = "034589.-" & Chr(8) & Chr(7)

                     If allowedChars.IndexOf(e.KeyChar) = -1 Then
                     ' Invalid Character
                     e.Handled = True
                     End If
                     End Sub

                     'subs for adding tooltips to labels
                     Private Sub Label_FrotherConc_MouseHover(ByVal sender As Object, ByVal e As
                    System.EventArgs) Handles Label_FrotherConc.MouseHover 1302 Dim ttfc As New ToolTip()

                     ttfc.AutoPopDelay = 5000
                     ttfc.InitialDelay = 500
                     ttfc.ReshowDelay = 500

                     ttfc.ShowAlways = True
                     ttfc.SetToolTip(Me.Label_FrotherConc, "Milligrams of frother added per liter of slurry")

                     End Sub
                     Private Sub Label_CellNum_MouseHover(ByVal sender As Object, ByVal e As System.
                    EventArgs) Handles Label_CellNum.MouseHover
                     Dim ttfc As New ToolTip()

                     ttfc.AutoPopDelay = 5000
                     ttfc.InitialDelay = 500
                     ttfc.ReshowDelay = 500
                     ttfc.ShowAlways = True
                     ttfc.SetToolTip(Me.Label_CellNum, "Number of identical cells in the flotation bank")
                     End Sub
                     Private Sub Label_Bub_MouseHover(ByVal sender As Object, ByVal e As System. EventArgs) Handles Label_Bub.MouseHover
                     Dim ttfc As New ToolTip()

                     ttfc.AutoPopDelay = 5000
                     ttfc.InitialDelay = 500
                     ttfc.ReshowDelay = 500
                     ttfc.ShowAlways = True
                     ttfc.SetToolTip(Me.Label_Bub, "Enter bubble size if known, SimuFloat will calculate otherwise")
                     End Sub
                     Private Sub Label_ContactDist_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ConDist.MouseHover
                     Dim ttfc As New ToolTip()

                     ttfc.AutoPopDelay = 5000
                     ttfc.InitialDelay = 500
                     ttfc.ReshowDelay = 500
                     ttfc.ShowAlways = True
                     ttfc.SetToolTip(Me.Label_ConDist, "Enable this function to use a distribution of contact angles for a single component feed")
                     End Sub
                     Private Sub Label_FGrade_MouseHover(ByVal sender As Object, ByVal e As System.
                    EventArgs) Handles Label_FGrade.MouseHover
                     Dim ttfc As New ToolTip()

                     ttfc.AutoPopDelay = 5000
                     ttfc.InitialDelay = 500
                     ttfc.ReshowDelay = 500
                     ttfc.ShowAlways = True
                     ttfc.SetToolTip(Me.Label_FGrade, "Enable this function to input parameters for a multi-component feed")
                     End Sub

                     End Class

} */
