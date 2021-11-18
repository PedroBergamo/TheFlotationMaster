using NUnit.Framework;
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
        int i = 0;
        double Sum = 0;
        foreach (double Example in SimulatedData)
        {
            double value = (Example - Expected[i]);
            value *= value;
            i++;
            Sum += value;
        }
        double RealMSE = Sum / SimulatedData.Length;
        Assert.AreEqual(SimulatedData.Length, Expected.Length);
        Assert.LessOrEqual(RealMSE, AcceptableMSE);
    }

    [Test]
    public void SingleRecoveryCalculationTest()
    {
        RecoveryCalculation R = new RecoveryExamples().CalculationExample();
        R.SetUpCalculation();
        double Actual = R.CalculateRecoveryForParticleDiameter(0.000071);
        double Expected = 60;
        Assert.AreEqual(Expected, Actual,20);
    }

    [Test]
    public void SingleRecoveryCalculationForBigParticleTest()
    {
        RecoveryCalculation R = new RecoveryExamples().CalculationExample();
        R.SetUpCalculation();
        double Actual = R.CalculateRecoveryForParticleDiameter(0.000101);
        double Expected = 20;
        Assert.AreEqual(Expected, Actual, 20);
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
        Recoveries.BubbleDiameterGiven = false;
        double Actual = Recoveries.BubbleDiameterInMeters();
        Assert.LessOrEqual(Actual, 0.005);
    }

    [Test]
    public void AirFlowRateAffectsRecovery()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        double[] data1 = Recoveries.arrRecovery;
        Recoveries.AirFlowRate = 4;
        Recoveries.CalculateParticleRecoveries();
        double[] data2 = Recoveries.arrRecovery;
        Assert.AreNotEqual(data1,data2);
    }

    [Test]
    public void FrothHeightAffectsRecovery()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        double[] data1 = Recoveries.arrRecovery;
        Recoveries.FrothHeight = 20;
        Recoveries.CalculateParticleRecoveries();
        double[] data2 = Recoveries.arrRecovery;
        Assert.AreNotEqual(data1, data2);
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
