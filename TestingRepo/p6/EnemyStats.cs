using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyStats : ScriptableObject {
    new public string name = "New Enemy";
    public string description = "Baddie";
    public Sprite icon = null;
    public int ID = 0;
    public int healthPoints = 0;
    public int damageMelee = 0;
    public int damageRanged = 0;
    public int damageTouch = 0;
    public int movementSpeed = 0;
    public int attackSpeed = 0;
    public int sizeCreature = 0;

    //Information
    /* Health Points:
        * Basically just how much damage a creature can take (0 = death)
     * Damage:
        * Melee- Damage done through a Weapon Attack.
        * Ranged- Damage done through a Ranged Attack.
        * Touch- Damage done by touching the player.
     * Movement:
        * 0-5, where 0 is no movement, 5 is twice as fast as the player, and 1 is half as fast as the player. (player at base is 3).
     * Attack Speed:
        * Attacks per sec.
     * Size Creature:
        * 0-5 where 0 is smallest, 5 is largest (non-boss or boss [undecided]), 3 is player.
     */
}
