
/*
public class CheckInputs{



 public object CheckInputs()
    {
        blnCheck = false;

        // ===== Check for all Inputs, then Output =====
        if (TextBox_SpecificPower.Text == "")
        {
            MsgBox("Please enter a value for Specific Power");
        }
        else if (TextBox_SpecificAir.Text == "")
        {
            MsgBox("Please enter a value for Superficial Gas Rate");
        }
        else if (TextBox_AirFraction.Text == "")
        {
            MsgBox("Please enter a value for Air Fraction");
        }
        else if (Val(TextBox_AirFraction.Text) > 0.6d)
        {
            MsgBox("Slurry Air cannot be greater than 0.6");
        }
        else if (TextBox_SlurryFraction.Text == "")
        {
            MsgBox("Please enter a value for Slurry Fraction");
        }
        else if (Val(TextBox_SlurryFraction.Text) > 0.5d)
        {
            MsgBox("Slurry Fraction cannot be greater than 0.5");
        }
        else if (TextBox_FrotherConc.Text == "" & ComboBox_Frother.Text != "")
        {
            MsgBox("Please enter a value for Frother Concentration");
        }
        else if (TextBox_DielectricConst.Text == "")
        {
            MsgBox("Please enter a value for Dielectric Constant");
        }
        else if (TextBox_BubbleZ.Text == "")
        {
            MsgBox("Please enter a value for Bubble Zeta Potential");
        }
        else if (TextBox_ParticleZ.Text == "")
        {
            MsgBox("Please enter a value for Particle Zeta Potential");
        }
        else if (TextBox_Permitivity.Text == "")
        {
            MsgBox("Please enter a value for Permitivity");
        }
        else if (TextBox_CellHeight.Text == "")
        {
            MsgBox("Please enter a value for Cell Height");
        }
        else if (TextBox_CellDiameter.Text == "")
        {
            MsgBox("Please enter a value for Cell Diameter");
        }
        else if (TextBox_NumCells.Text == "")
        {
            MsgBox("Please enter a value for Number of Cells");
        }
        else if (TextBox_RetentionTime.Text == "")
        {
            MsgBox("Please enter a value for Retention Time");
        }
        else if (TextBox_FrothHeight.Text == "")
        {
            MsgBox("Please enter a value for Froth Height");
        }
        else if (Button_FeedGrade.Enabled == false) // if using feedgrade dont
        {
            need(following);
            if (TextBox_ParticleDensity.Text == "")
            {
                MsgBox("Please enter a value for Particle Specific Gravity");
            }
            else if (TextBox_ContactAngle.Text == "")
            {
                MsgBox("Please enter a value for Contact Angle");
            }
            else if (Val(TextBox_ContactAngle.Text) > 88.7d)
            {
                MsgBox("Contact Angle must be 88.7 or less"); // cant have negative cosine
            }
            else if (Val(TextBox_ParticleDensity.Text) <= 1)
            {
                MsgBox("Particle Specific Gravity Must be Greater than 1"); // SG must be greater than 1 otherwise it floats itself
            }
            else
            {
                blnCheck = true;
            }
        }
        else if (Button_FeedGrade.Enabled == true)
        {
            if (FeedGrade.TextBox_MineralDensity.Text == "")
            {
                MsgBox("Please enter a value for Mineral Specific Gravity");
            }
            else if (FeedGrade.TextBox_MiddlingsDensity.Text == "")
            {
                MsgBox("Please enter a value for Middlings Specific Gravity");
            }
            else if (FeedGrade.TextBox_GangueDensity.Text == "")
            {
                MsgBox("Please enter a value for Gangue Specific Gravity");
            }
            else if (FeedGrade.TextBox_MineralContactAngle.Text == "")
            {
                MsgBox("Please enter a value for Mineral Contact Angle");
            }
            else if (FeedGrade.TextBox_MiddlingsContactAngle.Text == "")
            {
                MsgBox("Please enter a value for Middlings Contact Angle");
            }
            else if (FeedGrade.TextBox_GangueContactAngle.Text == "")
            {
                MsgBox("Please enter a value for Gangue Contact Angle");
            }
            else if (Val(FeedGrade.TextBox_MineralContactAngle.Text) >= 90) /* TODO ERROR: Skipped SkippedTokensTrivia
 TODO ERROR: Skipped SkippedTokensTrivia
MsgBox("Contact Angle must be less than 90") // cant have negative cosine
            {
            }
            else if (Val(FeedGrade.TextBox_MineralDensity.Text) <= 1)
            {
                MsgBox("Ore Specific Gravity Must be Greater than 1"); // SG must be greater than 1 otherwise it floats itself
            }
            else
            {
                blnCheck = true;
            }
        }

        return default;
    }
}


 // ===== Graphs =====
        ChartK.Series.Add(ri);
        ChartK.Series(ri).ChartType = SeriesChartType.Line;
        Chart_Rec2.Series.Add(ri);
        Chart_Rec2.Series(ri).ChartType = SeriesChartType.Line;
        Chart_RecLinear.Series.Add(ri);
        Chart_RecLinear.Series(ri).ChartType = SeriesChartType.Line;
        Chart_Pa.Series.Add(ri);
        Chart_Pa.Series(ri).ChartType = SeriesChartType.Line;
    5 
Chart_Pc.Series.Add(ri) 
    Chart_Pc.Series(ri).ChartType = SeriesChartType.Line;

Chart_Pd.Series.Add(ri) 
    Chart_Pd.Series(ri).ChartType = SeriesChartType.Line;

Chart_FRec.Series.Add(ri) 
    Chart_FRec.Series(ri).ChartType = SeriesChartType.Line;
Chart_Grade.Series.Add(ri);
Chart_Grade.Series(ri).ChartType = SeriesChartType.Line;
int n;
var loopTo1 = ;
for (n = 0; n <= loopTo1; n++)
{
    ChartK.Series(ri).Points.AddXY(arrPDiam[n], arrRateK[n]);
    Chart_Rec2.Series(ri).Points.AddXY(arrPDiam[n], arrRecovery[n]);
    Chart_RecLinear.Series(ri).Points.AddXY(arrPDiam[n], arrRecovery[n]);
    Chart_Pa.Series(ri).Points.AddXY(arrPDiam[n], arrPa[n]);
    Chart_Pc.Series(ri).Points.AddXY(arrPDiam[n], arrPc[n]);
    Chart_Pd.Series(ri).Points.AddXY(arrPDiam[n], arrPd[n]);
    Chart_FRec.Series(ri).Points.AddXY(arrPDiam[n], arrFR[n]);
}

        ();
ri = ;
SizeDistribution();
dblFGRecovery = dblFGRecovery + dblOvrRecovery * arrFeedFractions(x) / 100;
if (x == 1)
{
    dblMinRec = dblOvrRecovery;
    5:
            ;
    6:
            ;
    AddToolTip(); // adds info to the graphs
    ri[+1];
}
else
{
    dblGangRec = dblOvrRecovery;
};


// '==== plot grade v pdiam ====
int m;
var loopTo2 = ;
for (m = 0; m <= loopTo2; m++)
{
    arrSizeGrade[m] = (arrGrMineral[m] * arrFeedFractions[1] + arrGrMiddling[m] * arrFeedFractions[2] * 0.5d) / (arrGrMineral[m] * arrFeedFractions[1] + arrGrMiddling);
    ;

    /* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 14966


    Input:
                            (m) * arrFeedFractions(2) + _
                             arrGrGangue(m) * arrFeedFractions(3)) * 100
     
    Chart_Grade.Series(ri - 1).Points.AddXY(arrPDiam[m], arrSizeGrade[m]);
}


// ===== Temp Outputs for Debugging =====
// MsgBox("Some Outputs Temporary for Debugging")
if (dblOvrRecovery > 0)
{
    Label_RecoveryOutput.Text = Strings.Format(dblFGRecovery, "#.###" + " %");
    9 
    End If 
            label_VolCellOutput.Text = Strings.Format(dblVolCell, "#.###") + " m3";
    label_WaterRecOut.Text = Strings.Format(dblR_Water_avg * 100, "#.###") + " %";
    double dblProductGrade, dblOvrMineralRec;
    dblProductGrade = (dblMinRec * arrGrades[1] * arrFeedFractions[1] + dblMidRec * arrGrades[2] * arrFeedFractions[2] + dblGangRec * arrGrades[3] * arrFeedFractions[3]) / (dblMinRec * arrFeedFractions[1] + dblMidRec * arrFeedFractions[2] + dblGangRec * arrFeedFractions[3]);
    dblOvrMineralRec = (dblMinRec * arrGrades[1] * arrFeedFractions[1] + dblMidRec * arrGrades[2] * arrFeedFractions[2] + dblGangRec * arrGrades[3] * arrFeedFractions[3]) / (arrGrades[1] * arrFeedFractions[1] + arrGrades[2] * arrFeedFractions[2] + arrGrades[3] * arrFeedFractions[3]);
    Label_FeedGrade.Text = FeedGrade.TextBox_OvrFeedGrade.Text + " %";
    Label_ProductGrade.Text = Strings.Format((object)dblProductGrade, "#.##") + " %";
    Label_ProductRecovery.Text = Strings.Format((object)dblOvrMineralRec, "#.##") + " %";
    Label_MineralRec.Text = Strings.Format(dblMinRec, "#.##") + " %";
    Label_MiddlingsRec.Text = Strings.Format(dblMidRec, "#.##") + " %";
    Label_GangueRec.Text = Strings.Format(dblGangRec, "#.##") + " %";
    ;
#error Cannot convert EndBlockStatementSyntax - see comment for details
    /* Cannot convert EndBlockStatementSyntax, CONVERSION ERROR: Conversion for EndFunctionStatement not implemented, please report this issue in 'End Function' at character 17116


    Input:
                             End Function

     
}
    }



*/