using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    private float speed;

    public float startSpeed = 5;
    private float dazedTime;
    public float startDazedTime;

    playerController Player;

    // private Animator anim;
    public GameObject bloodEffect;

    // Use this for initialization
    void Start()
    {
        // anim = GetComponent<Animator>();
        // anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = startSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        // play a hurt sound effect

        //  Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN !");
    }
}

    
