using UnityEngine;

public class FeedChangesSounds : MonoBehaviour {
    float PreviousGrade = 15;
    float CurrentGrade;
    private AudioSource Bounce;

    private void Start()
    {
        Bounce = GetComponent<AudioSource>();        
    }

    void Update () {
        CurrentGrade = FlotationCalculation.Controller.FeedAsGrade;
        if (CurrentGrade != PreviousGrade) {
            Bounce.PlayDelayed(0.1f);
            PreviousGrade = CurrentGrade;
        }	
	}
}
