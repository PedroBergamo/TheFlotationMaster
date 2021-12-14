using System;
using UnityEngine;
using Assets.Scripts.Controllers;

public class FlotationCalculation : MonoBehaviour
{
    public static RecoveryCalculation Simulation;
    public static FlotationParameters flotationParameters;
    public static float SecondsForNextSampling = 3;
    public float SecondsSinceLastSampling = 0;
    public static bool NextSamplingIsReady = false;

    public static float NoiseSizePercentage = 50;
    //private static float AsKinetics = 1;
    public static float ConcentrateAsGrade;
    //public static float FeedAsGrade;
    //public static float TailingsFlowRate;
    //public static float TailingsCuGrade;
    //public static float TailingsAsGrade;
    public static int particleDiameterInMicrons = 70;
    public Stream Feed;
    public Stream ConcentrateStream;

    void Awake()
    {
        Simulation = new RecoveryCalculation() {
            feed=Feed,
            Power = 2500,
            NumberOfCells = 4,
            RetentionTime = 3,
            ZetaPotential = -0.15
         
    };
        TimeManager.LevelSeconds = 0;
        flotationParameters = new FlotationParameters();
        ConcentrateStream = new Stream();
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
    /// Weights obtained by using Linear Regression
    /// </summary>
    private float[] SolidsFlowWeights()
    {
        float Intercept = 0.04f;
        float AsRecoveryWeight = 0.07f;
        float CuRecoveryWeight = 0.08f;
        float[] Weights = { Intercept, AsRecoveryWeight, CuRecoveryWeight };
        return Weights;
    }

    /// <summary>
    /// Concentrate mass flow in tons per hour
    /// </summary>
    /// <returns></returns>
    public float ConcentrateMassFlow()
    {
        float SolidsFlow = SolidsFlowWeights()[0]
            + (SolidsFlowWeights()[2] * (float)ConcentrateRecovery());
        float Result = (float)(Simulation.feed.MassFlowRate / Simulation.feed.SolidsPercentage);
        Result += Result + (Result * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    public static double ConcentrateRecovery() {
        return Simulation.arrRecovery[particleDiameterInMicrons];
    }

    public float ConcentrationRatio()
    {
        float Result = (float)Simulation.feed.MassFlowRate / flotationParameters.ConcentrateSolidsFlow();
        return Result;
    }
     
    public float ConcentrateGrade()
    {
        float AirFlowCorrection = (float)Simulation.AirFlowRate / 50;
        float CuInfGrade = (float)(Simulation.feed.Grade * ConcentrationRatio() * ConcentrateRecovery() / 100) - AirFlowCorrection;
        double ConcCuGrade = CuInfGrade * (1 - Math.Exp(-Simulation.feed.Kinetics * Time.realtimeSinceStartup));
        double NoisyConcCuGrade = ConcCuGrade + (ConcCuGrade *
            (UnityEngine.Random.value / NoiseSizePercentage));
        return (float)Math.Round(NoisyConcCuGrade, 1);
    }
}