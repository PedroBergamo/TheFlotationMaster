using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableHandling : MonoBehaviour {

    public float Variable;
    public string VariableUnit;
    public bool SmallRandomness;
    private int nextUpdate = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SmallRandomness) {
            AddRandomness();
        }
        GetComponent<Text>().text = Variable + " " + VariableUnit;
    }

    void AddRandomness()
    {
        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            GenerateRandomNumber();
        }
    }

    void GenerateRandomNumber()
    {
        float SmallNumber = (Variable * 0.05f);
        Variable = Variable + Random.Range((SmallNumber * -1), SmallNumber);
    }
}
