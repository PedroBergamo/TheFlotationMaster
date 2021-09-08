
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour {
    Slider slider;
    public PID PID;

    void Start() {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = PID.ProcessValue;
    }
}
