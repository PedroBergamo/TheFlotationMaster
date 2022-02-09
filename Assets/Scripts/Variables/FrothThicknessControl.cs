using UnityEngine;

public class FrothThicknessControl : MonoBehaviour {
    public PID FrothPID;
    public FlotationCalculation simulation;
    public double didacticFactor = 5;

    void Update()
    {
        simulation.Simulation.FrothHeight = FrothPID.ProcessValue / 100 * didacticFactor;
    }
}
