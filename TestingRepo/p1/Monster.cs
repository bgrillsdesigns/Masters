using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour {

    public GameObject player;
    public Transform Monster_Eyes;

    private NavMeshAgent nav_agent;
    private string state = "idle";
    private bool alive = true;
    private float wait_time = 0f;
    private bool alert_mode = false;
    private float alert_value = 8f;
	// Use this for initialization
	void Start () {
        nav_agent = GetComponent<NavMeshAgent>();
	}
	
    //checks whether monster can see the player//
    public void Check_Sight()
    {
        if (alive && Character_Controller.hidden_player == false)
        {
            RaycastHit ray_hit;

            if(Physics.Linecast(Monster_Eyes.position, player.transform.position, out ray_hit))
            {
                if(ray_hit.collider.gameObject.tag == "Player")
                {
                    state = "chase";
                }
            }
        }
    }
    void OnCollisionEnter(Collision exampleCol)
    {
        if (exampleCol.collider.tag == "Player")
        {
            //Replace 'Game Over' with your game over scene's name.
            SceneManager.LoadScene("GameOver");
        }
    }

    // Update is called once per frame
    void Update () {

        if (alive)
        {
            if(state == "idle")
            {
                // goes to a random place//
                Vector3 randomDir = Random.insideUnitSphere * alert_value;
                NavMeshHit nav_Hit;
                NavMesh.SamplePosition(transform.position + randomDir, out nav_Hit, 15f, NavMesh.AllAreas);
                nav_agent.SetDestination(nav_Hit.position);
                state = "walk";

                if (alert_mode)
                {
                    // will start with player's last position if alerted//
                    NavMesh.SamplePosition(player.transform.position + randomDir, out nav_Hit, 20f, NavMesh.AllAreas);
                    alert_value += 3f;

                    if(alert_value > 15f)
                    {
                        alert_mode = false;
                        alert_value = 8f;
                        // can alter speed of monster here for walk speed//
                        // nav_agent.speed = 1.1f; //
                    }
                }
            }

            else if(state == "walk")
            {
                if(nav_agent.remainingDistance <= nav_agent.stoppingDistance && !nav_agent.pathPending)
                {
                    state = "search";
                    wait_time = 3.5f;
                }
            }

            else if(state == "search")
            {
                if (wait_time > 0f)
                {
                    wait_time -= Time.deltaTime;
                    transform.Rotate(0f, 45f * Time.deltaTime, 0f);
                }
                else
                {
                    state = "idle";
                }
            }

            else if(state == "chase")
            {
                // can lose the player and stop chasing//
                float dist = Vector3.Distance(transform.position, player.transform.position);

                if (Character_Controller.hidden_player == true)
                {
                    state = "hunting";
                }
                else
                    nav_agent.destination = player.transform.position;
                

                if (dist > 15f)
                {
                        state = "hunting";
                }
                
            }

            else if(state == "hunting")
            {
                if(nav_agent.remainingDistance <= nav_agent.stoppingDistance && !nav_agent.pathPending)
                {
                    state = "search";
                    wait_time = 2.0f;
                    alert_mode = true;
                    alert_value += 0.5f;
                    Check_Sight();
                }
            }
        }
        //nav_agent.SetDestination(player.transform.position);//
	}
}
