using UnityEngine;

public class ConcentrateSpeed : MonoBehaviour {
    public int DeltaPercentageFactor = 10;

    void Update()
    {
        var main = GetComponent<ParticleSystem>().main;
       // float SpeedFactor = (FlotationCalculation.Controller.ConcentrateMassFlowInTPH() - DeltaPercentageFactor) * DeltaPercentageFactor;
        //main.simulationSpeed = SpeedFactor;
    }
}
