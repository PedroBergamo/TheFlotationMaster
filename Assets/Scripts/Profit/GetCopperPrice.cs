using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using System;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class GetCopperPrice : MonoBehaviour
{
    public TextMeshProUGUI TMPRO;
    public float CopperPrice = 9664;
    public double TwoPercentCopperPrice = 193;
    public CumulativeConcentrateLabel FinalStreamTons;
    public TextMeshProUGUI Credits;
    public AudioSource MoneyAudio;


    void Start()
    {
        TMPRO = GetComponent<TextMeshProUGUI>();
        StartCoroutine(GetRequest("https://markets.businessinsider.com/commodities/copper-price"));
    }

    private void Update()
    {
        if(FlotationCalculation.NextSamplingIsReady){
            if (UnityEngine.Random.value > 0.5f)
            {
                CopperPrice += UnityEngine.Random.value * (CopperPrice * 0.01f);
            }
            else {
                CopperPrice -= UnityEngine.Random.value * (CopperPrice * 0.01f);
            };
        }
        TwoPercentCopperPrice = Math.Round(CopperPrice * 0.02, 1);

        TMPRO.text = "Ore price: " + TwoPercentCopperPrice.ToString() + "C per ton";
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    UpdateCopperPrice(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    private void UpdateCopperPrice(string input) {
        string search = "<span class=\"price-section__current-value\">";
        int p = input.IndexOf(search);
        if (p >= 0)
        {
            // move forward to the value
            int start = p + search.Length;
            // now find the end by searching for the next closing tag starting at the start position, 
            // limiting the forward search to the max value length
            int end = input.IndexOf("</span>", start);
            if (end >= 0)
            {
                string v = input.Substring(start, end - start);
                float value = float.Parse(v);
                CopperPrice = value;
            }
            else
            {
                Debug.Log("Bad html - closing tag not found");
            }
        }
        else
        {
            Debug.Log("value span not found");
        }
    }

    public void SellOre() {
        float CurrentCredits = float.Parse(Credits.text);
        Credits.text = (Math.Round(CurrentCredits + (FinalStreamTons.CumulativeConcentrate * TwoPercentCopperPrice))).ToString();
        PlayAudio();
        FinalStreamTons.CumulativeConcentrate = 0;

    }

    private void PlayAudio() {
        if (FinalStreamTons.CumulativeConcentrate > 0) {
            MoneyAudio.Play();
        }
    }
}