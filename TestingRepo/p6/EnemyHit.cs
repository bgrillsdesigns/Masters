using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {
    playerController player;
    void Awake()
    {
        player = (GameObject.Find("player")).GetComponent<playerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(.5);
    }
}
