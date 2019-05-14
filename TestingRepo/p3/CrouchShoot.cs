using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchShoot : MonoBehaviour {

    public GameObject firePointCrouch;

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
        Instantiate(bulletPrefab, firePointCrouch.transform.position, firePointCrouch.transform.rotation);
    }
}
