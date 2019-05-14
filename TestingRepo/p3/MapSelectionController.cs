using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class MapSelectionController : MonoBehaviour
{
    public GameObject MapSelect_Prefab;
    public GameObject MapSelection_Grid;
    public GameObject firstSelected;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject VsScreen;
    public Image vs1;
    public Image vs2;
    public EventSystem eventSystem;

    private bool setFirst = false;

    // Use this for initialization
    void Start()
    {
        LoadPlayerAnims();
        AddMaps();
    }

    private void AddMaps()
    {
        if (MasterController.Controller.UnlockedMaps.Any())
        {
            foreach (var map in MasterController.Controller.UnlockedMaps)
            {
                InstantiateMap(map);

            }
            InstantiateMap("Random", true);
        }
    }

    private void InstantiateMap(string mapName, bool isLast = false)
    {
        GameObject map;
        if (!setFirst)
        {
            setFirst = true;
            map = firstSelected;
        }
        else{
            map = Instantiate(MapSelect_Prefab);
        }
        string path;
        if (isLast)
        {
            path = Path.Combine("Portraits", "qm");
            map.GetComponent<Button>().onClick.AddListener(
                delegate { SelectMap("random"); }
            );
            map.name = "random";
        }
        else
        {
            path = Path.Combine("Portraits", mapName);
            map.GetComponent<Button>().onClick.AddListener(
                delegate { SelectMap(mapName); }
            );
            map.name = "Option-" + mapName;
        }
        map.GetComponentInChildren<Text>().text = mapName;

        var sp = Resources.Load<Sprite>(path);
        if (sp != null)
        {
            map.GetComponent<Image>().sprite = sp;
        }
        else
        {
            Debug.Log("Unable to load file at: " + path);
        }
        map.transform.SetParent(MapSelection_Grid.transform);
    }

    public void SelectMap(string name)
    {
        if (MasterController.Controller.MapName == "" ||
            MasterController.Controller.MapName != name)
        {
            Debug.Log("Selected " + name + "!");
            if (name == "random")
            {
                UnityEngine.Random.InitState((int)Time.time * 100);
                int rand = UnityEngine.Random.Range(0,
                MasterController.Controller.UnlockedMaps.Count);
                name = MasterController.Controller.UnlockedMaps[rand];
                Debug.Log("Random Map - " + name);
            }
            //Set map in master controller
            MasterController.Controller.MapName = name;

            //set bg image
            string path = Path.Combine("Portraits", name);
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        }
        else
        {
            Debug.Log("Already Selected!");
        }
    }
    public void GoBack()
    {
        var co = StartCoroutine(MasterController.Controller.ChangeScene(1));
    }

    public void StartMatch()
    {
        VsScreen.SetActive(true);
        LoadFightScene();
    }

    private void LoadPlayerAnims()
    {
        if (MasterController.Controller.Fighter1 != "")
        {
            string fighterName = MasterController.Controller.UnlockedFighters.Find(x =>
                 x == MasterController.Controller.Fighter1);
            var fl = Path.Combine("Fighters", fighterName);
            var f_base = Resources.Load<FighterBase>(fl);
            var anim = f_base.UI_Animation;
            if (anim != null)
            {
                Player1.GetComponent<Animator>().runtimeAnimatorController = anim;
            }
            else
            {
                Debug.Log("Unable to load file at: " + fl);
            }

            //Load vs screen
            var file = Path.Combine("FightPorts", "Fight_" + "P1_" + fighterName);
            vs1.sprite = Resources.Load<Sprite>(file);
            Debug.Log("Loaded VS File " + file);
        }
        if (MasterController.Controller.Fighter2 != "")
        {
            string fighterName = MasterController.Controller.UnlockedFighters.Find(x =>
                 x == MasterController.Controller.Fighter1);
            var fl = Path.Combine("Fighters", fighterName);
            var f_base = Resources.Load<FighterBase>(fl);
            var anim = f_base.UI_Animation;
            if (anim != null)
            {
                Player2.GetComponent<Animator>().runtimeAnimatorController = anim;
                Player2.transform.Rotate(0f, 180f, 0f);
            }
            else
            {
                Debug.Log("Unable to load file at: " + fl);
            }

            //Load vs screen
            var file = Path.Combine("FightPorts", "Fight_" + "P2_" + fighterName);
            vs2.sprite = Resources.Load<Sprite>(file);
            Debug.Log("Loaded VS File " + file);
        }
    }

    private void LoadFightScene()
    {
        int scene = 0;
        if (MasterController.Controller.GameMode == "Versus")
        {
            scene = 3;
        }
        if (MasterController.Controller.GameMode == "Arcade")
        {
            scene = 4;
        }

        var co = MasterController.Controller.ChangeScene(scene);
        StartCoroutine(co);
    }
}
