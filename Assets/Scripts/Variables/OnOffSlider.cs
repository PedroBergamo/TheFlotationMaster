using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSlider : MonoBehaviour {
    public GameObject FirstObject;
    public bool HidePanel;

    void Start() {
        if (HidePanel) {
            FirstObject.transform.localScale = new Vector2(0, 0);
        }        
    }

    public void SetOnOff() {
        if (GetComponent<Slider>().value == 0)
        {
            FirstObject.transform.localScale = new Vector2(0,0);
        }
        if (GetComponent<Slider>().value == 1)
        {
            FirstObject.transform.localScale = new Vector2(1, 1);
        }

    }

}
