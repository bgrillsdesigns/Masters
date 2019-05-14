using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBonce : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bounced");
        Fighter player = collision.GetComponent<Fighter>();
        player.TakeDamage(10f, AttackType.Wall, AttackButton.Wall);
        player.myBody.velocity = new Vector2(-4.2f * player.myBody.velocity.x,15f);

   
    }
}
