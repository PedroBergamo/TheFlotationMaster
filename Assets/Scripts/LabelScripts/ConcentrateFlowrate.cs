using UnityEngine;
using TMPro;

public class ConcentrateFlowrate : MonoBehaviour {
    TextMeshProUGUI ProcessLabel;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update () {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float ConcFlowRate = (float)System.Math.Round(FlotationCalculation.Controller.ConcentrateMassFlowInTPH(), 1);
            ProcessLabel.text = ConcFlowRate.ToString();
        }
    }
}