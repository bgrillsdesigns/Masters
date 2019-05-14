using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plugger : MonoBehaviour
{

    protected Animator animator;
    public bool Pushed;
    public Renderer PluggerRenderer;
    public GameObject Boom;
    public GameObject Dust;
    public GameObject Rocks;
    public GameObject Wire;
    public void Start()
    {
        Pushed = false;
    }

    public void Down(RaycastHit hit)
    {
        if (Input.GetButtonDown("Use"))
        {
            hit.collider.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - .05f, transform.position.z);
            Boom.SetActive(true); Dust.SetActive(true); Rocks.SetActive(false); Pushed = true;
        }

    }
}