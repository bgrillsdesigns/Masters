using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour
{

    public GameObject guiObject;
    public string levelToLoad;
    public string levelToLoad2;

    void Start()
    {
        guiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
//commented out code was ommited here 
        int RandomLevelSeed = Random.Range(1, 3); // Every frame chooses scence one or two. Very Random
        Debug.Log(RandomLevelSeed);
        if (other.gameObject.tag == "Player")
        {

            PlayerPrefs.SetString("NewMansion", SceneManager.GetActiveScene().name);

            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {
                if (RandomLevelSeed == 1)
                {
                    SceneManager.LoadScene(levelToLoad);
                }
                if (RandomLevelSeed == 2)
                {
                    SceneManager.LoadScene(levelToLoad); // levelToLoad2
                }
            }
        }
    }


    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}