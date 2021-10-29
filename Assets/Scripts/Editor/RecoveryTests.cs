using NUnit.Framework;
using Assets.Scripts.Controllers;
using UnityEngine;

public class RecoveryTests {

    private double[] RealLifeMockup() {
        // five points from real data: 50, 59, 47, 43, 35
        return new double[] {
            0,0,0,0,0,0,1,1,2,3,
            5,5,6,7,8,9,10,11,12,13,
            15,16,17,18,19,20,21,22,23,23,
            23,24,25,26,27,30,31,32,35,37,
            40,41,41,42,42,43,44,45,46,47,
            50,51,52,53,53,54,54,55,56,57,
            58,59,59,60,60,60,60,60,60,60,
            57,56,56,55,54,53,52,51,51,50,
            49,49,48,45,45,43,43,40,40,37,
            37,35,35,35,30,30,30,20,10,0,0 };
    }

    private double[] RecoveryExample() {
        RecoveryCalculation RC = new RecoveryCalculation();
        Feed Test = new Feed();
        Test.ContactAngle = 60;
        Test.Grade = 15;
        return RC.CalculateParticleRecoveries(Test);
    }

    [Test]
    public void RecoveriesAreTheSame()
    {
        double[] Expected = RealLifeMockup();
        double[] Actual = RecoveryExample();
        int i = 0;
        foreach (double a in Actual)
        {
            Assert.AreEqual(Expected[i], a, 5);
            i++;
        }      
    }

    [Test]
    public void NumberOfRecoveriesHaveSameNumber()
    {
        int Expected = RealLifeMockup().Length;
        int Actual = RecoveryExample().Length;
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
