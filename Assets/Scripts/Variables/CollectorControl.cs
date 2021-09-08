using Assets.Scripts.Controllers;
using UnityEngine;

public class CollectorControl : MonoBehaviour {
    public PID CollectorPID;
    public WindowGraph CollectorGraph;

    private void Start()
    {
        SetInitialParameters();
    }

    void SetInitialParameters() {
        FlotationCalculation.Controller.AirFlow = 8;
        FlotationCalculation.Controller.FrothThickness = 30;
    }

    void Update ()
    {
        FlotationCalculation.Controller.CollectorDosage = CollectorPID.ProcessValue;
    }
}
