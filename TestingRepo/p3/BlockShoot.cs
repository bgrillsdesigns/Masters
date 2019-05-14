using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShoot : MonoBehaviour {

    public GameObject firePointBlock;

    public GameObject bulletPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePointBlock.transform.position, firePointBlock.transform.rotation);      
    }
}
