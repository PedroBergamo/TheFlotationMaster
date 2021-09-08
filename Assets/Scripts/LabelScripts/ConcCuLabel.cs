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
            float CuGrade = FlotationCalculation.Controller.ConcentrateCuGrade();
            ProcessLabel.text = CuGrade.ToString();
            ThereIsPenalty = FlotationCalculation.Controller.ConcentrateCuGrade() < 28;
        }
    }

    private void CheckForPenalty()
    {
        if (ThereIsPenalty)
        {
            ProcessLabel.color = Color.red;
        }
        else
        {
            ProcessLabel.color = Color.white;
        }
    }
}
