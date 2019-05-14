using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public GameItems[] itemList = new GameItems[10];
    public InventorySlot[] inventory_slots = new InventorySlot[10];
    private GameObject[] noteList = new GameObject[10];
    public GameObject textBox;
    public GameObject messages;

    private int lastCalled;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UpdateSlotUI();
        lastCalled = 11;
    }


    // adds item to inventory
    public bool AddItem(GameItems item, GameObject obj)
    {
        for(int i = 0; i < itemList.Length; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;

                if (item.isNote)
                    noteList[i] = obj;

                DisplayMessage(i, true);
                return true;
            }
        }

        return false;
    }
    public void UpdateSlotUI()
    {
        for(int i = 0; i < inventory_slots.Length; i++)
        {
                inventory_slots[i].UpdateSlot();   
        }
    }


    public void Add_Inventory(GameItems item, GameObject obj)
    {
        bool hasAdded;

        if (item.isNote)
            hasAdded = AddItem(item, obj);
        
        else
            hasAdded = AddItem(item, null);

        if (hasAdded)
        {
            UpdateSlotUI();
        }
    }

    public void ShowItem(int num)
    {
        if (!itemList[num].isNote)
        {
            if (ShowItemDesc(num))
                lastCalled = 11;
            else
                lastCalled = num;
        }
        else
        {
            noteList[num].GetComponent<Note>().ShowNoteImage();
            ShowItemDesc(lastCalled);
            lastCalled = num;
        }

        
    }

    public bool ShowItemDesc(int num)
    {
        string name = "Item Name: ";
        string desc = "Description: ";
        bool disable = false;

        if (lastCalled == num)
        {
            name = "";
            desc = "";
            disable = true;
        }
        else
        {
            name += Inventory.instance.itemList[num].display_name;
            name += "\n";
            desc += Inventory.instance.itemList[num].description;
        }

        Inventory.instance.textBox.GetComponent<Text>().text = name + desc;
        return disable;
    }

	public bool IsItem(string display)
    {
        for(int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].display_name == display)
                return true;
        }

        return false;
    }

    public void DisplayMessage(int num, bool hasAdded)
    {
        if (hasAdded)
        {
            Inventory.instance.messages.GetComponent<Text>().text = "Added " + itemList[num].display_name;
        }
        else
        {
            Inventory.instance.messages.GetComponent<Text>().text = "Removed " + itemList[num].display_name;
        }

        messages.GetComponent<MessageTimer>().ResetTimer();
    }

    public void DisplayKeyUse(int num)
    {
        Inventory.instance.messages.GetComponent<Text>().text = "Used " + itemList[num].display_name + " 1 use left";

        messages.GetComponent<MessageTimer>().ResetTimer();
    }

    
}
