using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public float timer = 5f;
	public float repeat = 5f;
	private int next = 0;
	public int carsPerLevel;
	//  respawns = GameObject.FindGameObjectsWithTag("Respawn");
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer < 0 && next <= carsPerLevel) {
			string car = next.ToString();
			GameObject go = Instantiate (Resources.Load ("Car1")) as GameObject;
			go.tag = "Car" + car;
			Debug.Log ("Car" + car);
			go.GetComponent<Car1>().carTag = "Car" + car;
			timer = repeat;
			next++;
		}
	}
}
