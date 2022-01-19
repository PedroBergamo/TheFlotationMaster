using UnityEngine;
using TMPro;

public class ConcCuRecovery : MonoBehaviour {
    TextMeshProUGUI ProcessLabel;
    public float LowerPenalty = 0;
    public float HigherPenalty = 1000000000;
    private float Variable;
    public FlotationCalculation simulation;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            Variable = Mathf.Round((float)simulation.ConcentrateRecovery());
            ProcessLabel.text = Variable.ToString();
        }
    }
}
