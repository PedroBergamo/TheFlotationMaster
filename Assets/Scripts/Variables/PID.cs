using UnityEngine;
using Assets.Scripts.Controllers;

public class PID : MonoBehaviour {

    public float Kp = 0.0001f;
    public float Ki = 0.00000005f;
    public float ProcessValue;
    public float SetPoint;
    public float MinValue;
    public float MaxValue;
    public float Step;

    public PIDController pIDController;

    void Awake()
    {
        pIDController = new PIDController();
        pIDController.SetPoint = SetPoint;
        pIDController.ProcessValue = ProcessValue;
        pIDController.MinValue = MinValue;
        pIDController.MaxValue= MaxValue;
    }

    void Update () {
        pIDController.SetPoint = SetPoint;
        pIDController.Kp = Kp;
        pIDController.Ki = Ki;
        ProcessValue = pIDController.NewValue();
    }

    public void AddValue()
    {
        if (SetPoint < MaxValue)
        {
            SetPoint += Step;
        }
    }

    public void SubtractValue()
    {
        if (SetPoint > MinValue)
        {
            SetPoint -= Step;
        }
    }
}

