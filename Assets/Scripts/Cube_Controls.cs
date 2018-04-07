using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controls : MonoBehaviour {

	public GameObject player;
	public GameObject map;

	private const float MAX_DISTANCE = 12.5f;

	private Vector3 cubePos;
	private Vector3 playerPos;


	// Use this for initialization
	void Start () {
		cubePos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		updateCubePosition ();
	}

	void updateCubePosition() {
		playerPos = player.transform.position;
		if (cubePos.x - playerPos.x > MAX_DISTANCE) {
			cubePos = new Vector3 (cubePos.x - 2*MAX_DISTANCE, map.GetComponent<Map_RandomCubeHeightGenerator>().generateRandomHeight(), cubePos.z);
			this.transform.position = cubePos;
		}
		if (cubePos.x - playerPos.x < -MAX_DISTANCE) {
			cubePos = new Vector3 (cubePos.x + 2*MAX_DISTANCE, map.GetComponent<Map_RandomCubeHeightGenerator>().generateRandomHeight(), cubePos.z);
			this.transform.position = cubePos;
		}
		if (cubePos.z - playerPos.z > MAX_DISTANCE) {
			cubePos = new Vector3 (cubePos.x, map.GetComponent<Map_RandomCubeHeightGenerator>().generateRandomHeight(), cubePos.z - 2*MAX_DISTANCE);
			this.transform.position = cubePos;
		}
		if (cubePos.z - playerPos.z < -MAX_DISTANCE) {
			cubePos = new Vector3 (cubePos.x, map.GetComponent<Map_RandomCubeHeightGenerator>().generateRandomHeight(), cubePos.z + 2*MAX_DISTANCE);
			this.transform.position = cubePos;
		}
	}

}