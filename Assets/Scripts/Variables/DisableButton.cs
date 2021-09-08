using UnityEngine;
using Assets.Scripts.Controllers;

public class DisableButton : MonoBehaviour {
    public PID VariableToBeChecked;
    public bool DontCheckForMax;
    public bool DontCheckForMin;
    DisableButtonController disableButtonController;

    void Start() {
        disableButtonController = new DisableButtonController();
        disableButtonController.DontCheckForMax = DontCheckForMax;
        disableButtonController.DontCheckForMin = DontCheckForMin;
        disableButtonController.variable = VariableToBeChecked.pIDController;
    }

    void Update () {
        if(disableButtonController.variable == null)
        {
            disableButtonController.variable = VariableToBeChecked.pIDController;
        }
        if (!disableButtonController.IsOutOfLimits())
        {
            GetComponent<Animator>().enabled = false;
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            GetComponent<Animator>().enabled = true;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}


