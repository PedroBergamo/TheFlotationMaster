using UnityEngine;
using UnityEngine.UI;

public class ButtonFilling : MonoBehaviour {

    public PID Variable;
	
	void Update () {
        float fillAmount = (Variable.ProcessValue - Variable.MinValue) / (Variable.MaxValue - Variable.MinValue);
        GetComponent<Image>().fillAmount = fillAmount;
    }
}