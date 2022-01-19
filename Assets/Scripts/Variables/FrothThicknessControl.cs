using UnityEngine;

public class FrothThicknessControl : MonoBehaviour {
    public PID FrothPID;
    public FlotationCalculation simulation;

    void Update()
    {
        simulation.Simulation.FrothHeight = FrothPID.ProcessValue / 100;
    }
}
