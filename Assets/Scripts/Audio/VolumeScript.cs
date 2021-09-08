using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {

	void Update () {
        AudioListener.volume = GetComponent<Slider>().value;	           
	}
}
