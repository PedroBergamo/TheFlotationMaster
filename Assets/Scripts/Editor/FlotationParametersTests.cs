using NUnit.Framework;
using Assets.Scripts.Controllers;
using UnityEngine;

public class FlotationParametersTests {

    /// <summary>
    /// Trying to emulate the case decribed in References/Yanatos(2014).pdf
    /// </summary>
    /// <returns></returns>

    private FlotationCalculation FlotationExample() {
        Stream feed = new Stream
        {
            ContactAngle = 60,
            Grade = 1,
            Density = 4100,
            MassFlowRate = 10
        };
        FlotationCalculation FC = new FlotationCalculation();
        FC.Feed = feed;
        FC.ResetSimulation();
        FC.Simulation.FrothHeight = 0.15;
        FC.particleDiameterInMicrons = 100;
        FC.Simulation.CalculateParticleRecoveries();
        return FC;
    }

    [Test]
    public void ConcentrateCopperGradeCalculationTest()
    {
        float Expected = 5.38f;
        float Actual = FlotationExample().ConcentrateGrade();
        Assert.AreEqual(Expected, Actual, 1f);
    }


    [Test]
    public void ConcentrateRecoveryCalculationTest()
    {
        double Expected = 75;
        double Actual = FlotationExample().ConcentrateRecovery();
        Assert.AreEqual(Expected, Actual, 5f);
    }

    [Test]
    public void ConcentrateMassFlowCalculationTest()
    {
        float Expected = 1.5f;
        float Actual = FlotationExample().ConcentrateMassFlow();
        Assert.AreEqual(Expected, Actual, 0.5);
    }
}