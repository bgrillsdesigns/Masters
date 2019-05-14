using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInventory : MonoBehaviour {
    private int[] Items = new int[4];

    private void Awake() {
        Items[0] = 0;
        Items[1] = 0;
        Items[2] = 0;
        Items[3] = 0;
    }

    public void AddHerb(int ID) {
        // Red Apple
        if (ID == 1) {
            Items[0] += 1;
        }
        // Green Apple
        else if (ID == 2) {
            Items[1] += 1;
        }
        // Berries
        else if (ID == 3) {
            Items[2] += 1;
        }
        // Honey Suckle
        else if (ID == 4) {
            Items[3] += 1;
        }
        else {
            // Wrong Number Given
        }
    }

    public void AddPotion(int ID) {
        // Red Potion
        if (ID == 5) {
            Items[0] += 2;
        }
        // Blue Potion
        else if (ID == 6) {
            Items[1] += 1;
            Items[3] += 1;
        }
        // Purple Potion
        else if (ID == 7) {
            Items[0] += 1;
            Items[2] += 1;
        }
        // Yellow Potion
        else if (ID == 8) {
            Items[3] += 2;
        }
        else {
            // Wrong Number Given
        }
    }

    public bool Craft(int ID) {
        // Red Potion
        if (ID == 5) {
            if(Items[0] >= 2) {
                Items[0] -= 2;
                return true;
            }
            else {
                return false;
            }
        }
        // Blue Potion
        else if (ID == 6) {
            if (Items[1] >= 1 && Items[3] >=1) {
                Items[1] -= 1;
                Items[3] -= 1;
                return true;
            }
            else {
                return false;
            }
        }
        // Purple Potion
        else if (ID == 7) {
            if (Items[0] >= 1 && Items[2] >= 1) {
                Items[0] -= 1;
                Items[2] -= 1;
                return true;
            }
            else {
                return false;
            }
        }
        // Yellow Potion
        else if (ID == 8) {
            if (Items[3] >= 1 && Items[3] >= 1) {
                Items[3] -= 2;
                return true;
            }
            else {
                return false;
            }
        }
        else {
            // Wrong Number Given
            return false;
        }
    }

    public int GetNumRedApples() {
        return Items[0];
    }
    public int GetNumGreenApples() {
        return Items[1];
    }
    public int GetNumBerries() {
        return Items[2];
    }
    public int GetNumHoney() {
        return Items[3];
    }
}
