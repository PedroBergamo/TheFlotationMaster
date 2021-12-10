using UnityEngine;

public class FrothThicknessControl : MonoBehaviour {
    public PID FrothPID;   

    void Update()
    {
        FlotationCalculation.Simulation.FrothHeight = FrothPID.ProcessValue / 100;
    }
}
