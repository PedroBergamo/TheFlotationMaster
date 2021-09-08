using Assets.Scripts.Controllers;
using System;
using UnityEngine;

public class ConcentrationRatioExercise : MonoBehaviour
{
    public GameObject LevelClearedMenu;
    public AudioSource LevelClearedAudio;
    AudioPlayer audioPlayer;
    private int SecondsPassedWithCorrectRatio;

    private void Update()
    {
        if (TimeManager.SecondPassed) {
            if (Math.Round(FlotationCalculation.Controller.ConcentrateMassFlowInTPH()) == 20)
            {
                SecondsPassedWithCorrectRatio++;
            }
            else {
                SecondsPassedWithCorrectRatio = 0;
            }
        }
        if (SecondsPassedWithCorrectRatio >= 5)
        {
            CallClearedLevelPanel();
        }
    }

    private void CallClearedLevelPanel()
    {
        LevelClearedMenu.SetActive(true);
        audioPlayer= new AudioPlayer(LevelClearedAudio);
        audioPlayer.PlayOnce();
        gameObject.SetActive(false);
    }
}