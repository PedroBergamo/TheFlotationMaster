using NUnit.Framework;
using Assets.Scripts.Controllers;
using UnityEngine;

public class FlotationParametersTests {

    private FlotationParameters FlotationExample() {
        FlotationParameters FC = new FlotationParameters
        {
            AirFlow = 2,
            FrothThickness = 10,
            FeedCuGrade = 15
        };
        return FC;
    }

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
    public void ConcentrateCopperGradeCalculationTest()
    {
        float Expected = 32.76f;
        float Actual = FlotationExample().ConcentrateCuGrade();
        Assert.AreEqual(Expected, Actual, 0.1f);
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
    public void ConcentrateCopperRecoveryCalculationTest()
    {
        float Expected = 42.91f;
        float Actual = FlotationExample().ConcentrateCuRecovery();
        Assert.AreEqual(Expected, Actual, 0.1f);
    }

    [Test]
    public void TailingsCopperCalculationTest()
    {
        float Expected = 7.33f;
        float Actual = FlotationExample().TailingsCuGrade();
        Assert.AreEqual(Expected, Actual, 0.1f);
    }

    [Test]
    public void ConcentrateArsenicGradeCalculationTest()
    {
        float Expected = 1.09f;
        float Actual = FlotationExample().ConcentrateAsGrade();
        Assert.AreEqual(Expected, Actual, 0.1);
    }

    [Test]
    public void TailingArsenicGradeCalculationTest()
    {
        float Expected = 1.33f;
        float Actual = FlotationExample().TailingsAsGrade();
        Assert.AreEqual(Expected, Actual, 0.1);
    }

    [Test]
    public void ConcentrateMassFlowCalculationTest()
    {
        float Expected = 14.37f;
        float Actual = FlotationExample().ConcentrateMassFlowInTPH();
        Assert.AreEqual(Expected, Actual, 1);
    }

    [Test]
    public void ConcentrateSolidsFlowCalculationTest()
    {
        float Expected = 4.31f;
        float Actual = FlotationExample().ConcentrateSolidsFlow();
        Assert.AreEqual(Expected, Actual, 0.1);
    }

    [Test]
    public void ConcentrationRatioTest()
    {
        float Expected = 6.96f;
        float Actual = FlotationExample().ConcentrationRatio();
        Assert.AreEqual(Expected, Actual, 0.5f);
    }
}
