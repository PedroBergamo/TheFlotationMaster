using UnityEngine;
using TMPro;

public class FeedFlowrate : MonoBehaviour {
    private TextMeshProUGUI TMPRO;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            TMPRO.text = FlotationCalculation.FeedFlowRate.ToString();
        }
    }
}
