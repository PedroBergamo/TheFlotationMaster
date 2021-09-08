using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts.Controllers;

public class DisableButtonTest
{

    DisableButtonController disableButtonController;
    PIDController PIDTest;

    [Test]
    public void DisableButtonWithMaximunValue()
    {
        PIDTest = NewPID();
        disableButtonController = new DisableButtonController();
        disableButtonController.variable = NewPID();
        bool FirstAnswer = disableButtonController.IsOutOfLimits();
        PIDTest.MaxValue = 19;
        bool SecondAnswer = disableButtonController.IsOutOfLimits();
        Assert.AreNotEqual(FirstAnswer, SecondAnswer);
    }

    [Test]
    public void DisableButtonWithMinimunValue()
    {
        PIDTest = NewPID();
        disableButtonController = new DisableButtonController();
        disableButtonController.variable = NewPID();
        bool FirstAnswer = disableButtonController.IsOutOfLimits();
        PIDTest.MinValue = 23;
        bool SecondAnswer = disableButtonController.IsOutOfLimits();
        Assert.AreNotEqual(FirstAnswer, SecondAnswer);
    }

    private PIDController NewPID()
    {
        PIDTest = new PIDController();
        PIDTest.SetPoint = 20;
        PIDTest.MaxValue = 30;
        PIDTest.MinValue = 10;       
        return PIDTest;
    }
}
