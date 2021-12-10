using UnityEngine;
using TMPro;

public class TailingsAsLabel : MonoBehaviour {
    TextMeshProUGUI ProcessLabel;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float AsGrade = (float)System.Math.Round(FlotationCalculation.TailingsAsGrade, 1);
            ProcessLabel.text = AsGrade.ToString();
        }
    }
}
