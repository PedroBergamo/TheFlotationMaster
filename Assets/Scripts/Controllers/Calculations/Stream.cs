using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stream: MonoBehaviour
{
    public double SolidsPercentage = 0.3;
    /// <summary>
    /// Mass flow rate in tons per hour
    /// </summary>
    public double MassFlowRate = 10;
    public double ContactAngle = 25;
    public double Grade;
    public float Kinetics = 1;

    /// <summary>
    /// Density in g/m^3
    /// </summary>
    public double Density = 4100;
    public double PercentageVariation = 3;

    private void Update()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            MassFlowRate = SampleGaussian(MassFlowRate, MassFlowRate / 100);
            Grade = SampleGaussian(Grade, Grade / 100);
        }
    }

    public double SampleGaussian(double mean, double stddev)
    {
        double x1 = 1 - UnityEngine.Random.value;
        double x2 = 1 - UnityEngine.Random.value;
        double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
        return y1 * stddev + mean;
    }

    private double VolumetricFlowRate()
    {
        return MassFlowRate + (MassFlowRate * (1 - SolidsPercentage));
    }
}
