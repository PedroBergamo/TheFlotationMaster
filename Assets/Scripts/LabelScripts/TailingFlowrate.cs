using UnityEngine;
using TMPro;

public class TailingFlowrate : MonoBehaviour {
    TextMeshProUGUI TMPRO;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update () {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float Tailing = FlotationCalculation.Controller.TailingsFlowRate();
            TMPRO.text = Tailing.ToString();
        }
	}
}
