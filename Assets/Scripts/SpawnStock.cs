using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnStock : MonoBehaviour {
	
	public string whichRedPrefab;
	public string whichYellowPrefab;
	public float timer = 5f;
	public float repeat = 5f;
	public int carsPerLevel;
	public Transform[] spawnPoints;
	private int spawnPointIndex;
	private int randomCar = 0;
	private int next = 0;
	//  respawns = GameObject.FindGameObjectsWithTag("Respawn");
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		
		if (timer < 0 && next <= 60) {
			//string car = next.ToString();
			//randomCar = Random.Range (0,2);
			spawnPointIndex = Random.Range (0,spawnPoints.Length);
			//make prefab for car and store in resources folder
			Instantiate (Resources.Load ("StockCar"), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			//go.tag = "Wall";
			timer = repeat;
			next++;
		}		
	}
}