using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public GameObject continueButton;
    public bool readyToContinue = false; 

    public void Start()
    {
        string sceneToLoad = PlayerPrefs.GetString("sceneToLoad");
        Debug.Log(sceneToLoad);
//commented out code was ommited here 
//commented out code was ommited here 
        StartCoroutine(LoadAsynchronously(sceneToLoad)); 
    }  

    public void Continue()
    {
        readyToContinue = true; 
    }

    IEnumerator LoadAsynchronously (string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        float progress = 0;

        //!operation.isDone
        while ( progress != 1)
        {
            progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            progressText.text = progress * 100f + "%"; 
            yield return null;
        }

        continueButton.SetActive(true); 

        while(!readyToContinue)
        {
            yield return null; 
        }

        operation.allowSceneActivation = true; 
    }
}
