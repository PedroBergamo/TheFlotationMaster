using UnityEngine;
using TMPro;

public class FeedCuLabel : MonoBehaviour {
    float MaximumValue = 13;
    float MinimumValue = 9;    
    public float gradientFactor;

    public FlotationCalculation simulation;

    TextMeshProUGUI TMPRO;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float value = (float)simulation.Simulation.feed.Grade;
            TMPRO.text = value.ToString();
        }
    }

    private void AdjustLabelColors(float value)
    {
        float redFactor = (value - MinimumValue) / gradientFactor;
        float greenFactor = ((MaximumValue - value) / gradientFactor);
        TMPRO.color = new Color(255 * greenFactor, 255 * redFactor, 255 * greenFactor * redFactor);
    }
}

