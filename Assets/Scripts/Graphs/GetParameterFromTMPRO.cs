using UnityEngine;
using TMPro;
using ChartAndGraph;
using System;

public class GetParameterFromTMPRO : MonoBehaviour
{
    public TextMeshProUGUI TMPro;
    private GraphChart chart;
    public float NoiseSizePercentage = 50;
    public float SlideTime = 2f;

    void Start() {
        chart = GetComponent<GraphChart>();
    }

    void Update()
    {
        float Parameter = float.Parse(TMPro.text);
        float Noise = Parameter * (UnityEngine.Random.value / NoiseSizePercentage);
        Parameter = Parameter + Noise;
        if (TimeManager.SecondPassed) {
            string ChartName = TMPro.gameObject.name;
            chart.DataSource.AddPointToCategoryRealtime(ChartName, DateTime.Now, Parameter, SlideTime);
        }
    }
}
