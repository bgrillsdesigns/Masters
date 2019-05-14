using System.Collections;
using UnityEngine;

public class Use : MonoBehaviour {

    private Inventory inventory;
    protected Animator animator;

    public Renderer UseRenderer;
    public GameObject HUD_Image;
    public bool isTrigger;
    public GameObject Trigger;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {



    }
    //Uses the current item
    public void Press(RaycastHit hit)
    {
        //waits for Use Button and Checks if you are holding a key
        if (inventory.slots[0].name.Contains("Key") && Input.GetButtonDown("Use"))
        {
            animator = transform.parent.parent.GetComponent<Animator>();
            //Calls the lock aniamtion for the door
            animator.SetBool("unlocked", true);

            //Cleans up the HUD and Inventory. Call this whenever you are using an object
            useCleanup();

            //This is a fix for using two of the same object
            StartCoroutine(wait(hit));            
        }
        else if (Input.GetButtonDown("Use") && inventory.slots[0].name == "Sliding_Puzzle_Piece")
        {
            if (isTrigger)
                Trigger.SetActive(true);
            useCleanup();
            hit.collider.gameObject.tag = "Puzzle";
        }
        else if (Input.GetButtonDown("Use") && inventory.slots[0].name == "box")
        {
            if (isTrigger)
                Trigger.SetActive(true);
            useCleanup();

        }
        else if(Input.GetButtonDown("Use") && inventory.slots[0].name.Contains("Tin Can"))
        {
            if (isTrigger)
                Trigger.SetActive(true);
            useCleanup();
        }
    }
    public void useCleanup( )
    {
        //Gets rid of slot 1's object
        inventory.slots[0] = null;
        //Clears sprite off HUD
        HUD_Image.SetActive(false);
        //Sets the inventory spot to empty
        inventory.isFull[0] = false;
    }
    public IEnumerator wait(RaycastHit hit)
    {
        yield return new WaitForSeconds(2);
        hit.collider.gameObject.SetActive(false);
        yield break;
        
    }

}
