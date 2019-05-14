using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedTutorial : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Back to Menu");
            FindObjectOfType<TextBoxManager>().GoNextLine();
            Invoke("BacktoMenu", 3f);
        }
    }

    void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
