using UnityEngine;
using TMPro;

public class ConcCuLabel : MonoBehaviour {
    public static bool ThereIsPenalty;
    TextMeshProUGUI ProcessLabel;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float CuGrade = FlotationCalculation.ConcentrateCuGrade();
            ProcessLabel.text = CuGrade.ToString();
        }
    }
}
