using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Minion : NetworkBehaviour {

	public Transform objective;
	int team;

	public Transform target;
	public float range = 8f;

	private float timeBtwShots;
	public float startTimeBtwShots = 2f;

	public GameObject projectile;
	public Transform firePoint;

	void Start(){
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void Awake(){
		team = GetComponent<Stats>().team;
	}

	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Minion");

		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach(GameObject enemy in enemies){
			if(enemy.GetComponent<Stats>().team != gameObject.GetComponent<Stats>().team){
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if(distanceToEnemy < shortestDistance){
					shortestDistance = distanceToEnemy;
					nearestEnemy = enemy;
				}
			}
		}

		if(nearestEnemy != null && shortestDistance <= range){
				target = nearestEnemy.transform;
		}
		else{
			target = null;
		}

		
	}

	void Update (){
		if(target == null){
			GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
			return;
	
		}

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);

		Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime).eulerAngles;
		
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (target){
			GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
		}

		if(timeBtwShots <= 0){
			GameObject newBullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
			newBullet.GetComponent<MinionProjectile>().team = GetComponent<Stats>().team;
			newBullet.GetComponent<MinionProjectile>().target = target;
			NetworkServer.Spawn(newBullet);
			timeBtwShots = startTimeBtwShots;
		}
		else{
			timeBtwShots -= Time.deltaTime;
		}

	}
	

	public void LateStart(int t){
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		if(t == 0){
			objective = GameObject.FindGameObjectWithTag("Goal1").transform;
		}
		else{
			objective = GameObject.FindGameObjectWithTag("Goal2").transform;
		}
		
		agent.destination = objective.position;
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	// IEnumerator PoisonMin()
 //    {
 //        for (float healthDrain = this.health; healthDrain > 4; healthDrain -= 4){
 //            this.health = healthDrain;
 //            yield return new WaitForSeconds (1);
 //        }

 //        this.health = 0;
 //    }
}
