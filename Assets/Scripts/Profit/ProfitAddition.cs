using System;
using UnityEngine;
using TMPro;

public class ProfitAddition : MonoBehaviour
{
    public static bool LevelIsCleared;
    public float secondsToAddition;
    float addedProfit;
    float secondsPast;
    public TextMeshProUGUI profitText;
    public TextMeshProUGUI cumulativeProfitText;
    public Animator profitAnimator;
    public static float cumulativeProfit;

    private void Start()
    {
        profitText.text = "";
    }

    void Update()
    {
        if (TimeManager.SecondPassed)
        {
            AddProfit();
        }
    }

    void AddProfit()
    {
        if (secondsPast < secondsToAddition)
       {
       //     addedProfit += FlotationCalculation.Controller.ProfitPerSecond();
            secondsPast++;
        }
        else
        {
            profitAnimator.enabled = true;
            profitText.text = ProfitText();
            profitAnimator.Play(0);
            cumulativeProfit += addedProfit;
            cumulativeProfit = (float)Math.Round(cumulativeProfit, 1);
            cumulativeProfitText.text = "" + cumulativeProfit;
            addedProfit = 0;
            secondsPast = 0;
        }
    }

    private string ProfitText() {
        if (addedProfit > 0) {
            return "+" + (float)Math.Round(addedProfit,1);
        }
        return "" + addedProfit;
    }
}
