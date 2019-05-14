using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet3 : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Fighter player = collision.GetComponent<Fighter>();

            if (!player.STATS.Get_Current_Action().Equals(Movement_Direction.Crouch_Blocking))
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
