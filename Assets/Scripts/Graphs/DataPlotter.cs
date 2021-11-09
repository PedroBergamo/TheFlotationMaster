using UnityEngine;

public class DataPlotter : MonoBehaviour
{
    public float scalingFactorX = 1;
    public float scalingFactorY = 1;
    public float plotScale, width, height;
    public GameObject PointPrefab1;
    public GameObject PointPrefab2;
    private double NonNullNumber = 0.000000000000000001;

    public GameObject PointHolder;

    void Start()
    {
        RecoveryCalculation Recoveries = new RecoveryExamples().CalculationExample();
        Recoveries.CalculateParticleRecoveries();
        double[] SimulatedData = Recoveries.arrRecovery;
        double[] RealData = new RecoveryExamples().ExpectedRecoveries();
        Recoveries.FrothHeight = 20;
        Recoveries.CalculateParticleRecoveries();
        double[] data2 = Recoveries.arrRecovery;
        RectTransform rt = PointHolder.transform.GetComponent<RectTransform>();
        width = rt.sizeDelta.x * rt.localScale.x;
        height = rt.sizeDelta.y * rt.localScale.y;
        PlotGraph(data2, PointPrefab1);
        PlotGraph(SimulatedData, PointPrefab2);
    }

    private void PlotGraph(double[] Data, GameObject Point)
    {
        double yMax = FindMaxValue(Data);
        for (var i = 0; i < Data.Length; i++)
        {
            double recovery = Data[i];
            double y = ((recovery/ yMax ) * height) + NonNullNumber;
            double x = i * (width / Data.Length);
            GameObject dataPoint = Instantiate(
                    Point,
                    new Vector3((float)x, (float)y, 1) * plotScale,
                    Quaternion.identity);

            // Make child of PointHolder object, to keep points within container in hiearchy
            dataPoint.transform.SetParent(PointHolder.transform);
        }
    }

    private double FindMaxValue(double[] data)
    {
        double maxValue = 0;
        foreach (double number in data)
        {
            if (number > maxValue)
                maxValue = number;
        }
        return maxValue;
    }
}