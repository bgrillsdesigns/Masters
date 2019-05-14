using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class breathing : MonoBehaviour {
	Renderer rend;
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Standard");
	}
	
	void Update () {
		float heightMap = Mathf.PingPong(Time.time / 20, 0.075f) + 0.005f;
		rend.material.SetFloat("_Parallax", heightMap);
	}
}
