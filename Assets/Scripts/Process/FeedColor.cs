using UnityEngine;
using Assets.Scripts.Controllers;

public class FeedColor : MonoBehaviour {

    public FlotationCalculation simulation;

    void Update () {
        var ps = GetComponent<ParticleSystem>().main;
        FeedColorController FC = new FeedColorController();
        FC.FeedVariable = (float)simulation.Simulation.feed.Grade;
        ps.startColor = FC.NewColor();
    }
}
