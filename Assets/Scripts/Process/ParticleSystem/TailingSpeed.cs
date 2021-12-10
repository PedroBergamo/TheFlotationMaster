using UnityEngine;

public class TailingSpeed : MonoBehaviour {
    public int DeltaPercentageFactor = 10;

    void Update()
    {
        var main = GetComponent<ParticleSystem>().main;
       // float TailingSimulationSpeed = 100 - ((FlotationCalculation.Controller.ConcentrateMassFlowInTPH() - DeltaPercentageFactor) * DeltaPercentageFactor);
        //main.simulationSpeed = TailingSimulationSpeed;
    }
}
