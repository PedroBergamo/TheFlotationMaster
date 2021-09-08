using NUnit.Framework;
using Assets.Scripts.Controllers;
using UnityEngine;

public class FlotationParametersTests {

    private FlotationParameters FlotationExample() {
        FlotationParameters FC = new FlotationParameters
        {
            AirFlow = 15,
            FrothThickness = 30,
            FeedCuGrade = 11
        };
        return FC;
    }

    [Test]
    public void ConcentrateCopperGradeCalculationTest()
    {
        float Expected = 32.76f;
        float Actual = FlotationExample().ConcentrateCuGrade();
        Assert.AreEqual(Expected, Actual, 0.1f);
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
