using UnityEngine;
using Assets.Scripts.Controllers;

public class ProfitTask : MonoBehaviour
{
    float profitGoal = 50;
    public GameObject LevelClearedScreen;
    public AudioSource LevelClearedAudio;
    public AudioSource TaskClearedAudio;
    AudioPlayer levelClearedAudio;
    AudioPlayer taskClearedAudio;
    public static bool NewTask = false;
    public static bool TaskIsComplete;

    public void RestartTask()
    {
        TaskIsComplete = false;
        ProfitAddition.cumulativeProfit = 0;
    }

    void Update()
    {
        CheckNeedToRestartParameters();
        if (ProfitAddition.cumulativeProfit >= profitGoal)
        {
           LevelCleared();
        }
    }

    private void CheckNeedToRestartParameters()
    {
        if (NewTask == true)
        {
            RestartTask();
            NewTask = false;
        }
    }

    private void LevelCleared()
    {
        TaskIsComplete = true;
        gameObject.SetActive(false);
        levelClearedAudio = new AudioPlayer(LevelClearedAudio);
        levelClearedAudio.PlayOnce();
        LevelClearedScreen.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}