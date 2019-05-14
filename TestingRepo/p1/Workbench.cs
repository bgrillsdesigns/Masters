using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public GameObject SpawnScrap;

    public GameObject FPSgun;

    public GameObject scrap1;
    public GameObject scrap2;
    public GameObject scrap3;

    public GameItems Weapon1;
    public GameItems Weapon2;
    public GameItems Weapon3;

    private static bool Scrap1found = false;
    private static bool Scrap2found = false;
    private static bool Scrap3found = false;

    private static bool found = false;

    void Start()
    {
        SpawnScrap.GetComponent<BoxCollider>().enabled = false;
        SpawnScrap.SetActive(false);

        scrap1.SetActive(false);
        scrap2.SetActive(false);
        scrap3.SetActive(false);

        FPSgun.SetActive(false);
    }

    public void SpawnItemScrap()
    {
        SpawnScrap.SetActive(true);
        SpawnScrap.GetComponent<BoxCollider>().enabled = true;
        GetComponent<SphereCollider>().enabled = false;
        
    }

    public void FoundPart(int i)
    {
        if (Inventory.instance.itemList[i] == Weapon1)
        {
            scrap1.SetActive(true);
            Scrap1found = true;
            Debug.Log("weapon1");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();
            
        }
        else if (Inventory.instance.itemList[i] == Weapon2)
        {
            scrap2.SetActive(true);
            Scrap2found = true;
            Debug.Log("weapon2");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();

        }
        else if (Inventory.instance.itemList[i] == Weapon3)
        {
            scrap3.SetActive(true);
            Scrap3found = true;
            Debug.Log("weapon3");
            Inventory.instance.DisplayMessage(i, false);
            Inventory.instance.itemList[i] = null;
            Inventory.instance.UpdateSlotUI();

        }

    }

    public void isSolved()
    {
        if (Scrap1found == true && Scrap2found == true && Scrap3found == true)
            SpawnItemScrap();
    }

    public bool Use_Weapon_Scrap()
    {
        if (Inventory.instance.itemList.Length > 0)
        {
            for (int i = 0; i < Inventory.instance.itemList.Length; i++)
            {
                //if (Inventory.instance.itemList[i] == itm)
                if (Scrap1found && Scrap2found && Scrap3found)
                {
                    found = true;
                    SpawnItemScrap();
                    Inventory.instance.DisplayMessage(i, false);
                    Inventory.instance.itemList[i] = null;
                }
            }
        }

        if (found == true)
        {
            SpawnItemScrap();
        }

        return found;
    }

    public bool WorkbenchSolve()
    {
        if (Inventory.instance.itemList.Length > 0)
        {
            GameItems gunscrap;
            for (int i = 0; i < Inventory.instance.itemList.Length; i++)
            {
                gunscrap = Inventory.instance.itemList[i];
                if (gunscrap == Weapon1 || gunscrap == Weapon2 || gunscrap == Weapon3)
                {
                    FoundPart(i);
                    return true;

                }
            }
        }
        return false;
    }
}
