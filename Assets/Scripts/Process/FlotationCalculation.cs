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
    private static float CuKinetics = 1;
    private static float AsKinetics = 1;
    public static float ConcentrateAsGrade;
    public static float FeedAsGrade;
    public static float FeedFlowRate = 10;
    public static float TailingsFlowRate;
    public static float TailingsCuGrade;
    public static float TailingsAsGrade;
    public static int particleDiameterInMicrons = 70;
    public static float SolidsPercentage = 0.3f;


    /// <summary>
    /// Weights obtained by using Linear Regression
    /// </summary>
    private static float[] SolidsFlowWeights()
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
    public static float ConcentrateMassFlow()
    {
        float SolidsFlow = SolidsFlowWeights()[0]
            + (SolidsFlowWeights()[2] * (float)ConcentrateCuRecovery());
        float Result = SolidsFlow / SolidsPercentage;
        Result += Result + (Result * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    private static float FeedSolidsFlow()
    {
        float Result = FeedFlowRate * SolidsPercentage;
        Result = Result + (Result * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    public static double ConcentrateCuRecovery() {
        return Simulation.arrRecovery[particleDiameterInMicrons];
    }

    public static float ConcentrationRatio()
    {
        float Result = FeedSolidsFlow() / flotationParameters.ConcentrateSolidsFlow();
        return Result;
    }
     
    public static float ConcentrateCuGrade()
    {
        float AirFlowCorrection = (float)Simulation.AirFlowRate / 50;
        float CuInfGrade = (float)(Simulation.feed.Grade * ConcentrationRatio() * ConcentrateCuRecovery() / 100) - AirFlowCorrection;
        double ConcCuGrade = CuInfGrade * (1 - Math.Exp(-CuKinetics * Time.realtimeSinceStartup));
        double NoisyConcCuGrade = ConcCuGrade + (ConcCuGrade *
            (UnityEngine.Random.value / NoiseSizePercentage));
        return (float)Math.Round(NoisyConcCuGrade, 1);
    }

    void Awake()
    {
        Simulation = new RecoveryExamples().CalculationExample();
        TimeManager.LevelSeconds = 0;
        flotationParameters = new FlotationParameters();
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
        }
        else
        {
            NextSamplingIsReady = false;
        }
    }
}