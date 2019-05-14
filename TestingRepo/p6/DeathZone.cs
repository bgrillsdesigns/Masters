using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {
    [SerializeField]Transform spawnPoint;
    public AudioSource deathSound;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            if (Input.GetKey("z"))
                SceneManager.LoadScene(2);
            else{
                deathSound.Play();
                if (Input.GetKeyDown(KeyCode.J))
                    SceneManager.LoadScene(0);
            }
        }
    }
}
