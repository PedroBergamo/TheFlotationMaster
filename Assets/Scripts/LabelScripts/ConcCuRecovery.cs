using UnityEngine;
using TMPro;

public class ConcCuRecovery : MonoBehaviour {
    TextMeshProUGUI ProcessLabel;
    public float LowerPenalty = 0;
    public float HigherPenalty = 1000000000;
    private float Variable;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            Variable = Mathf.Round(FlotationCalculation.Controller.ConcentrateCuRecovery());
            ProcessLabel.text = Variable.ToString();
        }
    }

    private void CheckForPenalty()
    {
        if (Variable < LowerPenalty || Variable > HigherPenalty)
        {
            ProcessLabel.color = Color.red;
        }
        else
        {
            ProcessLabel.color = Color.white;
        }
    }
}
