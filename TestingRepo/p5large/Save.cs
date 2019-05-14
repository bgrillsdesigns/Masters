using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Save : MonoBehaviour
{
    public GameObject player;
    private Transform currentCheckpoint;
    public static Save saveData;

    Resolution[] resolutions;

    void Awake()
    {
        if (PlayerPrefs.GetInt("NewGame") == 0)
            LoadGame();
    }

    public void Start()
    {
        //Create new setting if no settings
        if (saveData == null)
        {
            //Persistant
            DontDestroyOnLoad(gameObject);
            saveData = this;
        }
        //There can be only one
        else if (saveData != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadGame()
    {

        player.transform.position = GetPos();
        player.transform.rotation = GetRot();
        player.GetComponent<Inventory>().count = PlayerPrefs.GetInt("count");
        if (SceneManager.GetActiveScene().name == "Trench-Pillbox")
        {
            GameObject.Find("TutorialController").GetComponent<TutorialController>().doTutorial = PlayerPrefs.GetInt("Tutorial");
            GameObject.Find("TutorialController").GetComponent<TutorialController>().buttonClicked = true;
        }

        GetHolding();
        GetInventory();

        Debug.Log("Game loaded");
    }
    public void SaveGame()
    {
       

        SetPos();
        SetRot();

        PlayerPrefs.SetInt("count", player.GetComponent<Inventory>().count);
        PlayerPrefs.SetString("sceneToLoad", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Tutorial", 2);

        SetHolding();
        SetInventory();
    }
    public void UpdateCheckpoint(GameObject newCheckpoint)
    {
        currentCheckpoint = newCheckpoint.GetComponent<Transform>();

        SaveGame();
    }
    public void ReloadLastCheckpoint()
    {
        player.transform.position = currentCheckpoint.position;
        player.transform.rotation = currentCheckpoint.rotation;
    }

    public void SetPos()
    {
        PlayerPrefs.SetFloat("posX", player.transform.position.x);
        PlayerPrefs.SetFloat("posY", player.transform.position.y);
        PlayerPrefs.SetFloat("posZ", player.transform.position.z);
    }
    public void SetRot()
    {
        PlayerPrefs.SetFloat("rotX", player.transform.rotation.x);
        PlayerPrefs.SetFloat("rotY", player.transform.rotation.y);
        PlayerPrefs.SetFloat("rotZ", player.transform.rotation.z);
        PlayerPrefs.SetFloat("rotW", player.transform.rotation.w);
    }
    public void SetHolding()
    {
        if(GameObject.Find("FPSController").GetComponent<Inventory>().slots[0]!=null)
            PlayerPrefs.SetString("slot0", GameObject.Find("FPSController").GetComponent<Inventory>().slots[0].name);
        if (GameObject.Find("FPSController").GetComponent<Inventory>().slots[1] != null)
            PlayerPrefs.SetString("slot1", GameObject.Find("FPSController").GetComponent<Inventory>().slots[1].name);
    }
    public void SetInventory()
    {
        for (int i = 0; i < player.GetComponent<Inventory>().count; i++)
            PlayerPrefs.SetString("inventory" + i, GameObject.Find("FPSController").GetComponent<Inventory>().list[i]);
    }

    public Vector3 GetPos()
    {
        Vector3 pos;
        pos.x = PlayerPrefs.GetFloat("posX");
        pos.y = PlayerPrefs.GetFloat("posY");
        pos.z = PlayerPrefs.GetFloat("posZ");
        return pos;
    }
    public Quaternion GetRot()
    {
        Quaternion rot;
        rot.x = PlayerPrefs.GetFloat("rotX");
        rot.y = PlayerPrefs.GetFloat("rotY");
        rot.z = PlayerPrefs.GetFloat("rotZ");
        rot.w = PlayerPrefs.GetFloat("rotW");
        return rot;
    }
    public void GetHolding()
    {
        if (PlayerPrefs.GetString("slot0") != "")
            GameObject.Find("FPSController").GetComponent<Inventory>().slots[0] = GameObject.Find(PlayerPrefs.GetString("slot0"));
        if (PlayerPrefs.GetString("slot1") != "")
            GameObject.Find("FPSController").GetComponent<Inventory>().slots[1] = GameObject.Find(PlayerPrefs.GetString("slot1"));
    }
    public void GetInventory()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("count"); i++)
            player.GetComponent<Inventory>().list[i] = PlayerPrefs.GetString("inventory" + i);
    }

    
}
