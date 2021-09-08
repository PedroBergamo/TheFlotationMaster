using UnityEngine;
using TMPro;

public class FinalTimeLabel : MonoBehaviour {
    TimeFormater time;
    TextMeshProUGUI TMPRO;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }
    void Update () {
        time = new TimeFormater();
        TMPRO.text = time.FormattedTime(TimeManager.LevelSeconds);
        Destroy(this);
    }
}
