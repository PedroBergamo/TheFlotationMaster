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

    private float SimulationRecovery()
    {
        float Recovery = (float)Simulation.arrRecovery[particleDiameterInMicrons];
        float RecoveryCorrection = 9 / (float)Math.Pow(Recovery, 1 / 2);
        return Recovery - RecoveryCorrection;
    }

    /// <summary>
    /// Concentrate mass flow in tons per hour
    /// </summary>
    /// <returns></returns>
    public float ConcentrateMassFlow()
    {
        float FakeConcGrade = 5.4f;
        float AirFlowFactor = (float)Simulation.AirFlowRate / 10;
        float Recovery = SimulationRecovery();
        float ConcentrateFlow = AirFlowFactor + (float)Simulation.feed.MassFlowRate * (float)Simulation.feed.Grade * Recovery / (100 * FakeConcGrade);
        float Result = ConcentrateFlow + (ConcentrateFlow * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    public float ConcentrateGrade()
    {
        float MassFlowCorrection = (float)Math.Pow(ConcentrateMassFlow(), 1/2);
        float AirFlowFactor = (float)Simulation.AirFlowRate / 10;
        float MassFlow = ConcentrateMassFlow() + MassFlowCorrection - AirFlowFactor;
        float InfGrade = TailingsCuGrade + ((((float)Simulation.feed.Grade - TailingsCuGrade) * (float)Simulation.feed.MassFlowRate) / (MassFlow));
        double ConcGrade = InfGrade * (1 - Math.Exp(-Simulation.feed.Kinetics * Time.realtimeSinceStartup));
        double NoisyConcGrade = ConcGrade + (ConcGrade *
            (UnityEngine.Random.value / NoiseSizePercentage));
        return (float)Math.Round(NoisyConcGrade, 1);
    }

    public float ConcentrateRecovery()
    {
        return ConcentrateMassFlow() * ConcentrateGrade() * 100 / (float)Simulation.feed.MassFlowRate * (float)Simulation.feed.Grade;
    }

   
}