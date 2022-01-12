using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InstructionsManager : MonoBehaviour {

    public float TypingSpeed = 0.03f;
    public string MissionName;
    public int InstructionsIndex = 0;
    private Coroutine lastRoutine = null;
    public TextMeshProUGUI TMPRO;
    public GameObject InstructionsButton;
    private List<GameObject> CreatedButtons;
    public static int GivenAnswer = 1;
    private List<Instruction> SetOfInstructions;
    public GameObject LevelClearedMenu;
    public AudioSource AchievementAudio;
    public AudioSource LevelClearedAudio;
    public Canvas TaskMenu;
    public Canvas TaskCanvas;
    public GameObject JobsButton;

    private void StartExercise()
    {
        CreatedButtons = new List<GameObject>();
        CallInstruction();
        EnableAnimators(false);
    }

    IEnumerator SlowType(string Text)
    {
        foreach (char letter in Text.ToCharArray())
        {
            TMPRO.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
        }
        TMPRO.text = Text;
        GenerateButtons();
      }

    IEnumerator TryAgainText()
    {
        DestroyDynamicGameObjects(CreatedButtons);
        TMPRO.text  = "Wrong Answer. Try again!";
        yield return new WaitForSeconds(2);
        CallInstruction();
    }

    public void CheckIfRightAnswer() {
        if (GivenAnswer == SetOfInstructions[InstructionsIndex].CorrectOption)
        {
            AchievementAudio.Play();
            NextText();
            GivenAnswer = 0;
        }
        else
        {
            lastRoutine = StartCoroutine(TryAgainText());
        }
    }

    public void NextText()
    {
        if (InstructionsIndex < SetOfInstructions.Count - 1)
        {
            InstructionsIndex++;
            CallInstruction();
        }
        else
        {
            LevelClearedMenu.SetActive(true);
            LevelClearedAudio.Play();
            JobsButton.SetActive(true);
            TaskMenu.enabled = true;
            TaskCanvas.enabled = false;
            DestroyDynamicGameObjects(CreatedButtons);
        }
    }

    private void CallInstruction()
    {
        TMPRO.text = SetOfInstructions[InstructionsIndex].Text;
        GenerateButtons();
    }

    public void TextBoxClicked() {
        StopCoroutine(lastRoutine);
        TMPRO.text = SetOfInstructions[InstructionsIndex].Text;
       }

    public void GiveMissionName(string missionName) {
        JobsButton.SetActive(false);
        InstructionsIndex = 0;
        MissionName = missionName;
        SetOfInstructions = GetInstructions();
        StartExercise();
    }

    private List<Instruction> GetInstructions()
    {
        string InstructionName = "Instructions/" + MissionName;
        List<Instruction> instructions = new InstructionsReader().SetOfInstructions(Resources.Load<TextAsset>(InstructionName).text).InstructionsList;
        return instructions;
    }

    private void EnableAnimators(bool AreEnabled) {
        foreach (Animator animator in SetOfInstructions[InstructionsIndex].Animators) {
            animator.SetBool("Active", AreEnabled);
        }
    }

    private void GenerateButtons()
    {
        DestroyDynamicGameObjects(CreatedButtons);
        if (SetOfInstructions[InstructionsIndex].Options[0] != "") {
            InstructionsButton.SetActive(true);
            CreateButtons();
            InstructionsButton.SetActive(false);
        }
    }

    private void CreateButtons()
    {
        Instruction CurrentInstruction = GetInstructions()[InstructionsIndex];
        foreach (string Option in CurrentInstruction.Options)
        {
            GameObject NewButton = Instantiate(InstructionsButton);
            NewButton.transform.SetParent(InstructionsButton.transform.parent, false);
            NewButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Option;
            CreatedButtons.Add(NewButton);
        }
    }

    private void DestroyDynamicGameObjects(List<GameObject> ListOfObjects) {
        foreach (GameObject DynamicObject in ListOfObjects) {
            Destroy(DynamicObject);
        }
    }
}
