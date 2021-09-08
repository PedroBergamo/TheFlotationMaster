using UnityEngine;
using UnityEngine.Video;

public class IntroPlayer : MonoBehaviour {
    public GameObject MenuCanvas;
    public bool PlayIntroVideoEverytime;
    private VideoPlayer videoPlayer;

    public void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        if (PlayerPrefs.GetString("IntroHasPlayed") == "true" && !PlayIntroVideoEverytime)
        {
            ActivateMenuCanvas();
        }
    }

    public void LateUpdate()
    {        
        if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
        {
            ActivateMenuCanvas();
            PlayerPrefs.SetString("IntroHasPlayed", "true");
        }
    }

    public void ActivateMenuCanvas() {
        videoPlayer.enabled = false;
        MenuCanvas.SetActive(true);
    }

    public void SetMuteOn(bool MuteOn) {
        videoPlayer.SetDirectAudioMute(0, MuteOn);
    }
}
