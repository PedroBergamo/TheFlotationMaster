using UnityEngine;
using TMPro;

public class GradeLabel : MonoBehaviour {
    public static bool ThereIsPenalty;
    public Stream stream;
    TextMeshProUGUI ProcessLabel;

    private void Start()
    {
        ProcessLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            ProcessLabel.text = System.Math.Round(stream.Grade,2).ToString();
        }
    }
}
