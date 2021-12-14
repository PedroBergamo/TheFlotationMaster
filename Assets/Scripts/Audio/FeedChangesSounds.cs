using UnityEngine;

public class FeedChangesSounds : MonoBehaviour {
    double PreviousGrade = 15;
    double CurrentGrade;
    private AudioSource Bounce;
    public Stream stream;

    private void Start()
    {
        Bounce = GetComponent<AudioSource>();        
    }

    void Update () {
        CurrentGrade = stream.Grade;
        if (CurrentGrade != PreviousGrade) {
            Bounce.PlayDelayed(0.1f);
            PreviousGrade = CurrentGrade;
        }	
	}
}
