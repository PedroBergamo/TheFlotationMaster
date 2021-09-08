using Assets.Scripts.Controllers;
using UnityEngine;

public class LevelGraphContainer : MonoBehaviour {
    public WindowGraph LevelGraph;
    public PID LevelPID;

    void Start () {
        SetInitialParameters(); 
    }

    void SetInitialParameters() {
        FlotationCalculation.Controller.AirFlow = 14;
        FlotationCalculation.Controller.CollectorDosage = 32;
    }
}
