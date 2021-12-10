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
            float ConcFlowRate = (float)System.Math.Round((float)FlotationCalculation.ConcentrateMassFlow(), 1);
            ProcessLabel.text = ConcFlowRate.ToString();
        }
    }
}