using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAttack : MonoBehaviour {
    private float dmg;
    private int FromWho;
    public void Set_Params(float _dmg, int _player){
        dmg = _dmg;
        FromWho = _player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fighter player = collision.GetComponent<Fighter>();
        if(player.PNum != FromWho){
            player.TakeDamage(dmg, AttackType.Forward, AttackButton.Primary);
        }
    }
}
