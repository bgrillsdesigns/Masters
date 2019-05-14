using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactable NPC", menuName = "New NPC")]
public class NPCStats : ScriptableObject {
    // Base Item Stats
    new public string name = "NPC Name";
    public string description = "Facts about NPC";
    public int ID = 0;
    public Sprite icon = null;
    public Dialogue dialogue;

    // Information
    // ID's-
        /* 00: No NPC (or Test NPC)
         * 01: Gaurdian of the Forest Dog
         * 02: MothMan
         * 03: TBA
         */
}
