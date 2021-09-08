using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Scripts.Controllers;

public class ColorChangeTests {

    FeedColorController feedColorController;

    [Test]
    public void FeedFeChange()
    {
        feedColorController = new FeedColorController();
        feedColorController.FeedVariable = 1;
        Color Expected = feedColorController.NewColor();
        feedColorController.FeedVariable = 0;
        Color Actual = feedColorController.NewColor();
        Assert.AreNotEqual(Expected, Actual);
    }

    [Test]
    public void FrothFeChange()
    {
        TankColorController TC = new TankColorController(2, 1);
        Color Expected = TC.NewColor();

        TankColorController TC2 = new TankColorController(0, 1);
        Color Actual = TC2.NewColor();
        Assert.AreNotEqual(Expected, Actual);
    }
}
