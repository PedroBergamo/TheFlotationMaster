using UnityEngine;
using TMPro;
using ChartAndGraph;
using System;

public class RecoveryPlot : MonoBehaviour
{
    public GraphChart chart;
    double[] SimulatedData;

    void Start()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        SimulatedData = Recoveries.arrRecovery;
        int j = 0;
        foreach (double i in SimulatedData) {
            chart.DataSource.AddPointToCategory("Recoveries", j, i);
            j++;
        }         
    }

}
