using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private Scene currentScene;


    void OnTriggerEnter(Collider other)
    {
        string pathToScene = SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
        PlayerPrefs.SetString("sceneToLoad", sceneName);
        //PlayerPrefs.SetString("sceneToLoad", SceneManager.GetActiveScene().name);
            //currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("deathScreen");

    }


}
