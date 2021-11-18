using System;
/// <summary>
/// Example obtained at Resources/Kyle2011.pdf - figure17
/// </summary>
/// <returns></returns>
public class RecoveryExamples{

    public RecoveryCalculation CalculationExample() {
        Feed Test = new Feed
        {
            ContactAngle = 25,
            Grade = 15,
            Density = 4100
        };
        RecoveryCalculation RC = new RecoveryCalculation()
        {
            feed = Test,
            Power = 2500,
            NumberOfCells = 4,
            RetentionTime = 3,
            ZetaPotential = -0.15
        };
        RC.SetUpCalculation();
        return RC;
    }

    public double[] ExpectedRecoveries() {
        double[] Recoveries = new double[CalculationExample().ParticleRange];
        
        for (int i = 0; i < Recoveries.Length; i++) {
            double Recovery = - Math.Pow((0.17 * i)-9,2) + (0.1 * i) + 60;
            Recoveries[i] = Recovery;
        }
        return Recoveries;
    }

    public double[] ParticleDiameters() {
        return CalculationExample().arrPDiam;
    }
}