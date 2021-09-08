using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewManager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject GameCanvas;

    private void GoToProcessView(){
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
    }
}