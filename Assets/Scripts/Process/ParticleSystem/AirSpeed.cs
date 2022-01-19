using UnityEngine;

public class AirSpeed : MonoBehaviour {

    public FlotationCalculation simulation;

	void Update () {
        var main = GetComponent<ParticleSystem>().main;
        main.simulationSpeed = (float)simulation.Simulation.AirFlowRate * 4;
    }
}
