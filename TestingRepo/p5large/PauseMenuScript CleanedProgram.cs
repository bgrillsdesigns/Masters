using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuScript : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuInterface, HUD_Interface, helpInterface,settingsInterface;
    private GameObject firstPerson;
//commented out code was ommited here 
    public GameObject Puzzle_HUD;
    private Scene currentScene;
    private GameObject player;

    private void Awake()
    {
        firstPerson = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
//commented out code was ommited here 
//commented out code was ommited here 
    }

    // Update is called once per frame
    void Update () {

        
        if (Input.GetButtonDown("Escape"))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause(); 
            }
        }
	}

    public void Resume()
    {
        pauseMenuInterface.SetActive(false);
        helpInterface.SetActive(false);
        settingsInterface.SetActive(false); 
        HUD_Interface.SetActive(true);
        //GameObject firstPerson = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(firstPerson.name);
        if (!Puzzle_HUD.activeInHierarchy)
        firstPerson.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        isPaused = false; 
    }

    void Pause()
    {
        //GameObject firstPerson = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(firstPerson.name);
        pauseMenuInterface.SetActive(true);
        HUD_Interface.SetActive(false);
        firstPerson.GetComponent<FirstPersonController>().enabled = false; 
        Time.timeScale = 0f;
        isPaused = true; 
    }

    public void LoadMainMenu()
    {
        pauseMenuInterface.SetActive(false);
        helpInterface.SetActive(false);
        settingsInterface.SetActive(false);
        HUD_Interface.SetActive(true);
        firstPerson.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadControlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Controls");
    }
    public void LoadSettingMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Settings");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void RestartLevel()
    {
        //currentScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(currentScene.name);

        firstPerson.GetComponent<Save>().ReloadLastCheckpoint();

        Debug.Log("Restart");
        Resume();
    }
}
