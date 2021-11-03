/// <summary>
/// Examples obtained at Resources/Kyle2011.pdf
/// </summary>
/// <returns></returns>
public class RecoveryExamples{

public double[] RealLifeRecoveries() {
        return new double[] {
            0,0,0,0,0,0,1,1,2,3,
            5,5,6,7,8,9,10,11,12,13,
            15,16,17,18,19,20,21,22,23,23,
            23,24,25,26,27,30,31,32,35,37,
            40,41,41,42,42,43,44,45,46,47,
            50,51,52,53,53,54,54,55,56,57,
            58,59,59,60,60,60,60,60,60,60,
            57,56,56,55,54,53,52,51,51,50,
            49,49,48,45,45,43,43,40,40,37,
            37,35,35,35,30,30,30,20,10,0,0 };
    }

    public double[] SimulatedRecoveries() {
        RecoveryCalculation RC = new RecoveryCalculation();
        RC.AirFlowRate = 2;
        RC.FrothHeight = 10;
        Feed Test = new Feed();
        Test.ContactAngle = 60;
        Test.Grade = 15;
        return RC.CalculateParticleRecoveries(Test);
    }
}