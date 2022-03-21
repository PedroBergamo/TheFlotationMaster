using System;
using UnityEngine;
using Assets.Scripts.Controllers;

public class FlotationCalculation : MonoBehaviour
{
    public RecoveryCalculation Simulation;
    public static float SecondsForNextSampling = 3;
    public float SecondsSinceLastSampling = 0;
    public static bool NextSamplingIsReady = false;

    public static float NoiseSizePercentage = 50;
    public static float ConcentrateAsGrade;
    public int particleDiameterInMicrons = 129;
    public Stream Feed;
    public Stream ConcentrateStream;
    private float TailingsCuGrade = 0.4f;

    void Awake()
    {
        ResetSimulation();
        TimeManager.LevelSeconds = 0;
        ConcentrateStream = GetComponent<Stream>();
    }

    public void ResetSimulation()
    {
        Simulation = new RecoveryCalculation()
        {
            feed = Feed,
            Power = 1500,
            NumberOfCells = 4,
            RetentionTime = 3,
            ZetaPotential = -0.015
        };
    }

    private void Update()
    {
        if (TimeManager.SecondPassed)
        {
            SecondsSinceLastSampling++;
        }
        if (SecondsSinceLastSampling >= SecondsForNextSampling)
        {
            NextSamplingIsReady = true;
            Simulation.CalculateParticleRecoveries();
            SecondsSinceLastSampling = 0;
            UpdateStreams();
        }
        else
        {
            NextSamplingIsReady = false;
        }
    }

    private void UpdateStreams() {
        ConcentrateStream.MassFlowRate = ConcentrateMassFlow();
        ConcentrateStream.Grade = ConcentrateGrade();
    }

    /// <summary>
    /// Concentrate mass flow in tons per hour
    /// </summary>
    /// <returns></returns>
    public float ConcentrateMassFlow()
    {
        float FakeConcGrade = 5.4f;
        float ConcentrateFlow =  (float)Simulation.feed.MassFlowRate * (float)Simulation.feed.Grade * (float)ConcentrateRecovery() / (100 * FakeConcGrade);
        float Result = ConcentrateFlow + (ConcentrateFlow * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    public double ConcentrateRecovery() {
        return Simulation.arrRecovery[particleDiameterInMicrons] - 15;
    }

    public float ConcentrateGrade()
    {
        float MassFlowCorrection = 0; //added to make sure that it reaches a value similar to FakeConcGrade
        float MassFlow = ConcentrateMassFlow() - MassFlowCorrection;
        float InfGrade = TailingsCuGrade + ((((float)Simulation.feed.Grade - TailingsCuGrade) * (float)Simulation.feed.MassFlowRate) / (MassFlow));
        //float InfGrade = (float)ConcentrateRecovery() * (float)(Simulation.feed.Grade) * (5 * TailingsCuGrade)/ (float)(Simulation.feed.Grade * TailingsCuGrade * 100);
        double ConcGrade = InfGrade * (1 - Math.Exp(-Simulation.feed.Kinetics * Time.realtimeSinceStartup));
        double NoisyConcGrade = ConcGrade + (ConcGrade *
            (UnityEngine.Random.value / NoiseSizePercentage));
        return (float)Math.Round(NoisyConcGrade, 1);
    }
}