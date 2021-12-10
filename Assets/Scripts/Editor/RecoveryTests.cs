using NUnit.Framework;
using UnityEngine;

public class RecoveryTests
{
  [Test]
    public void SingleRecoveryCalculationMediumSizeParticleTest()
    {
        RecoveryCalculation R = new RecoveryExamples().CalculationExample();        
        double Actual = R.arrRecovery[81];

//        double Actual = R.CalculateRecoveryForParticleDiameter(0.000071);
        double Expected = 60;
        Assert.AreEqual(Expected, Actual,20);
    }

    [Test]
    public void SingleRecoveryCalculationSmallSizeParticleTest()
    {
        RecoveryCalculation R = new RecoveryExamples().CalculationExample();
        double Actual = R.arrRecovery[10];
        //double Actual = R.CalculateRecoveryForParticleDiameter(0.00001);
        double Expected = 10;
        Assert.AreEqual(Expected, Actual, 20);
    }

    [Test]
    public void SingleRecoveryCalculationForBigSizeParticleTest()
    {
        RecoveryCalculation R = new RecoveryExamples().CalculationExample();
        double Actual = R.arrRecovery[100];
        //double Actual = R.CalculateRecoveryForParticleDiameter(0.000100);
        double Expected = 16;
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
        Recoveries.BubbleDiameterGiven = false;
        double Actual = Recoveries.BubbleDiameterInMeters();
        Assert.LessOrEqual(Actual, 0.005);
    }


    [Test]
    public void FrothHeightAffectsRecovery()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.FrothHeight = 0.1;
        double Froth1 = Recoveries.arrRecovery[70];
        Assert.AreEqual(90, Froth1, 10);
        Recoveries.FrothHeight = 0.2;
        Recoveries.CalculateParticleRecoveries();
        double Froth2 = Recoveries.arrRecovery[70]; ;
        Assert.AreEqual(50, Froth2, 10);
    }

    [Test]
    public void AirFlowAffectsRecovery()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.AirFlowRate = 2;
        double Air1 = Recoveries.arrRecovery[70];
        Assert.AreEqual(86, Air1, 3);
        Recoveries.AirFlowRate = 4;
        Recoveries.CalculateParticleRecoveries();
        double Air2 = Recoveries.arrRecovery[70]; ;
        Assert.AreEqual(95, Air2, 3);
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
