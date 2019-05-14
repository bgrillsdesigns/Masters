﻿using UnityEngine;

public class gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public Camera FPSCamera;

    public AudioSource gunSound;
//commented out code was ommited here 

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
//commented out code was ommited here 
        GetComponent<AudioSource>().Play();
        RaycastHit hit;

        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
