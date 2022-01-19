using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStream : MonoBehaviour
{
    public GameObject FlotationCircuit;
    Stream ConcentrateStream;

    void Start()
    {
        ConcentrateStream = GetComponent<Stream>();
        GetLastStream();
    }

    public void GetLastStream()
    {
        Transform child = FlotationCircuit.transform.GetChild(transform.childCount - 1);
        Stream lastStream = child.GetComponent<Stream>();
        ConcentrateStream = lastStream;
    }
}
