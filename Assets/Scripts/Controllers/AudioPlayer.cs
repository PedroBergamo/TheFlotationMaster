using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class AudioPlayer
    {
        public bool HasAlreadyPlayed = false;
        AudioSource audio;

        public AudioPlayer(AudioSource Audio) {
            audio = Audio;
        }

        public void PlayOnce()
        {
            if (!HasAlreadyPlayed)
            {
                audio.PlayDelayed(0.1f);
                HasAlreadyPlayed = true;
            }
        }
    }
}
