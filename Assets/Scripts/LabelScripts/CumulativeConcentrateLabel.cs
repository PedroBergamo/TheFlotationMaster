using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CumulativeConcentrateLabel : MonoBehaviour
{
    public float LimitGrade;
    public float CumulativeConcentrate;
    public Stream FinalStream;
    public TextMeshProUGUI CumulativeText;


    private void Start()
    {
        CumulativeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (FlotationCalculation.NextSamplingIsReady) {
            if (FinalStream.Grade >= LimitGrade) {
                CumulativeConcentrate += (float)(FinalStream.MassFlowRate / 3600) * FlotationCalculation.SecondsForNextSampling;
            }
        }
        CumulativeText.text = System.Math.Round(CumulativeConcentrate, 3).ToString();
    }
}
