using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpControl : MonoBehaviour
{
    public KeyCode jumpKey;
    public string midjump = "n";
    public AudioSource jumpSound;

    private playerController player;
    // Use this for initialization
    void Start()
    {
        player = (GameObject.Find("player")).GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(jumpKey)) && (midjump == "n") && player.CheckHealthPoints() > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 15, 0);
            midjump = "y";
            jumpSound.Play();
        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
            midjump = "n";
    }
}
