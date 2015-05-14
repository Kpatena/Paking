using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public float timer = 5f;
	public float repeat = 5f;
	public int carsPerLevel;
	public int differentCarsInLevel = 3;
	private int randomCar = 1;
	private int next = 0;
	//  respawns = GameObject.FindGameObjectsWithTag("Respawn");
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer < 0 && next <= carsPerLevel && randomCar == 1) {
			string car = next.ToString();
			randomCar = Random.Range (1,differentCarsInLevel);
			GameObject go = Instantiate (Resources.Load ("YellowCar")) as GameObject;
			go.tag = "Car" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "Car" + car;
			timer = repeat;
			next++;} 
		else if (timer < 0 && next <= carsPerLevel && randomCar == 2) {
			string car = next.ToString();
			randomCar = Random.Range (1,differentCarsInLevel);
			GameObject go = Instantiate (Resources.Load ("RedCar")) as GameObject;
			go.tag = "Car" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "Car" + car;
			timer = repeat;
			next++;
		} else if (timer < 0 && next <= carsPerLevel && randomCar == 3) {
			string car = next.ToString();
			randomCar = Random.Range (1,differentCarsInLevel);
			GameObject go = Instantiate (Resources.Load ("YellowRaceCar")) as GameObject;
			go.tag = "RaceCar" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "Car" + car;
			timer = repeat;
			next++;
		}

	}
}
