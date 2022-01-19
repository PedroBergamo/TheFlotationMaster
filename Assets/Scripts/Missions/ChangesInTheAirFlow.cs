using UnityEngine;

public class ChangesInTheAirFlow : MonoBehaviour
{
    public InstructionsManager Instructions;
    public AudioSource TaskClearedAudio;
    private int SecondsPassedWithCorrectRatio;
    public FlotationCalculation simulation;

    private bool[] Conditions() {
        bool[] conditions = new bool[10];
       // conditions[3] = (Mathf.Round(FlotationCalculation.Controller.FrothHeight) <= 29);
        //conditions[5] = (Mathf.Round(FlotationCalculation.Controller.AirFlowRate) >= 20);
        return conditions;
    }

    private void ChangesInTheFeed() {
        switch (Instructions.InstructionsIndex) {
            case 2:
                float NewCopperGrade = 5;
                simulation.Simulation.feed.Grade = (NewCopperGrade * (1 - (Mathf.Exp(- 1 * Time.realtimeSinceStartup))));
                break;
            default:
                break;
        }
    }    

    private void Update()
    {
        if (TimeManager.SecondPassed)
        {
            //ChangesInTheFeed();
            if (Conditions()[Instructions.InstructionsIndex])
            {
                SecondsPassedWithCorrectRatio++;
            }
            else
            {
                SecondsPassedWithCorrectRatio = 0;
            }
        }
        if (SecondsPassedWithCorrectRatio >= 5)
        {
            NextInstruction();
        }
    }

    private void NextInstruction()
    {
      SecondsPassedWithCorrectRatio = 0;
      TaskClearedAudio.Play();
      Instructions.NextText();
    }
}
