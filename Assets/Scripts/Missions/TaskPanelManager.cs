using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Controllers;

public class TaskPanelManager : MonoBehaviour {
    public float profitGoal = 1000;
    public int ClearedTasks;
    public GameObject CellComponentTasks;
    public GameObject VariablePanelsContainer;
    public GameObject LevelClearedScreen;
    public Animator AirButton;
    int totalTasks = 1;
    public AudioSource LevelClearedAudio;
    public AudioSource TaskClearedAudio;
    AudioPlayer levelClearedAudio;
    AudioPlayer TaskCleared;
    public static bool NewTask = false;
    
    private void Start()
    {
       RestartTasks();
    }

    public void RestartTasks()
    {
        ActivateSoundEffects();
        SetPanelsActive(false);
        ClearedTasks = 0;
        RestartTasksUI();
        EraseProfitTasks();
        PrepareAirFlowTask();
    }

    private void ActivateSoundEffects()
    {
        levelClearedAudio = new AudioPlayer(LevelClearedAudio);
        TaskCleared = new AudioPlayer(TaskClearedAudio);
    }

    void Update ()
    {
        CheckNeedToRestartParameters();
        if (ClearedTasks > totalTasks)
        {
            LevelCleared();
        }
        CheckProfitGoal();
    }

    private void CheckNeedToRestartParameters()
    {
        if (NewTask == true)
        {
            RestartTasks();
            NewTask = false;
        }
    }

    private void CheckProfitGoal()
    {
        if (ProfitAddition.cumulativeProfit >= profitGoal)
        {
            TaskCleared.PlayOnce();
            TaskCleared.HasAlreadyPlayed = false;
            ClearedTasks++;
            EraseProfitTasks();
            UpdateTasksTextsAndCheckMarks();
            CallNextProfitTask();
        }
    }

    private void EraseProfitTasks()
    {
        ProfitAddition.cumulativeProfit = 0;
    }

    private void SetPanelsActive(bool Decision)
    {
        for (int i = 0; i < VariablePanelsContainer.transform.childCount; i++)
        {
            VariablePanelsContainer.transform.GetChild(i).gameObject.SetActive(Decision);
        }
    }

    private void UpdateTasksTextsAndCheckMarks()
    {
        if (ClearedTasks <= totalTasks)
        {
            Transform PreviousTask = CellComponentTasks.transform.GetChild(ClearedTasks - 1);
            PreviousTask.GetComponent<TextMeshProUGUI>().color = Color.gray;
            PreviousTask.GetComponentInChildren<Image>().enabled = true;
            ActivateNextTaskText();
        }
    }

    private void ActivateNextTaskText()
    {       
            Transform CurrentTask = CellComponentTasks.transform.GetChild(ClearedTasks);
            CurrentTask.gameObject.SetActive(true);     
    }

    private void CallNextProfitTask()
    {
        if (ClearedTasks < totalTasks)
        {
            CallNextVariablePanel();
        }
        else {
            AllVariablesTask();
        }
    }

    private void CallNextVariablePanel()
    {
        Transform PreviousVariablePanel = VariablePanelsContainer.transform.GetChild(ClearedTasks - 1);
        PreviousVariablePanel.gameObject.SetActive(false);
        Transform CurrentVariablePanel = VariablePanelsContainer.transform.GetChild(ClearedTasks);
        CurrentVariablePanel.gameObject.SetActive(true);
    }

    private void AllVariablesTask()
    {
        SetPanelsActive(true);
        StopAirFlowButtonAnimation();
    }

    private void StopAirFlowButtonAnimation()
    {
        AirButton.SetTrigger("NotActive");
    }

    private void LevelCleared()
    {
        gameObject.SetActive(false);
        levelClearedAudio.PlayOnce();
        LevelClearedScreen.SetActive(true);
    }

    private void RestartTasksUI()
    {
        for (int i = 0; i <= CellComponentTasks.transform.childCount - 1; i++)
        {
            Transform PreviousTask = CellComponentTasks.transform.GetChild(i);
            PreviousTask.GetComponent<TextMeshProUGUI>().color = Color.white;
            PreviousTask.GetComponentInChildren<Image>().enabled = false;
            PreviousTask.gameObject.SetActive(false);
        }
    }

    private void PrepareAirFlowTask()
    {
        VariablePanelsContainer.transform.GetChild(0).gameObject.SetActive(true);
        Transform AirFlowTaskText = CellComponentTasks.transform.GetChild(0);
        AirFlowTaskText.gameObject.SetActive(true);
    }
}
