using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableController : MonoBehaviour
{
   public float AddedValue;

    void OnMouseDown()
    {
        GetComponentInParent<VariableHandling>().Variable += AddedValue;
    }
}
