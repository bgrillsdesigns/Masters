using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class MainMenu : MonoBehaviour {

    public void LoadGame(string mode)
    {
        if (mode == "new")
        {
            PlayerPrefs.SetInt("NewGame", 1);
            PlayerPrefs.SetString("sceneToLoad", "Trench-Pillbox");
            PlayerPrefs.SetInt("Tutorial", 0);
        }
        else
            PlayerPrefs.SetInt("NewGame", 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void Start()
    {
        if (GameObject.Find("FPSController"))
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;

    }

    public void ExitGame()
    {
        Debug.Log("Exit Application"); 
        Application.Quit();
    }
}
