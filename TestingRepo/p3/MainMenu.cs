using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        AudioManager.instance.Play("MainMenu");
        AudioManager.instance.Mute("Battle");

    }

    public void PlayVersus()
    {
        MasterController.Controller.GameMode = "Versus";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayArcade(){
        MasterController.Controller.GameMode = "Arcade";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayTutorial()
    {
        MasterController.Controller.GameMode = "Tutorial";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
