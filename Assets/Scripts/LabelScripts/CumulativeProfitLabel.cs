using UnityEngine;
using TMPro;

public class CumulativeProfitLabel : MonoBehaviour {
    TextMeshProUGUI TMPRO;

    private void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
    }

    void Update () {
            TMPRO.text = "C" + ProfitAddition.cumulativeProfit;
        }
    }

