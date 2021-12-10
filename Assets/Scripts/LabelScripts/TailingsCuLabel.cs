using UnityEngine;
using TMPro;

public class TailingsCuLabel : MonoBehaviour {
    TextMeshProUGUI ProcessLabel;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float CuGrade = (float)System.Math.Round(FlotationCalculation.TailingsCuGrade, 1);
            ProcessLabel.text = CuGrade.ToString();
        }
    }
}
