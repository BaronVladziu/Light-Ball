using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		offset = player.transform.position - transform.position;
	}

	// LateUpdate is called once per frame after Update
	void LateUpdate () {
		newPosition = new Vector3 (player.transform.position.x - offset.x, transform.position.y, player.transform.position.z - offset.z);
		transform.position = newPosition;
	}

}