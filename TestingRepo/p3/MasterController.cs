using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;

public class MasterController : MonoBehaviour
{
    public static MasterController Controller;
    public GameSettings GameSettings;
    public List<string> UnlockedFighters, UnlockedMaps;
    public string Fighter1, Fighter2, MapName, GameMode, Player1InputMethod, Player2InputMethod;
    public GameObject PauseMenu_Prefab;
    private bool isPaused;
    public int score1 = 0;
    public int score2 = 0;

    void Awake()
    {
        if (Controller == null)
        {
            Controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadDataFromJson();
    }

    // Update is called once per frame
    void Update()
    {
        int build = SceneManager.GetActiveScene().buildIndex;
        if (build == 3 || build == 4) //Fight Scene
        {
            //Player presses pause
            if (Input.GetAxisRaw("Pause") > 0 && !isPaused)
            {
                //show pause menu
                isPaused = true;
                var menu = Instantiate(PauseMenu_Prefab);
                menu.transform.SetParent(transform);
                Time.timeScale = 0;
                menu.GetComponent<PauseMenuHandler>().ExitBtn.onClick.AddListener(delegate
                {
                    isPaused = false;
                    SceneManager.LoadScene(0);
                    Destroy(menu);
                });
                menu.GetComponent<PauseMenuHandler>().CancelBtn.onClick.AddListener(delegate
                {
                    isPaused = false;
                    Time.timeScale = 1;
                    Destroy(menu);
                });
            }
        }
    }

    public IEnumerator ChangeScene(int buildIndex)
    {
        if (buildIndex > 2)
        {
            yield return new WaitForSeconds(2f);
        }
        var async = SceneManager.LoadSceneAsync(buildIndex);
        while (!async.isDone)
        {
            yield return null;
        }
    }

    private void ReturnToMainMenu()
    {

    }

    public void LoadDataFromJson()
    {
        var json_string = Resources.Load<TextAsset>("GameData");
        var json_Data = JsonUtility.FromJson<JSON_Game_Data>(json_string.text);

        UnlockedFighters = new List<string>();
        UnlockedFighters.AddRange(json_Data.fighters);
        UnlockedMaps = new List<string>();
        UnlockedMaps.AddRange(json_Data.maps);
    }
}
