using NUnit.Framework;

public class RecoveryTests
{
    
    [Test]
    public void MeanSquaredErrorTest()
    {
        double AcceptableMSE = 5;
        RecoveryExamples R = new RecoveryExamples();
        double[] Expected = R.RealLifeRecoveries();
        double[] Actual = R.SimulatedRecoveries();
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
    public void NumberOfRecoveriesHaveSameNumber()
    {
        RecoveryExamples R = new RecoveryExamples();
        int Expected = R.RealLifeRecoveries().Length;
        int Actual = R.SimulatedRecoveries().Length;
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
