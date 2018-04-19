using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_RandomCubeHeightGenerator : MonoBehaviour {

	private const int CHANCE_FOR_FLOOR = 8;
	private const int CHANCE_FOR_WALL = 1;
	private const int CHANCE_FOR_SKY = 1;

	private System.Random randomGenerator;
	private int randomNumber;
	private CubeHeight cubeHeight;

	// Use this for initialization
	void Start () {
		randomGenerator = new System.Random ();
	}
	
	public float generateRandomHeight() {
		cubeHeight = generateRandomCubeHeight ();
		switch (cubeHeight) {
		case CubeHeight.Wall:
			return 1;
		case CubeHeight.Sky:
			return 100;
		default:
			return 0;
		}
	}

	CubeHeight generateRandomCubeHeight() {
		randomNumber = randomGenerator.Next (CHANCE_FOR_FLOOR + CHANCE_FOR_WALL + CHANCE_FOR_SKY);
		if (randomNumber < CHANCE_FOR_FLOOR) {
			return CubeHeight.Floor;
		} else if (randomNumber < CHANCE_FOR_FLOOR + CHANCE_FOR_WALL) {
			return CubeHeight.Wall;
		} else {
			return CubeHeight.Sky;
		}
	}

}

enum CubeHeight {
	Floor,
	Wall,
	Sky
};