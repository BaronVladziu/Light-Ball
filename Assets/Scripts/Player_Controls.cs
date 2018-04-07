using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour {

	private bool isMoving = false;
	private Vector3 startPos;
	private Vector3 moveDirection;
	private Vector3 endPos;
	float time;
	Vector2 input;

	public GameObject downCollider;
	public GameObject northCollider;
	public GameObject eastCollider;
	public GameObject southCollider;
	public GameObject westCollider;
	public float walkSpeed;

	// Update is called once per frame
	void Update () {
		if (isMoving == false) {
			if (doesCollideWithSomething(downCollider) == false) {
				moveDirection = new Vector3 (0, -1, 0);
				MovePlayer ();
			} else {
				moveDirection = getPlayerInput ();
				if (canPlayerMove(moveDirection) == true) {
					MovePlayer ();
				}
			}
		}
	}

	bool doesCollideWithSomething (GameObject collider) {
		return collider.GetComponent<ColliderState> ().getIfCollides ();
	}

	void MovePlayer () {
		StartCoroutine (MoveWTF (transform));
	}

	IEnumerator MoveWTF (Transform entity) { //nie mam pojęcia, jak działa ta metoda XD
		isMoving = true;
		startPos = entity.position;
		time = 0;

		endPos = startPos + moveDirection;
		while (time < 1f) {
			time += Time.deltaTime * walkSpeed;
			entity.position = Vector3.Lerp (startPos, endPos, time);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}

	Vector3 getPlayerInput () {
		if (Input.anyKeyDown == true) {
			input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			if (Mathf.Abs (input.x) > Mathf.Abs (input.y)) {
				input.y = 0;
			} else {
				input.x = 0;
			}
			return new Vector3 (System.Math.Sign (input.x), 0, System.Math.Sign (input.y));
		} else {
			return Vector3.zero;
		}
	}

	bool canPlayerMove(Vector3 direction) {
		bool ifNoCollision = false;
		if (direction.z > 0) {
			if (doesCollideWithSomething (northCollider) == false) {
				ifNoCollision = true;
			}
		} else if (direction.z < 0) {
			if (doesCollideWithSomething (southCollider) == false) {
				ifNoCollision = true;
			}
		} else if (direction.x > 0) {
			if (doesCollideWithSomething (eastCollider) == false) {
				ifNoCollision = true;
			}
		} else if (direction.x < 0) {
			if (doesCollideWithSomething (westCollider) == false) {
				ifNoCollision = true;
			}
		}
		return ifNoCollision;
	}

}