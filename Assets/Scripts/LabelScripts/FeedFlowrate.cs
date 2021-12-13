using UnityEngine;
using System;
using TMPro;

public class FeedFlowrate : MonoBehaviour {
    private TextMeshProUGUI TMPRO;
    public Stream stream;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            TMPRO.text = Math.Round(stream.MassFlowRate).ToString();
        }
    }
}
