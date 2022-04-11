using NUnit.Framework;
using Assets.Scripts.Controllers;
using UnityEngine;

public class FlotationCalculationTests {

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

        FlotationCalculation FC = FlotationExample();
        FC.Simulation.FrothHeight = 0.2;
        FC.Simulation.AirFlowRate = 1;
        float Expected = 5.38f;
        float Actual = FC.ConcentrateGrade();
        Assert.AreEqual(Expected, Actual, 1f);
    }


    [Test]
    public void ConcentrateRecoveryCalculationTest()
    {
        double Expected = 45;
        double Actual = FlotationExample().ConcentrateRecovery();
        Assert.AreEqual(Expected, Actual, 10f);
    }

    [Test]
    public void ConcentrateMassFlowCalculationTest()
    {
        float Expected = 1.5f;
        float Actual = FlotationExample().ConcentrateMassFlow();
        Assert.AreEqual(Expected, Actual, 0.5);
    }


    [Test]
    public void ConcentrateMassFlowSmallerThanOneTest()
    {
        FlotationExample().Simulation.FrothHeight = 0.2;
        FlotationExample().Simulation.AirFlowRate = 1;
        float Expected = 5f;
        float Actual = FlotationExample().ConcentrateGrade();
        Assert.AreEqual(Expected, Actual, 2);
    }

    [Test]
    public void RecoveryTest()
    {
        float Recovery1 = FlotationExample().ConcentrateMassFlow() * FlotationExample().ConcentrateGrade() * 100 / 10;
        float Recovery2 = FlotationExample().ConcentrateRecovery();
        Assert.AreEqual(Recovery1, Recovery2, 2);
    }

    [Test]
    public void RecoveryDiffParametersTest()
    {
        FlotationExample().Simulation.FrothHeight = 0.1;
        FlotationExample().Simulation.AirFlowRate = 0.4;

        float Recovery11 = FlotationExample().ConcentrateMassFlow() * FlotationExample().ConcentrateGrade() * 100 / 10;
        float Recovery22 = FlotationExample().ConcentrateRecovery();
        Assert.AreEqual(Recovery11, Recovery22, 5);
    }
}