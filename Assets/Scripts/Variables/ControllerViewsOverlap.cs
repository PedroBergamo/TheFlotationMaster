using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerViewsOverlap : MonoBehaviour {

    public GameObject ThisController;
    public GameObject DesactivateController1;
    public GameObject DesactivateController2;

    public void ChangePanels() {
        DesactivateController1.SetActive(false);
        DesactivateController2.SetActive(false);
        ThisController.SetActive(true);
    }
}
