using UnityEngine;

public class AirControl : MonoBehaviour {
    public PID AirFlowPID;

	void Update ()
    {
        FlotationCalculation.Controller.AirFlow = AirFlowPID.ProcessValue;
    }
}
