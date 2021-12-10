using Assets.Scripts.Controllers;
using UnityEngine;

public class CollectorControl : MonoBehaviour {
    public PID CollectorPID;
    
    void Update ()
    {
        FlotationCalculation.Simulation.frotherConcentrate = CollectorPID.ProcessValue;
    }
}
