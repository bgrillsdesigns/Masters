using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public GameObject ic;


    public void UpdateSlot()
    {
        if(Inventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            ic.GetComponentsInChildren<Image>()[1].sprite = Inventory.instance.itemList[transform.GetSiblingIndex()].icon;
            ic.SetActive(true);
        }   
        else
        {
            ic.SetActive(false);
        }
    }	
}
