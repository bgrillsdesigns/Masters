using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WaveSpawner : NetworkBehaviour {

	public enum SpawnState{ SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public class Wave{
		public string name;
		public Transform enemy;
		public int amount;
		public float spawnRate;
	}

	public Wave[] waves;

	private int nextWave = 0;

	public float timeBetweenWaves = 5f;

	public Transform[] spawnOne;
	public Transform[] spawnTwo;
	public float waveCountdown;

	public SpawnState state =  SpawnState.COUNTING;

	void Start(){
		waveCountdown = timeBetweenWaves;

	}

	void Update(){
		if (waveCountdown <= 0){
			if (state != SpawnState.SPAWNING){
				StartCoroutine(SpawnWave(waves[nextWave]));
				WaveCompleted();
			}
		}
		else{
			waveCountdown -= Time.deltaTime;
		}
	}

	IEnumerator SpawnWave(Wave wave){
		int point = 0;

		state = SpawnState.SPAWNING;
		for(int i = 0; i < wave.amount; i++){
			SpawnEnemy(wave.enemy, point);
			if(point + 1 > spawnOne.Length - 1){
				point = 0;
			}
			else{
				point++;
			}
			yield return new WaitForSeconds(1f / wave.spawnRate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void WaveCompleted(){

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if(nextWave + 1 > waves.Length - 1){
			nextWave = 0;
		}
		else{
			nextWave++;
		}
	}

	void SpawnEnemy(Transform enemy, int point){
		Transform s1 = spawnOne[point];
		Transform s2 = spawnTwo[point];

		Transform enem = Instantiate(enemy, s1.position, s1.rotation);
		enem.gameObject.GetComponent<Stats>().LateStart(0);
		NetworkServer.Spawn(enem.gameObject);
		
		Transform enem2 = Instantiate(enemy, s2.position, s2.rotation);
		enem2.gameObject.GetComponent<Stats>().LateStart(1);
		NetworkServer.Spawn(enem2.gameObject);

	}
}
