using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ 
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public static bool CamStop = false;
    //Capsule.GetComponent<Camera_Mouse_Look>;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
               
                Resume();  // Time.timeScale = 0f



            }
            else
            {
                Pause();

            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        CamStop = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        CamStop = true;
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("NewMansion");  // Change the " " what scence it needs to be restarted to.
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public static bool PauseCam()
    {
        return CamStop;

    }

}