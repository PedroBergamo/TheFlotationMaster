using UnityEngine;

public class AirSpeed : MonoBehaviour {
    
	void Update () {
        var main = GetComponent<ParticleSystem>().main;
        main.simulationSpeed = FlotationCalculation.Controller.AirFlow * 4;
    }
}
