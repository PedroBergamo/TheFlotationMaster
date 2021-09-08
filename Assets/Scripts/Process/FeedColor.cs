using UnityEngine;
using Assets.Scripts.Controllers;

public class FeedColor : MonoBehaviour {
	
	void Update () {
        var ps = GetComponent<ParticleSystem>().main;
        FeedColorController FC = new FeedColorController();
        FC.FeedVariable = FlotationCalculation.Controller.FeedCuGrade;
        ps.startColor = FC.NewColor();
    }
}
