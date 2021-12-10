using UnityEngine;
using TMPro;

public class FeedAsLabel : MonoBehaviour {
    public float MaximumValue = 0.5f;
    public float MinimumValue = 1.5f;
    public float GradientFactor;

    TextMeshProUGUI TMPRO;
    public bool ColorTest;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            TMPRO.text = AsGrade().ToString();
        }
    }

    private void AdjustLabelColor()
    {
        float BigFactor = ((MaximumValue - AsGrade())) / GradientFactor;
        float SmallFactor = (AsGrade() - MinimumValue) / GradientFactor;
        TMPRO.color = new Color(255, 255 * BigFactor, 255 * BigFactor * SmallFactor);
    }

    private float AsGrade() {
        if (ColorTest) {
            return float.Parse(TMPRO.text);
        }
        return FlotationCalculation.FeedAsGrade;
    }
}
