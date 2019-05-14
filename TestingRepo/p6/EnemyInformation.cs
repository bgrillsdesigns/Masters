using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class EnemyInformation : MonoBehaviour {
    // Public Enemy Information
    new public string name;
    public Sprite icon;
    public string Description;
    public int ID;
    // 00: Nothing
    // 01: Spider (Small)
    // 02: Plant (Player)
    // 03: Tree (Large)
    public double hp;
    public int melee;
    public int ranged;
    public int touch;
    public int mSpeed;
    public int startSpeed;
    public int changedSpeed;
    public int aSpeed;
    public int size;
    public bool IsRandom = true;
    public bool testAni = false;
    public int dazedTime = 500;
    public int startDazedTime = 500;
    public AnimatorController creatureAni;
    public bool changeMS;
    

    // Hidden Info
    EnemyStats EnemyInfo;
    private playerController player;
    const string pathEnemy = "Objects/Enemies/";
    const string pathAni = "Animations/";
    Animator animator;
    SpriteRenderer loadSprite;

    // Use this for initialization
    void Awake() {
        player = (GameObject.Find("player")).GetComponent<playerController>();
        // Get A random Stat at runtime
        if (IsRandom) {
            ID = Random.Range(1, 3);
        }
        // Load Stat
        EnemyInfo = Resources.Load(pathEnemy + ID) as EnemyStats;
        // Change stats
        name = EnemyInfo.name;
        Description = EnemyInfo.description;
        ID = EnemyInfo.ID;
        icon = EnemyInfo.icon;
        hp = EnemyInfo.healthPoints;
        melee = EnemyInfo.damageMelee;
        ranged = EnemyInfo.damageRanged;
        touch = EnemyInfo.damageTouch;
        startSpeed = EnemyInfo.movementSpeed;
        aSpeed = EnemyInfo.attackSpeed;
        size = EnemyInfo.sizeCreature;
        // load the Icon
        loadSprite = gameObject.GetComponent<SpriteRenderer>();
        loadSprite.sprite = icon;

        // Give correct animation to enemy
        if(!testAni) {
           creatureAni = Resources.Load(pathAni + name) as AnimatorController;
        }        
        if (!creatureAni) {
            Debug.LogError("Missing animation asset: " + pathAni + name + " could not be found.");
        }
        else {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = creatureAni;
            animator.SetBool("isWalking", true);
        }

        // make sure enemy all look right way
        if(ID == 1) {
            loadSprite.flipX = false;
        }
    }

    void Update() {
        if (player.CheckHealthPoints() > 0) {
            if (changeMS == true)
            {
                if (dazedTime <= 0)
                {
                    mSpeed = changedSpeed;
                    if(mSpeed < 0)
                    {
                        animator.SetBool("isLeft", false);
                    }
                    else
                    {
                        animator.SetBool("isLeft", true);
                    }
                    if(mSpeed == 0)
                    {
                        animator.SetBool("isWalking", false);
                        animator.SetBool("isLeft", false);
                    }
                    else
                    {
                        animator.SetBool("isWalking", true);
                    }
                    
                }
                else
                {
                    mSpeed = 0;
                    dazedTime -= 1;
                    if (mSpeed == 0)
                    {
                        animator.SetBool("isWalking", false);
                        animator.SetBool("isLeft", false);
                    }
                    else
                    {
                        animator.SetBool("isWalking", true);
                    }
                }

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }

                transform.Translate(Vector2.left * mSpeed * Time.deltaTime);
            }
            else
            {
                if (dazedTime <= 0)
                {
                    mSpeed = startSpeed;
                    if(mSpeed < 0)
                    {
                        animator.SetBool("isLeft", false);
                    }
                    else
                    {
                        animator.SetBool("isLeft", true);
                    }
                    if (mSpeed == 0)
                    {
                        animator.SetBool("isWalking", false);
                    }
                    else
                    {
                        animator.SetBool("isWalking", true);
                    }
                }
                else
                {
                    mSpeed = 0;
                    dazedTime -= 1;
                    if (mSpeed == 0)
                    {
                        animator.SetBool("isWalking", false);
                    }
                    else
                    {
                        animator.SetBool("isWalking", true);
                    }
                }

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }

                transform.Translate(Vector2.left * mSpeed * Time.deltaTime);
            }
        }
        else {
            animator.SetBool("isWalking", false);
            mSpeed = 0;  
        }
    }
    public void TakeDamage(double damage) {
        dazedTime = startDazedTime;
        // play a hurt sound effect

        //  Instantiate(bloodEffect, transform.position, Quaternion.identity);
        hp -= damage;
        Debug.Log(name + " took " + damage + " damage!");
    }
}
