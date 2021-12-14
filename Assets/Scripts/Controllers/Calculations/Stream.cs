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

    /// <summary>
    /// Density in g/m^3
    /// </summary>
    public double Density = 4100;
    public double PercentageVariation = 3;


    private void Update()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            MassFlowRate = NoisyValue(MassFlowRate);
            Grade = NoisyValue(Grade);
        }
    }

    private double NoisyValue(double n)
    {
        if (Random.value > 0.5)
        {
            return n + (-n * (PercentageVariation / 100));
        }
        else
            return n + (n * (PercentageVariation / 100));
    }

    private double VolumetricFlowRate()
    {
        return MassFlowRate + (MassFlowRate * (1 - SolidsPercentage));
    }
}
