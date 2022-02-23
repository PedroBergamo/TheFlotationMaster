using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream: MonoBehaviour
{
    public double SolidsPercentage = 0.3;
    /// <summary>
    /// Mass flow rate in tons per hour
    /// </summary>
    public double MassFlowRate = 10;
    public double ContactAngle = 25;
    public double Grade = 1;
    public float Kinetics = 1;

    public int Times = 0;

    /// <summary>
    /// Density in g/m^3
    /// </summary>
    public double Density = 4100;
    public double PercentageVariation = 3;

    private void Update()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            Times++;
            MassFlowRate = NoisyValue(MassFlowRate, 2);
            Grade = (0.8) + (NoisyValue(0.2, 1 ));
        }
    }

    private double NoisyValue(double n, double PercentageVariation)
    {
        if (Random.value > 0.5)
        {
            return n + (-n * (Random.value / PercentageVariation));
        }
        else
            return n + (n * (Random.value / PercentageVariation));
    }

    private double VolumetricFlowRate()
    {
        return MassFlowRate + (MassFlowRate * (1 - SolidsPercentage));
    }
}
