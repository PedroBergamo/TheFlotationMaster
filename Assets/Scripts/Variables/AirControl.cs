using UnityEngine;

public class AirControl : MonoBehaviour {
    public PID AirFlowPID;

	void Update ()
    {
        FlotationCalculation.Simulation.AirFlowRate = AirFlowPID.ProcessValue;
    }
}
