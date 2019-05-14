using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{

    private string p1 = "";
    private string p2 = "";
    private bool isAI = false;
    public GameObject PlayerPrefab;
    public Transform Spawn1, Spawn2;
    public Transform Fighter1_Transform, Fighter2_Transform;
    public SpriteRenderer Map_Background, Map_ForeGround, Map_Midground, Map_Ground;

    private bool roundEnded = false;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI player1win;
    public TextMeshProUGUI player2win;

    public Canvas UI;
    public Canvas CPlayer1;
    public Canvas CPlayer2;

    public int P1_Score;
    public int P2_Score;


    // Use this for initialization
    void Start()
    {
        //Load in Players
        if (!string.IsNullOrEmpty(MasterController.Controller.Fighter1))
        {
            p1 = MasterController.Controller.Fighter1;
            LoadFighterData(1);
        }
        if (!string.IsNullOrEmpty(MasterController.Controller.Fighter2))
        {
            p2 = MasterController.Controller.Fighter2;
            LoadFighterData(2);
        }
        LoadMapData(MasterController.Controller.MapName);
        AudioManager.instance.Play("Battle", 0.9f);
        AudioManager.instance.Mute("MainMenu");

        LoadScores();
        if (P1_Score == 1)
        {
            player1win.gameObject.SetActive(true);
        }

        if (P2_Score == 1)
        {
            player2win.gameObject.SetActive(true);
        }

        Fighter1_Transform.gameObject.GetComponent<Fighter>().EnemyTransform = Fighter2_Transform;
        Fighter2_Transform.gameObject.GetComponent<Fighter>().EnemyTransform = Fighter1_Transform;
    }
    void LoadFighterData(int player)
    {
        string fighterName = "";
        if (player == 1)
        {
            fighterName = MasterController.Controller.UnlockedFighters.Find(x => x == p1);
        }
        else if (player == 2)
        {
            fighterName = MasterController.Controller.UnlockedFighters.Find(x => x == p2);
            if (MasterController.Controller.Player2InputMethod == "AI")
            {
                isAI = true;
            }
        }
        if (!string.IsNullOrEmpty(fighterName))
        {
            string path = Path.Combine("Fighters", fighterName);
            var FighterData = Resources.Load<FighterBase>(path);

            //Create the Fighter
            GameObject FighterObject;
            FighterObject = Instantiate(PlayerPrefab);
            FighterObject.GetComponent<Fighter>().Base = FighterData;
            FighterObject.GetComponent<Fighter>().PNum = player;
            FighterObject.GetComponent<Fighter>().isAI = isAI;
            //Choose spawn location and rotation
            if (player == 1)
            {
                FighterObject.transform.position = Spawn1.transform.position;
                Fighter1_Transform = FighterObject.transform;
            }
            if (player == 2)
            {
                FighterObject.transform.position = Spawn2.transform.position;
                Fighter2_Transform = FighterObject.transform;
            }
        }
    }

    void LoadMapData(string map)
    {
        string[] map_Parts = new string[4] { "Background", "Foreground", "Midground", "Ground" };
        for (int i = 0; i < map_Parts.Length; ++i)
        {
            string part_file = Path.Combine("Maps", map, map_Parts[i]);
            var LoadedSprite = Resources.Load<Sprite>(part_file);
            if (LoadedSprite != null)
            {
                switch (i)
                {
                    case 0:
                        Map_Background.sprite = LoadedSprite;
                        break;
                    case 1:
                        Map_ForeGround.sprite = LoadedSprite;
                        break;
                    case 2:
                        Map_Midground.sprite = LoadedSprite;
                        break;
                    case 3:
                        Map_Ground.sprite = LoadedSprite;
                        break;
                }
            }
            else
            {
                Debug.Log(string.Format("Could not load File at {0}", part_file));
            }
        }
    }
    public void EndRound()
    {
        if (roundEnded == false)
        {
            roundEnded = true;
            Debug.Log("Score: " + P1_Score + " :" + P2_Score);
            Invoke("RestartRound", 2f);
        }
    }

    void RestartRound()
    {
        SceneManager.LoadScene(4);
        roundEnded = false;
    }

    public void EndMatch()
    {
        P1_Score = 0;
        P2_Score = 0;
        SaveScores();
        Invoke("toMenu", 5f);
    }

    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScores()
    {
        P1_Score = PlayerPrefs.GetInt("P1_Score");
        P2_Score = PlayerPrefs.GetInt("P2_Score");
    }
    public void SaveScores()
    {
        PlayerPrefs.SetInt("P1_Score", P1_Score);
        PlayerPrefs.SetInt("P2_Score", P2_Score);
        PlayerPrefs.Save();
    }

    public void SetScore(int player)
    {
        if (player == 1)
        {
            P1_Score += 1;
        }
        else
        {
            P2_Score += 1;
        }
        SaveScores();

        if (P1_Score >= 2 || P2_Score >= 2)
        {
            int winner = P1_Score >= 2 ? 1 : 2;
            winText.text = string.Format("Player {0} Wins! ", winner);
            UI.gameObject.SetActive(true);
            EndMatch();
        }
        else
        {
            EndRound();
        }
    }
}
