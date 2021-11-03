using NUnit.Framework;
using Assets.Scripts.Controllers;

public class RecoveryTests
{
    
    [Test]
    public void MeanSquaredErrorTest()
    {
        double AcceptableMSE = 2;
        RecoveryExamples R = new RecoveryExamples();
        double[] Expected = R.RealLifeRecoveries();
        double[] Actual = R.CalculationExample().CalculateParticleRecoveries();
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
            Assert.LessOrEqual(RealMSE, AcceptableMSE);
    }

    [Test]
    public void SingleRecoveryCalculationTest()
    {
        double Actual = new RecoveryExamples().CalculationExample().CalculateRecoveryForParticleDiameter(0.000071);
        double Expected = 60;
        Assert.AreEqual(Expected, Actual);
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
