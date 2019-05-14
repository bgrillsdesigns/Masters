using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemGeneration : MonoBehaviour {
    // Public Item Information
    new public string name;
    public Sprite icon;
    public string description;
    public int ID;
    public ItemType itemType;
    public bool IsRandom;

    // Enum for Item type Selection
    public enum ItemType {
        Herb,
        Potion,
    };

    // Hidden Info
    ItemStats itemInfo;
    const string path = "Objects/Interactables/";

    // Use this for initialization
    void Awake() {
        // Get A random Stat at runtime
        if (IsRandom) {
            if(itemType == 0) {
                ID = Random.Range(1, 5);
            }
            else {
                ID = Random.Range(1, 5) + 4;
            }
        }
        itemInfo = Resources.Load(path + ID) as ItemStats;
        // Change stats
        name = itemInfo.name;
        description = itemInfo.description;
        ID = itemInfo.ID;
        icon = itemInfo.icon;
        // load the Icon
        SpriteRenderer loadSprite = gameObject.GetComponent<SpriteRenderer>();
        loadSprite.sprite = icon;
    }
}
