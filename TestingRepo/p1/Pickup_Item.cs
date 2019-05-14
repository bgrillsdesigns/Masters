using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Item : MonoBehaviour {
    public GameItems item;


    public void Interact()
    {
        Pickup();
    }
    // Use this for initialization

    public void Pickup()
    {
        if (item.isNote)
        {
            Inventory.instance.Add_Inventory(item, gameObject);
            gameObject.SetActive(false);
        }

        else
        {
            Inventory.instance.Add_Inventory(item, null);
            Destroy(gameObject);
        }
        
    }

    public GameItems getItem()
    {
        return item;
    }

    void Start () {
		
	}
	
	
}
