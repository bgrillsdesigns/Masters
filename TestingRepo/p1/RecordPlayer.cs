using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour {

    // Disks on record player
    public GameObject Record1;
    public GameObject Record2;
    public GameObject Record3;
    public GameObject Record4;
    public GameObject Record5;

    //Choosing record 4 gives key
    public GameObject WinKey;

    // Win or lose sounds
    public AudioClip WinSound;
    public AudioSource LoseSound;

    // Inventory items
    public GameItems Record1_Inv;
    public GameItems Record2_Inv;
    public GameItems Record3_Inv;
    public GameItems Record4_Inv;
    public GameItems Record5_Inv;

    // Use this for initialization
    void Start ()
    {
        LoseSound = GetComponent<AudioSource>();
        Record1.SetActive(false);
        Record2.SetActive(false);
        Record3.SetActive(false);
        Record4.SetActive(false);
        Record5.SetActive(false);
        WinKey.SetActive(false);
    }


    public void FoundPart(int i)
    {
        if (Inventory.instance.itemList[i] == Record1_Inv)
        {
            LoseSound.Play();
            Record1.SetActive(true);
            Debug.Log("Record1");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();
            StartCoroutine(Wait(Record1));

        }
        else if (Inventory.instance.itemList[i] == Record2_Inv)
        {
            LoseSound.Play();
            Record2.SetActive(true);
            Debug.Log("Record2");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();
            StartCoroutine(Wait(Record2));

        }
        else if (Inventory.instance.itemList[i] == Record3_Inv)
        {
            LoseSound.Play();
            Record3.SetActive(true);
            Debug.Log("Record3");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();
            StartCoroutine(Wait(Record3));

        }
        else if (Inventory.instance.itemList[i] == Record4_Inv)
        {
            //
            // WIN
            //
            gameObject.GetComponent<AudioSource>().PlayOneShot(WinSound);
            Record4.SetActive(true);
            Debug.Log("Record4");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();
            WinKey.SetActive(true);

        }
        else if (Inventory.instance.itemList[i] == Record5_Inv)
        {
            LoseSound.Play();
            Record5.SetActive(true);
            Debug.Log("Record5");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();
            StartCoroutine(Wait(Record5));
        }
    }

    public bool RecordPlayerSolve()
    {
        if (Inventory.instance.itemList.Length > 0)
        {
            GameItems records;
            for (int i = 0; i < Inventory.instance.itemList.Length; i++)
            {
                records = Inventory.instance.itemList[i];
                if (records == Record1_Inv || records == Record2_Inv || records == Record3_Inv || records == Record4_Inv || records == Record5_Inv)
                {
                    FoundPart(i);
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator Wait(GameObject Record)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Wait ova");
        Record.SetActive(false);

    }
}
