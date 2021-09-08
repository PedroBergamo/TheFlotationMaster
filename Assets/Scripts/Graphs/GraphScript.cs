using UnityEngine;
using Assets.Scripts.Controllers;

public class GraphScript : MonoBehaviour {  
    public WindowGraph ConcentrateGraph;
    public WindowGraph FlowRateGraph;

    void Update () {
        SetVariableGraphs();
    }

    private void SetVariableGraphs()
    {
        SetFlowRateGraph();
        SetConcGraph();
    }
    
    private void SetFlowRateGraph()
    {
        //ChartLine FRGraph = FlowRateGraph.FirstVariable;
        //FRGraph.Value = FlotationCalculation.Controller.ConcentrateMassFlowInTPH();
        //FRGraph.MaximumValue = 320;
    }

    private void SetConcGraph()
    {
        //ChartLine CuChart = ConcentrateGraph.FirstVariable;
        //CuChart.Value = FlotationCalculation.Controller.ConcentrateCuGrade() - 25;
        //CuChart.MaximumValue = 10;
        //ChartLine AsChart = ConcentrateGraph.SecondVariable;
        //AsChart.Value = FlotationCalculation.Controller.ConcentrateAsGrade() - 25;
        //AsChart.LineColor = new Color(1, 0, 0, 0.5f);
        //AsChart.MaximumValue = 10;
    }
}

