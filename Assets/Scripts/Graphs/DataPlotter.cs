﻿using UnityEngine;

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
        RecoveryExamples Recoveries = new RecoveryExamples();
        double[] SimulatedData = Recoveries.SimulatedRecoveries();
        double[] RealData = Recoveries.RealLifeRecoveries();
        RectTransform rt = PointHolder.transform.GetComponent<RectTransform>();
        width = rt.sizeDelta.x * rt.localScale.x;
        height = rt.sizeDelta.y * rt.localScale.y;
        PlotGraph(RealData, PointPrefab1);

        PlotGraph(SimulatedData, PointPrefab2);
    }

    private void PlotGraph(double[] Data, GameObject Point)
    {
        double yMax = FindMaxValue(Data);
        for (var i = 0; i < Data.Length; i++)
        {
            Debug.Log(Data[i]);
            double y = ((Data[i] / yMax) * height) + NonNullNumber;
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
        for (var i = 0; i < data.Length; i++)
        {
            if (maxValue < data[i])
                maxValue = data[i];
        }
        return maxValue + NonNullNumber;
    }
}