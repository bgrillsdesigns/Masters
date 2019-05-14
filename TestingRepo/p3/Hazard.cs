using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Fighter player = collision.GetComponent<Fighter>();

        if(player.name == "Player-1")
        {
            Destroy(player);
            SceneManager.LoadScene(3);
        }
    }
}
