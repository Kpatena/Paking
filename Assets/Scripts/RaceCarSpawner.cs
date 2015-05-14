using UnityEngine;
using System.Collections;

public class RaceCarSpawner : MonoBehaviour {

	public float timer = 10f;
	public float repeat = 10f;
	public int carsPerLevel;
	private int randomCar = 1;
	private int next = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;

		if (timer <= 0 && next <= carsPerLevel && randomCar == 1) {
			string car = next.ToString();
			randomCar = Random.Range (1,2);
			GameObject go = Instantiate (Resources.Load ("YellowRaceCar")) as GameObject;
			go.tag = "RaceCar" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "RaceCar" + car;
			timer = repeat;
			next++;
		}
	}
}
