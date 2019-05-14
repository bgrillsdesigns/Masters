using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBetAttack;
    public float startTimeBetAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public Animator ani;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    public AudioSource attackSound;
    public GameObject magicRight, magicLeft;

    Vector2 magicPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    private bool facingRight = false;

    public SpriteRenderer player;

    void Awake()
    {
        player = (GameObject.Find("player")).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }

        if (timeBetAttack <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                attackSound.Play();
                ani.SetBool("isAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyInformation>().TakeDamage(damage);
                }

                timeBetAttack = startTimeBetAttack;
            }
            else
            {
                timeBetAttack -= Time.deltaTime;
                ani.SetBool("isAttacking", false);
            }
        }
    }

    void fire()
    {
        magicPos = transform.position;
        if (facingRight)
        {
            magicPos += new Vector2(+1f, -0.5f);
            Instantiate(magicRight, magicPos, Quaternion.identity);

        }
        else
        {
            magicPos += new Vector2(-1f, -0.5f);
            Instantiate(magicLeft, magicPos, Quaternion.identity);
        }
    }
}
