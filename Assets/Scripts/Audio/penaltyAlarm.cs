using System.Collections;
using UnityEngine;

public class penaltyAlarm : MonoBehaviour {
    AudioSource Alert;
    
    private void Start()
    {
        Alert = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GradeLabel.ThereIsPenalty || GradeLabel.ThereIsPenalty)
        {
            PlayAlert();
        }
    }

    private void PlayAlert()
    {
        bool secondPassed = Time.time - Mathf.RoundToInt(Time.time) > 0.1f;
        if (secondPassed)
        {
            Alert.PlayDelayed(0.1f);
        }
    }
}
