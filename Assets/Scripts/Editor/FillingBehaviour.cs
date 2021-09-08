using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillingBehaviour : MonoBehaviour
{
    public static bool isTransbording = false;
    RectTransform MaterialRectTransform;
    float MinimumValue = -0.36f;
    float MaximumValue = 0.1f;
    public PID TankPID;

    void Start()
    {
        MaterialRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        FillTheTankAnimation();
    }

    void FillTheTankAnimation()
    {
        MaterialRectTransform.localPosition = new Vector3(MaterialRectTransform.localPosition.x, yPosition(), MaterialRectTransform.localPosition.z);
    }

    private float yPosition() {
        float Percentage = ((TankPID.ProcessValue) - 120) / 180;
        float Difference = Percentage * (MaximumValue - MinimumValue);
        return MaximumValue - Difference;
    }
}
