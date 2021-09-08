using UnityEngine;

public class FrothThicknessControl : MonoBehaviour {
    public PID FrothPID; 

    void Start()
    {
        SetInitialParameters();
    }

    void SetInitialParameters()
    {
        FlotationCalculation.Controller.CollectorDosage = 32;
        FlotationCalculation.Controller.AirFlow = 13;
    }

    void Update()
    {
        FlotationCalculation.Controller.FrothThickness = FrothPID.ProcessValue;
    }
}
