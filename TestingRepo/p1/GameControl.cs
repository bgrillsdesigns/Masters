using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject winText;

    public Camera Puzzle_Camera;
    public Camera Main_Camera;
    public static bool youWin;
    bool pic2, pic3, pic3alt, pic4, pic5, pic5alt, pic7, pic8;

    public GameObject key;
    public GameObject sink;
    public GameObject puzzle;

    void Start()
    {
        // Main_Camera.gameObject.SetActive(true);
        int num = Random.Range(1, 4);

        num = num * 90;

        pictures[0].transform.Rotate(0, 0, num, Space.Self);
        pictures[1].transform.Rotate(0, 0, num, Space.Self);
        pictures[2].transform.Rotate(0, 0, num, Space.Self);
        pictures[3].transform.Rotate(0, 0, num, Space.Self);
        pictures[4].transform.Rotate(0, 0, num, Space.Self);
        pictures[5].transform.Rotate(0, 0, num, Space.Self);
        pictures[6].transform.Rotate(0, 0, num, Space.Self);
        pictures[7].transform.Rotate(0, 0, num, Space.Self);
        pictures[8].transform.Rotate(0, 0, num, Space.Self);

        Cursor.lockState = CursorLockMode.None;
        winText.SetActive(false);
        youWin = false;
    }


    // update once per frame
    void Update()
    {
        if (pictures[2].rotation.eulerAngles.z == 0)
        {
            pic2 = true;
        }
        if (pictures[3].rotation.eulerAngles.z == 0)
        {
            pic3 = true;
        }
        if (pictures[3].rotation.eulerAngles.z == 180)
        {
            pic3alt = true;
        }
        if (pictures[4].rotation.eulerAngles.z == 0)
        {
            pic4 = true;
        }
        if (pictures[5].rotation.eulerAngles.z == 0)
        {
            pic5 = true;
        }
        if (pictures[5].rotation.eulerAngles.z == 180)
        {
            pic5alt = true;
        }
        if (pictures[7].rotation.eulerAngles.z == 0)
        {
            pic7 = true;
        }
        if (pictures[8].rotation.eulerAngles.z == 0)
        {
            pic8 = true;
        }

        if (pic2 && pic3 && pic4 && pic5 && pic7 && pic8)
        {
            youWin = true;
            winText.SetActive(true);
            Main_Camera.gameObject.SetActive(true);
            Puzzle_Camera.gameObject.SetActive(false);
            winText.SetActive(false);
            Time.timeScale = 1f;

            key.SetActive(true);
            key.GetComponent<SpawnItemEvent>().SpawnItemKey();
            sink.GetComponent<BoxCollider>().enabled = false;
            puzzle.SetActive(false);
            
        }

        if (pic2 && pic3alt && pic4 && pic5 && pic7 && pic8)
        {
            youWin = true;
            winText.SetActive(true);
            Main_Camera.gameObject.SetActive(true);
            Puzzle_Camera.gameObject.SetActive(false);
            winText.SetActive(false);
            Time.timeScale = 1f;

            key.SetActive(true);
            key.GetComponent<SpawnItemEvent>().SpawnItemKey();
            sink.GetComponent<BoxCollider>().enabled = false;
            puzzle.SetActive(false);

        }

        if (pic2 && pic3 && pic4 && pic5alt && pic7 && pic8)
        {
            youWin = true;
            winText.SetActive(true);
            Main_Camera.gameObject.SetActive(true);
            Puzzle_Camera.gameObject.SetActive(false);
            winText.SetActive(false);
            Time.timeScale = 1f;

            key.SetActive(true);
            key.GetComponent<SpawnItemEvent>().SpawnItemKey();
            sink.GetComponent<BoxCollider>().enabled = false;
            puzzle.SetActive(false);

        }

        if (pic2 && pic3alt && pic4 && pic5alt && pic7 && pic8)
        {
            youWin = true;
            winText.SetActive(true);
            Main_Camera.gameObject.SetActive(true);
            Puzzle_Camera.gameObject.SetActive(false);
            winText.SetActive(false);
            Time.timeScale = 1f;

            key.SetActive(true);
            key.GetComponent<SpawnItemEvent>().SpawnItemKey();
            sink.GetComponent<BoxCollider>().enabled = false;
            puzzle.SetActive(false);

        }
    }
}

// other ways of doing it.

//if (pictures[2].rotation.eulerAngles.z == 0 &&
//    (pictures[3].rotation.eulerAngles.z == 0 || pictures[3].rotation.eulerAngles.z == 180) &&
//    pictures[4].rotation.z == 0 &&
//    (pictures[5].rotation.eulerAngles.z == 0 || pictures[5].rotation.eulerAngles.z == 180) &&
//    pictures[7].rotation.z == 0 &&
//    pictures[8].rotation.z == 0)
//{
//    Debug.Log("win");
//    youWin = true;
//    winText.SetActive(true);
//    Main_Camera.gameObject.SetActive(true);
//    Puzzle_Camera.gameObject.SetActive(false);
//    winText.SetActive(false);
//    //string sceneName = PlayerPrefs.GetString("NewMansion");
//    // SceneManager.LoadScene(sceneName);
//}
//}


//Debug.Log("here1");
//    if (pictures[3].rotation.eulerAngles.z == 0 || pictures[3].rotation.eulerAngles.z == 180)
//    {
//        Debug.Log("here2");
//        if (pictures[4].rotation.z == 0)
//        {
//            if (pictures[5].rotation.eulerAngles.z == 0 || pictures[5].rotation.eulerAngles.z == 180)
//            {
//                if (pictures[7].rotation.z == 0)
//                {
//                    if (pictures[8].rotation.z == 0)
//                    {
//                        youWin = true;
//                        string sceneName = PlayerPrefs.GetString("NewMansion");
//                        SceneManager.LoadScene(sceneName);
//                        winText.SetActive(true);
//                    }
//                }
//            }
//        }
//    }