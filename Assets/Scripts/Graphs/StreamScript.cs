using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreamScript : MonoBehaviour {
    public float CopperAmountm3PerSec;
    public float IronAmountm3PerSec;
    public float WasteAmountm3PerSec;
    public float MaximumAmount, MinimumAmount;

    void Update () {
        GetComponent<Text>().text = FlowRateInTonsPerHour() + " t/h";
    }

    public float FlowRateInM3PerSecond() {
        return CopperAmountm3PerSec + IronAmountm3PerSec + WasteAmountm3PerSec;
     }

    public float FlowRateInTonsPerHour()
    {
        return FlowRateInM3PerSecond() * 3600;
    }

    public float CopperGrade()
    {
        return CopperAmountm3PerSec / FlowRateInM3PerSecond() * 100;
    }

    public float IronGrade()
    {
        return IronAmountm3PerSec / FlowRateInM3PerSecond() * 100;
    }

    public bool CanAlter() {
        if (FlowRateInTonsPerHour() < MinimumAmount || FlowRateInTonsPerHour() > MaximumAmount)
        {
            Debug.Log("FlowRateInTonsPerHour " + FlowRateInTonsPerHour());
            return false;
        }
        else {
            Debug.Log("FlowRateInTonsPerHour " + FlowRateInTonsPerHour());

            return true;
        }
    }


}
