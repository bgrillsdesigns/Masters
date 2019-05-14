using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameItem", menuName = "Items/GameItem")]
public class GameItems : ScriptableObject {

    public Sprite icon;
    public string display_name, description;
    public bool isNote;
    public bool UseTwice;

}
