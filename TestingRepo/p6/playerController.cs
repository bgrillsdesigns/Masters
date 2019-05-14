using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    //Public
    public int EquipmentID;
    public int AttackDamage = 0;
    public double HealthPoints = 4;
    public int ManaPoints = 10;
    public Sprite PlayerSprite;
    public float speed;
    public AudioSource deathSound;
    public bool dead = false;

    //Private
    private bool facingRight;
    private Rigidbody2D rb;
    private Animator ani;
    private int HealthPointMax = 4;
    private int ManaPointMax = 10;
    private double damageBlock = 0;
    private bool called = false;
    private bool hit = false;

    // Inventory Stuff
    const string path = "Objects/Interactables/";
    BasicInventory basicInventory;

    // Use this for initialization
    void Awake () {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        basicInventory = (GameObject.Find("GameManager")).GetComponent<BasicInventory>();
        PlayerSprite = GetComponent<SpriteRenderer>().sprite;
        called = false;
        dead = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (HealthPoints <= 0 && !called) {
            deathSound.Play();
            speed = 0;
            StartCoroutine(WaitTimeDead(3));
            called = true;
        }
        if (dead == true) {
            SceneManager.LoadScene(0);
        } 
    }

    void FixedUpdate() {
        float move = Input.GetAxis("Horizontal"); // a or left arrow = -1. d or right arrow = 1

        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        if (move != 0) {
            ani.SetBool("isWalking", true);
        }
        else {
            ani.SetBool("isWalking", false);
        }
        Flip(move);
    }

    private void Flip(float horizontal)
    {
        if(speed != 0) {
            if (horizontal < 0) {
                (GetComponent<SpriteRenderer>()).flipX = true;
            }
            if (horizontal > 0) {
                (GetComponent<SpriteRenderer>()).flipX = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // Set Hit object
        GameObject hit = collision.gameObject;
        // Test Tags for Item
        if (hit.tag == "Item") {
            // Get The ScriptableObject for Inventory
            ItemGeneration Item = hit.GetComponent<ItemGeneration>();
            if(Item.ID > 4) {
                // Add Potion
                basicInventory.AddPotion(Item.ID);
            }
            else {
                // Add Item
                basicInventory.AddHerb(Item.ID);
            }
            // Destroy Old Item
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        // Set Hit object
        GameObject hit = collision.gameObject;
        // Test Tags for Item
        if (hit.tag == "Dialog") {
            Dialogue dialogue = hit.GetComponentInParent<NPCInformation>().dialogue;
            FindObjectOfType<DialogManager>().StartDialog(dialogue);
        }
    }
    public void TakeDamage(double damage)
    {
        if(!hit) {
            hit = true;
            HealthPoints = HealthPoints - (damage - damageBlock);
            StartCoroutine(WaitTimeHit(2));
        }
        else {
            // Invicibility frame
        }
    }

    public void Craft(int ID) {
        if (basicInventory.Craft(ID)) {
            if (ID == 5) {
                HealthPoints = HealthPointMax;
            }
            else if (ID == 6) {
                ManaPoints = ManaPointMax;
            }
            else if (ID == 7) {
                StartCoroutine(WaitTimeAttack(10, AttackDamage));
                AttackDamage += 10;
            }
            else if (ID == 8) {
                StartCoroutine(WaitTimeBlock(10, damageBlock));
                damageBlock += 1;
            }
            else {
                // Do nothing
                Debug.Log("Craft Failed: wrong number");
            }
        }
        else {
            Debug.Log("Craft Failed");
        }
    }
    IEnumerator WaitTimeDead(int wait) {
        yield return new WaitForSeconds(wait);
        dead = true;
    }
    IEnumerator WaitTimeAttack(int wait, int baseAttack) {
        yield return new WaitForSeconds(wait);
        AttackDamage = baseAttack;
    }
    IEnumerator WaitTimeBlock(int wait, double baseBlock) {
        yield return new WaitForSeconds(wait);
        damageBlock = baseBlock;
    }
    IEnumerator WaitTimeHit(int wait) {
        yield return new WaitForSeconds(wait);
        hit = false;
    }
    public double CheckHealthPoints()
    {
        return HealthPoints;
    }
}
