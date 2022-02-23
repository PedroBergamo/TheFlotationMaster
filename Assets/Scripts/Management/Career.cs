using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Career : MonoBehaviour
{
    public Rank[] Hierarchy;
    public TextMeshProUGUI title;
    public TextMeshProUGUI CurrentXPText;
    public TextMeshProUGUI XPNeeded;
    public float CurrentXP;
    public int Level;
    public AudioSource GoodJobSound;

    void Start()
    {
        Level = 0;
        buildHierarchy();
        CurrentXP = 0;  
    }

    private void buildHierarchy() {
        Hierarchy = new Rank[10];
        Hierarchy[0] = new Rank("Rookie", 0);
        Hierarchy[1] = new Rank("Novice", 300);
        Hierarchy[2] = new Rank("Competant", 900);
        Hierarchy[3] = new Rank("Skilled", 2500);
        Hierarchy[4] = new Rank("Advanced", 6400);
        Hierarchy[5] = new Rank("Expert", 13000);
        Hierarchy[6] = new Rank("Master", 21000);
        Hierarchy[7] = new Rank("Superior", 32000);
        Hierarchy[8] = new Rank("Veteran", 48000);
        Hierarchy[9] = new Rank("Legend", 60000);
    }

    public void SetUpTexts() {
        title.text = Hierarchy[Level].Position + " Operator";
        XPNeeded.text = "/ " + Hierarchy[Level+1].XPNeeded.ToString();
    }

    public void AddXP(float amount) {
        CurrentXP += amount * 1000;
        float xp = (float)Math.Round(CurrentXP);
        CurrentXPText.text = xp.ToString();
        if (CurrentXP >= Hierarchy[Level+1].XPNeeded && Level < 9) {
            Level++;
            SetUpTexts();
            GoodJobSound.Play();
        }
    }
}
