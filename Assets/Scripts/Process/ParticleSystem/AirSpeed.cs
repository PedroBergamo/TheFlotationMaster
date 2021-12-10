using UnityEngine;

public class AirSpeed : MonoBehaviour {
    
	void Update () {
        var main = GetComponent<ParticleSystem>().main;
        main.simulationSpeed = (float)FlotationCalculation.Simulation.AirFlowRate * 4;
    }
}
