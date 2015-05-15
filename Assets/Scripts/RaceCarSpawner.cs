using UnityEngine;
using System.Collections;

public class RaceCarSpawner : MonoBehaviour {

	public float timer = 10f;
	public float repeat = 10f;
	public int carsPerLevel;
	public Transform[] spawnPoints;
	private int spawnPointIndex;
	private int randomCar = 0;
	private int next = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;

		if (timer <= 0 && next <= carsPerLevel && randomCar == 0) {
			string car = next.ToString();
			randomCar = Random.Range (0,2);
			spawnPointIndex = Random.Range (0,spawnPoints.Length);
			GameObject go = Instantiate (Resources.Load ("YellowRaceCar"), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
			go.tag = "RaceCar" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "RaceCar" + car;
			timer = repeat;
			next++;
		}
	}
}
