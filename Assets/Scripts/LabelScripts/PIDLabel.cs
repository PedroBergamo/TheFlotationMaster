using UnityEngine;
using TMPro;

public class PIDLabel : MonoBehaviour {
    public PID Variable;
    public bool SetPoint;
    public bool ProcessValue;
    public bool negativeValue;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        if (SetPoint)
        {
            textMeshPro.text = sign() + Variable.SetPoint.ToString();
        }
        else if (ProcessValue) {
            textMeshPro.text = sign() + Mathf.Round(Variable.ProcessValue).ToString();
        }
    }

    string sign(){
        if (negativeValue) {
            return "-";            
        }
        return "";
    }

}
