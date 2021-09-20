using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class FlotationParameters
    {
        public float FeedFlowRate = 100;
        public float SolidsPercentage = 0.3f;
        public float AirFlow;
        public float FrothThickness;
        public float CollectorDosage;
        public float FrotherDosage;
        public float CumulativeProfit;
        public float FeedCuGrade;
        public float FeedAsGrade;
        private float CuKinetics = 1;
        private float AsKinetics = 1;
        public int FeedStep;
        public float[] CuGrades = new float[] { 1.5f, 11.2f, 13f };
        public float[] AsGrades = new float[] { 0.1f, 1.1f, 1.2f };
        public float NoiseSizePercentage = 50;
        public FlotationParameters()
        {
            SetInitialVariables();
        }

        public void SetInitialVariables()
        {
            AirFlow = 13;
            FrothThickness = 30;
            CollectorDosage = 25;
            FrotherDosage = 8;
            CumulativeProfit = 0;
            FeedCuGrade = CuGrades[0];
            FeedAsGrade = AsGrades[0];
            FeedStep = 0;
        }

        /// <summary>
        /// Weights obtained by using Machine learning based on HSC model
        /// </summary>
        private float[] CuRecoveryWeights() {
            float Intercept = 17f;
            float AirWeight = 1.02f;
            float ThicknessWeight = -0.31f;
            float[] Weights = { Intercept, AirWeight, ThicknessWeight };
            return Weights;
        }

        private float[] AsRecoveryWeights()
        {
            float Intercept = 7.48f;
            float AirWeight = 0.53f;
            float ThicknessWeight = -0.11f;
            float[] Weights = { Intercept, AirWeight, ThicknessWeight };
            return Weights;
        }

        private float[] SolidsFlowWeights() {
            float Intercept = 0.04f;
            float AsRecoveryWeight = 0.07f;
            float CuRecoveryWeight = 0.08f;
            float[] Weights = { Intercept, AsRecoveryWeight, CuRecoveryWeight };
            return Weights;
        }

        public float ConcentrateCuRecovery() {
           float CuRec = CuRecoveryWeights()[0] +
                (CuRecoveryWeights()[1] * AirFlow) +
                (CuRecoveryWeights()[2] * FrothThickness);
            float DecayFactor = 0.047f;
            CuRec = CuRec - (Mathf.Exp(DecayFactor * FeedCuGrade));
            CuRec += CuRec + (CuRec * (UnityEngine.Random.value / NoiseSizePercentage));
            return CuRec;
        }

        private float AsRecovery()
        {
            float AsRec = AsRecoveryWeights()[0] + (AsRecoveryWeights()[1] * AirFlow) + (AsRecoveryWeights()[2] * FrothThickness);
            return AsRec;
        }

        public float ConcentrateCuGrade()
        {
            float AirFlowCorrection = AirFlow / 50;
            float CuInfGrade = (FeedCuGrade * ConcentrationRatio() * ConcentrateCuRecovery() / 100) - AirFlowCorrection;
            double ConcCuGrade = CuInfGrade * (1 - (Math.Exp(-CuKinetics * Time.realtimeSinceStartup)));
            double NoisyConcCuGrade = ConcCuGrade + (ConcCuGrade * (UnityEngine.Random.value / NoiseSizePercentage));
            return (float)Math.Round(NoisyConcCuGrade, 1);
        }

        public float ConcentrateAsGrade()
        {
            float AsInfGrade = FeedAsGrade * ConcentrationRatio() * AsRecovery() / 100;
            double ConcAsGrade = AsInfGrade * (1 - (Math.Exp(-AsKinetics * Time.realtimeSinceStartup)));
            double NoisyConcAsGrade = ConcAsGrade + (ConcAsGrade * (UnityEngine.Random.value / NoiseSizePercentage));
            return (float)Math.Round(NoisyConcAsGrade, 1);
        }

        public float TailingsCuGrade() {
            float MetalLoss = 100 - ConcentrateCuRecovery();
            float TailingsCuGrade = MetalLoss * FeedCuGrade * ReverseConcentrationRatio() / 100;
            float NoisyTailingsCuGrade = TailingsCuGrade + (TailingsCuGrade * (UnityEngine.Random.value / NoiseSizePercentage));
            return NoisyTailingsCuGrade;
        }

        public float TailingsAsGrade()
        {
            float MetalLoss = 100 - AsRecovery();
            float TailingsAsGrade = MetalLoss * FeedAsGrade * ReverseConcentrationRatio() / 100;
            float NoisyTailingsAsGrade = TailingsAsGrade + (TailingsAsGrade * (UnityEngine.Random.value / NoiseSizePercentage));
            return NoisyTailingsAsGrade;
        }

        private float ReverseConcentrationRatio() {
            float TailingsSolidsFlow = FeedSolidsFlow() - ConcentrateSolidsFlow();
            return FeedSolidsFlow() / TailingsSolidsFlow;
        }

        public float TailingsFlowRate() {
            float Tailing = FeedFlowRate - ConcentrateMassFlowInTPH();
            Tailing += Tailing * (UnityEngine.Random.value / NoiseSizePercentage);
            return (float)Math.Round(Tailing, 1);
        }

        private float FeedSolidsFlow() {
            float Result =FeedFlowRate * SolidsPercentage;
            Result = Result + (Result * (UnityEngine.Random.value / NoiseSizePercentage));
            return Result;
        }

        public float ConcentrateSolidsFlow() {
            float SolidsFlow = SolidsFlowWeights()[0] + (SolidsFlowWeights()[1] * AsRecovery()) + (SolidsFlowWeights()[2] * ConcentrateCuRecovery());
            return SolidsFlow;
        }

        public float ConcentrationRatio() {
            float Result = FeedSolidsFlow() / ConcentrateSolidsFlow();
            return Result;
        }

        public float ConcentrateMassFlowInTPH()
        {
            float Result = ConcentrateSolidsFlow() / SolidsPercentage;
            Result += Result + (Result * (UnityEngine.Random.value / NoiseSizePercentage));
            return Result;
        }

        public float ProfitPerSecond()
        {
            float ProfitPerSecond = RevenuePerSecond() - MiningCostPerSecond();
            return (float)Math.Round(ProfitPerSecond, 1);
        }

        //Figures derived from Winter, H. J.(1978);
        //https://www.arizonageologicalsoc.org/resources/Documents/Publications/Digests/Digest_11/23_AGS_DIG11_Winters_Production_Costs-S.pdf

        //Simplified calculation: https://www.quora.com/Whats-is-the-price-in-dollars-for-5-copper-ore?share=1

        private float MiningCostPerSecond()
        {
            float MiningCostPerTon = 10f;
            //float AdministrativeCosts = MiningCostPerTon * (0.4f + (Unity.Random.value * 0.2));
            //float CollectorPrice = 0.002012f;
            //float FrotherPrice = 0.002840f;
            float MiningCostPerSecond = (FeedFlowRate * (ConcentrateCuGrade()/100) * MiningCostPerTon / 3600);
            return MiningCostPerSecond;
        }

        private float RevenuePerSecond() {
            float CopperPrice = 6000f;
             return (CopperPrice * ((ConcentrateCuGrade() / 100) * ConcentrateSolidsFlow() / 3600)) - Penalty();
        }

        private float Penalty()
        {
            float PenaltyCost = 10000;
            if (ConcentrateAsGrade() > 1f)
            {
                return (ConcentrateAsGrade() - 1) * (ConcentrateSolidsFlow() / 3600) * PenaltyCost;
            }
            else
            {
                return 0;
            }
        }
    }
}
