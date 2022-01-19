using UnityEngine;

public class AirControl : MonoBehaviour {
    public PID AirFlowPID;
    public FlotationCalculation simulation;


    void Update ()
    {
        simulation.Simulation.AirFlowRate = AirFlowPID.ProcessValue;
    }
}
