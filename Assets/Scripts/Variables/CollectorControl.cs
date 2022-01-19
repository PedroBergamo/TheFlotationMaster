using Assets.Scripts.Controllers;
using UnityEngine;

public class CollectorControl : MonoBehaviour {
    public PID CollectorPID;

    public FlotationCalculation simulation;

    void Update ()
    {
        simulation.Simulation.frotherConcentrate = CollectorPID.ProcessValue;
    }
}
