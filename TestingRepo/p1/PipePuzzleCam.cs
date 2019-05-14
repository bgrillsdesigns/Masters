using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzleCam : MonoBehaviour
{
    public Camera mainCam;
    public Camera hidden_cam;
    public bool isHidden = false;
    private bool show = false;
    public int ray_dist = 2;
    public GameObject player;
   

    private int gui_timer = 6;
    // Use this for initialization
    void Start()
    {
        mainCam.GetComponent<Camera>().enabled = true;
        hidden_cam.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ray_hit;
        Vector3 fd = transform.TransformDirection(Vector3.forward);

        if (isHidden == true)
        {
            if (Input.GetKeyDown("e"))
            {
                player.GetComponent<Character_Controller>().enabled = true;
                player.GetComponent<PlayerController>().enabled = true;
                player.GetComponent<CapsuleCollider>().enabled = true;
                player.GetComponent<SphereCollider>().enabled = true;
                player.GetComponent<Rigidbody>().useGravity = true;

                mainCam.GetComponent<Camera>().enabled = true;
                hidden_cam.GetComponent<Camera>().enabled = false;



                Character_Controller.hidden_player = false;
                isHidden = false;
            }
        }
        else if (Physics.Raycast(transform.position, fd, out ray_hit, ray_dist))
        {
            if (ray_hit.collider.gameObject.tag == "Hide" && isHidden == false)
            {
                show = true;

                if (Input.GetKeyDown("e"))
                {
                    mainCam.GetComponent<Camera>().enabled = false;
                    hidden_cam.GetComponent<Camera>().enabled = true;

                    Character_Controller.hidden_player = true;
                    isHidden = true;
                    show = false;
                    gui_timer = 6;
                }
            }
        }

        else
        {
            show = false;
        }
    }


}
