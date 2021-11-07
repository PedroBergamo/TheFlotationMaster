﻿using System;
public class SurfaceTension
{

    // Some of the values below are different from the pdf (I tried with the 'real' values but it might get worse..)
    public SurfaceTension() { }

    public Reagent PureWater = new Reagent(0, 0, 1); //23°C                   
    public Reagent MIBC = new Reagent(0.000005, 230, 1);
    public Reagent PPG400 = new Reagent(0.000001, 1700000, 134170);
    public Reagent Octanol = new Reagent(0.000008, 2200, 130230);
    public Reagent Pentanol = new Reagent(0.000006, 55, 8);
    public Reagent ChosenReagent;
    public double FrotherConcentrate; //mg/m3

    public double CalculateSurfaceTension()
    {
        double FrotherConc = FrotherConcentrate / ChosenReagent.Conversor;
        double ReagentFactor = 8.314 * (2.15 + 23) * ChosenReagent.Gamma *
                Math.Log(ChosenReagent.K * FrotherConc + 1);
        double SurfaceTension = 0.043 - ReagentFactor;
        return SurfaceTension * 1000;
    }


    //public Reagent PureWater = new Reagent(0, 0, 1); //23°C                   
    //public Reagent MIBC = new Reagent(0.000005, 230, 102170);
    //public Reagent PPG400 = new Reagent(0.000001, 1700000, 134170);
    //public Reagent Octanol = new Reagent(0.000008, 2200, 130230);
    //public Reagent Pentanol = new Reagent(0.000006, 55, 88150);
    //public Reagent ChosenReagent;
    //public double FrotherConcentrate; //mg/m3

    //public double CalculateSurfaceTension()
    //{
    //    double FrotherConc = FrotherConcentrate / ChosenReagent.Conversor;
    //    double ReagentFactor = 8.314 * (273.15 + 23) * ChosenReagent.Gamma *
    //            Math.Log(ChosenReagent.K * FrotherConc + 1);
    //    double SurfaceTension = 0.07243 - ReagentFactor;
    //    return SurfaceTension * 1000;
    //}
}