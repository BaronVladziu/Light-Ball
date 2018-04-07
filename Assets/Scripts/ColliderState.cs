using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderState : MonoBehaviour {

	private int numberOfCollisions;

	// Use this for initialization
	void Start () {
		numberOfCollisions = 0;
	}

	void OnCollisionEnter (Collision collision) {
		numberOfCollisions++;
	}

	void OnCollisionExit (Collision collision) {
		numberOfCollisions--;
	}

	public bool getIfCollides () {
		return numberOfCollisions > 0;
	}

}