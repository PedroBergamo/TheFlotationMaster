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
    private float ConcentrationRatio = 2;

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
        ConcentrateStream = GetComponent<Stream>();
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
        float Intercept = 0.004f;
        float RecoveryWeight = 0.01f;
        float[] Weights = { Intercept, RecoveryWeight };
        return Weights;
    }

    /// <summary>
    /// Concentrate mass flow in tons per hour
    /// </summary>
    /// <returns></returns>
    public float ConcentrateMassFlow()
    {
        float SolidsFlow =  (0.7f * (float)Simulation.feed.MassFlowRate / ConcentrationRatio) + (0.3f * (float)Simulation.feed.MassFlowRate * (float)ConcentrateRecovery()/100);
        float Result =  SolidsFlow + (SolidsFlow * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    public static double ConcentrateRecovery() {
        return Simulation.arrRecovery[particleDiameterInMicrons];
    }


     
    public float ConcentrateGrade()
    {
        float InfGrade = (float)(Simulation.feed.Grade * ConcentrationRatio * ConcentrateRecovery() / 100);
        double ConcGrade = InfGrade * (1 - Math.Exp(-Simulation.feed.Kinetics * Time.realtimeSinceStartup));
        double NoisyConcGrade = ConcGrade + (ConcGrade *
            (UnityEngine.Random.value / NoiseSizePercentage));
        return (float)Math.Round(NoisyConcGrade, 1);
    }
}