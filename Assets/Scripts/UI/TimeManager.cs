using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
    public static bool SecondPassed = false;
    public static bool TimeIsOver = false;
    float TimeInSeconds = 1;
    float NextInterval;
    public static int LevelSeconds;

    private void Start()
    {
        NextInterval = TimeInSeconds;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Update()
    {
        CheckForTheTime();
        CountTheSeconds();
    }

    private void CheckForTheTime()
    {
        if (TimeIsOver) {
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void CountTheSeconds()
    {
        SecondPassed = false;
        if (Time.time >= NextInterval)
        {
            NextInterval = Mathf.FloorToInt(Time.time) + (1 / TimeInSeconds);
            SecondPassed = true;
            LevelSeconds++;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
