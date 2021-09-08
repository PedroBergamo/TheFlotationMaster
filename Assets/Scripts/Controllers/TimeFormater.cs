using UnityEngine;

public class TimeFormater {
    int minutes;
    int seconds;
    public int EndingTime;

    public string FormattedTime(float totalTime) {
        minutes = Mathf.FloorToInt(totalTime / 60f);
        seconds = Mathf.RoundToInt(totalTime % 60f);
        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }   
}
