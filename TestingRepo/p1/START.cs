using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class START : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //When play is pressed goes to first active scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }
}
