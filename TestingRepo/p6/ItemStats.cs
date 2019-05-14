using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactable Item", menuName = "New Item")]
public class ItemStats : ScriptableObject {
    // Base Item Stats
    new public string name = "Item";
    public string description = "Object in game";
    public int ID = 0;
    public Sprite icon = null;

    // Information
    // ID's-
    /* 00: Fist Weapon (No Icon)
     * 01: Red Apple
     * 02: Green Apple
     * 03: Berries
     * 04: Honey
     * 05: Red Potion
     * 06: Blue Potion
     * 07: Purple Potion
     * 08: Yellow Potion
     */
}

