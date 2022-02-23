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
}

