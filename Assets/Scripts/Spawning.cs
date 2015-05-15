using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

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

		if (timer < 0 && next <= carsPerLevel && randomCar == 0) {
			string car = next.ToString();
			randomCar = Random.Range (0,2);
			spawnPointIndex = Random.Range (0,spawnPoints.Length);
			GameObject go = Instantiate (Resources.Load ("YellowCar"), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
			go.tag = "Car" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "Car" + car;
			timer = repeat;
			next++;
		} else if (timer < 0 && next <= carsPerLevel && randomCar == 1) {
			string car = next.ToString();
			randomCar = Random.Range (0,2);
			spawnPointIndex = Random.Range (0,spawnPoints.Length);
			GameObject go = Instantiate (Resources.Load ("RedCar"), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
			go.tag = "Car" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "Car" + car;
			timer = repeat;
			next++;
		} 

	}
}
