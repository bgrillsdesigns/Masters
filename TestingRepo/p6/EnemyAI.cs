using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public int moveSpeed = 3;
    bool isFollowing = false;
    Transform player = null;

    void Awake()
    {
        player = (GameObject.Find("player")).GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            GetComponentInParent<EnemyInformation>().changeMS = true;
            isFollowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            GetComponentInParent<EnemyInformation>().changeMS = false;
            isFollowing = false;
        }
    }

    void Update()
    {
        
        if(isFollowing == true)
        {
            float value = player.position.x - transform.position.x;
            if (value < 0)
            {
                GetComponentInParent<EnemyInformation>().changedSpeed = 3;
            }
            else if (value > 0)
            {
                GetComponentInParent<EnemyInformation>().changedSpeed = -3;
            }
            else
            {
                GetComponentInParent<EnemyInformation>().changedSpeed = 0;
            }
        }
    }
}
