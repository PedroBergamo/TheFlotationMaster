using System;
using UnityEngine;
using Assets.Scripts.Controllers;

public class FlotationCalculation : MonoBehaviour
{
    public RecoveryCalculation Simulation;
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
    private float TailingsCuGrade = 0.4f;
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
        float FakeConcGrade = 5;
        float AirFlowComponent = (float)Simulation.AirFlowRate / 5; //added to increase the impact of air changes, for didactic purposes
        float ConcentrateFlow =  (float)Simulation.feed.MassFlowRate * (float)Simulation.feed.Grade * (float)ConcentrateRecovery() / (100 * FakeConcGrade) + AirFlowComponent ;
        float Result = ConcentrateFlow + (ConcentrateFlow * (UnityEngine.Random.value / NoiseSizePercentage));
        return Result;
    }

    public double ConcentrateRecovery() {
        return Simulation.arrRecovery[particleDiameterInMicrons];
    }


     
    public float ConcentrateGrade()
    {
        float InfGrade = (TailingsCuGrade + ((((float)Simulation.feed.Grade - TailingsCuGrade) * (float)Simulation.feed.MassFlowRate) / ConcentrateMassFlow()));
        //float InfGrade = (float)ConcentrateRecovery() * (float)(Simulation.feed.Grade) * (5 * TailingsCuGrade)/ (float)(Simulation.feed.Grade * TailingsCuGrade * 100);
        double ConcGrade = InfGrade * (1 - Math.Exp(-Simulation.feed.Kinetics * Time.realtimeSinceStartup));
        double NoisyConcGrade = ConcGrade + (ConcGrade *
            (UnityEngine.Random.value / NoiseSizePercentage));
        return (float)Math.Round(NoisyConcGrade, 1);
    }
}