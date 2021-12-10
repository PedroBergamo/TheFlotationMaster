using Assets.Scripts.Controllers;
using UnityEngine;

public class TankContentColor : MonoBehaviour {
    public float alpha = 1;

	void Update () {
        TankColorController TC = new TankColorController(FlotationCalculation.ConcentrateAsGrade, alpha);
        GetComponent<SpriteRenderer>().color = TC.NewColor();
    }
}