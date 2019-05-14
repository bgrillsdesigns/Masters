using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchBlockShoot : MonoBehaviour {

    public GameObject firePointCrouchBlock;

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
        Instantiate(bulletPrefab, firePointCrouchBlock.transform.position, firePointCrouchBlock.transform.rotation);
    }
}
