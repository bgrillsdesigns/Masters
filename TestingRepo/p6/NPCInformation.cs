using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class NPCInformation : MonoBehaviour {
    // Public Info for Stats
    new public string name;
    public Sprite icon;
    public string Description;
    public int ID;
    public bool IsRandom;
    public Dialogue dialogue;
    public AnimatorController creatureAni;
    public bool testAni = false;

    // Hidden Info
    NPCStats npcInfo;
    const string path = "Objects/NPCs/";
    const string pathAni = "Animations/";
    Animator animator;

    private void Awake() {
        // Check if Item is Randomly Generated
        if (IsRandom == true) {
            ID = Random.Range(1, 4);
        }
        npcInfo = Resources.Load(path + ID) as NPCStats;
        // Change stats
        name = npcInfo.name;
        Description = npcInfo.description;
        ID = npcInfo.ID;
        icon = npcInfo.icon;
        dialogue = npcInfo.dialogue;
        // load the Icon
        SpriteRenderer loadSprite = gameObject.GetComponent<SpriteRenderer>();
        loadSprite.sprite = icon;

        // Give correct animation to enemy
        if (!testAni) {
            creatureAni = Resources.Load(pathAni + name) as AnimatorController;
        }
        if (!creatureAni) {
            Debug.LogError("Missing animation asset: " + pathAni + name + " could not be found.");
        }
        else {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = creatureAni;
        }
    }

}
