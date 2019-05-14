using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Use_Item : MonoBehaviour
{
    public GameObject obj;
    public GameItems itm;


    private static bool found = false;

    // Use this for initialization
    void Start()
    {
      

    }

    public bool Use_Item_Door()
    {
        if (Inventory.instance.itemList.Length > 0)
        {
            for (int i = 0; i < Inventory.instance.itemList.Length; i++)
            {
                if (Inventory.instance.itemList[i] == itm)
                {

                    if (Inventory.instance.itemList[i].UseTwice)
                    {
                        found = true;
                        Inventory.instance.DisplayKeyUse(i);
                        Inventory.instance.itemList[i].UseTwice = false;
                        i = Inventory.instance.itemList.Length;
                    }
                    else
                    {
                        found = true;
                        Inventory.instance.DisplayMessage(i, false);
                        Inventory.instance.itemList[i].UseTwice = true;
                        Inventory.instance.itemList[i] = null;
                        Inventory.instance.UpdateSlotUI();
                        
                        
                    }
                }
            }


        }

        if (found)
        {
            found = false;
            return true;
        }

        return found;
        
    }

    


    public bool Use_Item_Lighter()
    {
        if (Inventory.instance.itemList.Length > 0)
        {
            for (int i = 0; i < Inventory.instance.itemList.Length; i++)
            {
                if (Inventory.instance.itemList[i] == itm)
                {
                    found = true;
                    Inventory.instance.DisplayMessage(i, false);
                    Inventory.instance.itemList[i] = null;
                }
            }
        }

        if (found == true)
        {
            obj.GetComponent<Fireplace_Activate>().TurnOn();
            obj.GetComponent<SpawnItemEvent>().SpawnItemKey();
        }

        return found;
    }

}
