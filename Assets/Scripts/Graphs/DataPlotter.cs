using UnityEngine;

public class DataPlotter : MonoBehaviour
{
    public float scalingFactorX = 1;
    public float scalingFactorY = 1;
    public float plotScale, width, height;
    public GameObject PointPrefab;
    public GameObject PointHolder;

    void Start()
    {
        float[] realData = RealLifeMockup();
        float yMax = FindMaxValue(realData);
        RectTransform rt = PointHolder.transform.GetComponent<RectTransform>();
        width = rt.sizeDelta.x * rt.localScale.x;
        height = rt.sizeDelta.y * rt.localScale.y;
        for (var i = 0; i < realData.Length; i++)
        {
            float y = (realData[i]/ yMax) * height;
            float x = i * (width/realData.Length);

            // Instantiate as gameobject variable so that it can be manipulated within loop
            GameObject dataPoint = Instantiate(
                    PointPrefab,
                    new Vector3(x, y, 1) * plotScale,
                    Quaternion.identity);

            // Make child of PointHolder object, to keep points within container in hiearchy
            dataPoint.transform.SetParent(PointHolder.transform);         
        }
    }

    private float FindMaxValue(float[] data)
    {
        float maxValue = 0;
        for (var i = 0; i < data.Length; i++)
        {
            if (maxValue < data[i])
                maxValue = data[i];
        }
        return maxValue;
    }

    private float[] RealLifeMockup()
    {
        // five points from real data: 50, 59, 47, 43, 35
        // from didactic kyle.2011.pdf
        return new float[] {
            0,0,0,0,0,0,1,1,2,3,
            5,5,6,7,8,9,10,11,12,13,
            15,16,17,18,19,20,21,22,23,23,
            23,24,25,26,27,30,31,32,35,37,
            40,41,41,42,42,43,44,45,46,47,
            50,51,52,53,53,54,54,55,56,57,
            58,59,59,60,60,60,60,60,60,60,
            57,56,56,55,54,53,52,51,51,50,
            49,49,48,45,45,43,43,40,40,37,
            37,35,35,35,30,30,30,20,10,0,0 };
    }
}