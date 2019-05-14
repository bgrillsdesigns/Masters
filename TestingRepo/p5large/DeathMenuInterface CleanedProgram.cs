using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMainMenu()
    {
        string pathToScene = SceneUtility.GetScenePathByBuildIndex(0);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
        PlayerPrefs.SetString("sceneToLoad", sceneName);
        Debug.Log(PlayerPrefs.GetString("sceneToLoad"));
        SceneManager.LoadScene("LoadingScreen");
       
    }

    public void LoadCheckpoint()
    {
        Debug.Log(PlayerPrefs.GetString("sceneToLoad")); 
        SceneManager.LoadScene("LoadingScreen");
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
    }
}
