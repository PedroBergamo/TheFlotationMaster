using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Controllers;

public class TimerLabel : MonoBehaviour {
    public float levelTime;
    public GameObject LevelFailedScreen;
    public GameObject gameCanvas;
    public AudioSource TimerBeep;
    public AudioSource LevelFailedSound;
    public TextMeshProUGUI TimeText;
    AudioPlayer LevelFailAudio;
    public Image Chronometer;
    float RemainingTime;
    float totalTime;
    float EndingTime = 10;
    TimeFormater timeFormater;

    public void ResetTimer()
    {
        LevelFailAudio = new AudioPlayer(LevelFailedSound);
        totalTime = levelTime;
        Chronometer.fillAmount = 1;
        RemainingTime = 0;
        TimeText.color = Color.white;
    }

    void Update ()
    {
        timeFormater = new TimeFormater();
        TimeText.fontSize = 100;
        CheckForLevelCleared();
        CheckForLevelFailed();
    }

    private void CheckForLevelCleared()
    {
        if (ProfitTask.TaskIsComplete) {
            gameObject.SetActive(false);
        }
    }

    private void CheckForLevelFailed()
    {
        if (totalTime < 0.1f)
        {
            TimeIsUp();
            LevelFailedScreen.SetActive(true);
        }
        else CheckIfTimeIsEnding();
    }

    private void CheckIfTimeIsEnding()
    {
        totalTime -= Time.deltaTime;
        UpdateChronometer();
        if (totalTime <= EndingTime)
        {
            TimeText.color = Color.red;
            BumpingTextLabel();
        }
        TimeText.text = timeFormater.FormattedTime(totalTime);
    }

    private void BumpingTextLabel()
    {
        TimeText.color = Color.red;
        bool secondPassed = Time.time - Mathf.RoundToInt(Time.time) > 0.1f;
        if (secondPassed)
        {
            TimeText.fontSize = 140;
            TimerBeep.PlayDelayed(0.1f);
        }
    }
    
    private void TimeIsUp()
    {
        LevelFailAudio.PlayOnce();
        TimeText.text = "00" + ":" + "00";
        TimeManager.TimeIsOver = true;
    }

    void UpdateChronometer()
    {
        RemainingTime += Time.deltaTime;
        Chronometer.fillAmount = RemainingTime / levelTime;
    }
}