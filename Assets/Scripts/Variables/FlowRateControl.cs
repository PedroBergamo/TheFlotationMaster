using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowRateControl : MonoBehaviour
{
    public PID pid;
    public Stream stream;

    void Update()
    {
        stream.MassFlowRate = pid.ProcessValue;
    }
}
