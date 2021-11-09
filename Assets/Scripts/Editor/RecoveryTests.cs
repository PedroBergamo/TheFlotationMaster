﻿using NUnit.Framework;
using UnityEngine;

public class RecoveryTests
{
    
    [Test]
    public void MeanSquaredErrorTest()
    {
        double AcceptableMSE = 100;
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        double[] SimulatedData = Recoveries.arrRecovery;
        double[] Expected = new RecoveryExamples().ExpectedRecoveries();
        double[] Actual = Recoveries.CalculationExample().arrRecovery;
        int i = 0;
        double Sum = 0;
        foreach (double Example in Actual)
        {
            double value = (Example - Expected[i]);
            value *= value;
            i++;
            Sum += value;
        }
        double RealMSE = Sum / Actual.Length;
        Assert.AreEqual(Actual.Length, Expected.Length);
        Assert.LessOrEqual(RealMSE, AcceptableMSE);
    }

    [Test]
    public void SingleRecoveryCalculationTest()
    {
        RecoveryCalculation R = new RecoveryExamples();
        R.SetUpCalculation();
        double Actual = R.CalculateRecoveryForParticleDiameter(0.000071);
        double Expected = 60;
        Assert.AreEqual(Expected, Actual);
    }

    [Test]
    public void BubbleSizeConvesionToMicrometers()
    {
        RecoveryCalculation R = new RecoveryExamples().CalculationExample();
        R.BubbleDiameterGiven = true;
        R.BubbleDiameter = 1;
        double Actual = R.BubbleDiameterInMeters();
        Assert.LessOrEqual(Actual, 0.0051);
    }

    [Test]
    public void BubbleDiameterHasReasonableSize()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        double[] SimulatedData = Recoveries.arrRecovery;
        R.BubbleDiameterGiven = false;
        double Actual = R.BubbleDiameterInMeters();
        Assert.Greater(Actual, 5000000000000001);
    }

    [Test]
    public void SurfaceTensionWater()
    {
        SurfaceTension SF = new SurfaceTension();
        SF.FrotherConcentrate = 192; //as seen in example of didactic/Kyle2011.pdf
        SF.ChosenReagent = SF.PureWater;
        double Actual = SF.CalculateSurfaceTension();
        double Expected = 43;
        Assert.AreEqual(Expected, Actual,1);
    }

    [Test]
    public void EnergyBarrierIsNonNull()
    {
        double Energy = new RecoveryExamples().CalculationExample().EnergyBarrier();
        Assert.GreaterOrEqual(Energy, 0);
    }

    [Test]
    public void SurfaceTensionOctanol()
    {
        SurfaceTension SF = new SurfaceTension();
        SF.FrotherConcentrate = 192; //as seen in example of didactic/Kyle2011.pdf
        SF.ChosenReagent = SF.Octanol;
        double Actual = SF.CalculateSurfaceTension();
        double Expected = 40.5;
        Assert.AreEqual(Expected, Actual,1);
    }

    [Test]
    public void SurfaceTensionsForDifferentReagents()
    {
        SurfaceTension SF = new SurfaceTension();
        SF.FrotherConcentrate = 192; //as seen in example of didactic/Kyle2011.pdf
        SF.ChosenReagent = SF.Octanol;
        double R1 = SF.CalculateSurfaceTension();
        SF.ChosenReagent = SF.MIBC;
        double R2 = SF.CalculateSurfaceTension();
        Assert.AreNotEqual(R1, R2);
    }
}
