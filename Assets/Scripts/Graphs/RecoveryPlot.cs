using UnityEngine;
using TMPro;
using ChartAndGraph;
using System;

public class RecoveryPlot : MonoBehaviour
{
    public GraphChart chart;
    double[] SimulatedData;
    double[] RealData;

    void Start()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        SimulatedData = Recoveries.arrRecovery;
        RealData = new RecoveryExamples().ExpectedRecoveries();
        int j = 0;
        foreach (double i in SimulatedData) {
            chart.DataSource.AddPointToCategory("Recoveries", j, i);
            j++;
        }
         j = 0;
        foreach (double i in RealData) {
            chart.DataSource.AddPointToCategory("ExpectedRecoveries", j, i);
            j++;
        }
    }

}
