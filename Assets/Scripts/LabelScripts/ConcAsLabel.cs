﻿using UnityEngine;
using TMPro;

public class ConcAsLabel : MonoBehaviour {
    public static bool ThereIsPenalty;
    TextMeshProUGUI TMPRO;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update ()
    {
        if (FlotationCalculation.NextSamplingIsReady)
        {
            float AsGrade = FlotationCalculation.ConcentrateAsGrade;
            TMPRO.text = AsGrade.ToString();
            ThereIsPenalty = FlotationCalculation.ConcentrateAsGrade > 1;
            CheckForPenalty();
        }
    }

    private void CheckForPenalty()
    {
        if (ThereIsPenalty)
        {
            TMPRO.color = Color.red ;
        }
        else
        {
            TMPRO.color = Color.white;
        }
    }
}
