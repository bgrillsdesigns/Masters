using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : isController {
    //to check to see if a slot is full
    public bool[] isFull;
    //to allow for expansion
    public GameObject[] slots;
    //to keep track of items picked up
    public string[] list;
    //to count picked up items
    public int count;

}
