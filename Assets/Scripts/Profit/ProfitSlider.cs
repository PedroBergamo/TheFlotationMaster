using UnityEngine;
using UnityEngine.UI;

public class ProfitSlider : MonoBehaviour {
    Slider slider;

	void Start () {
        slider = GetComponent<Slider>();
	}

	void Update () {
        slider.value = ProfitAddition.cumulativeProfit;
	}
}
