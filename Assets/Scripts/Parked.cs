using UnityEngine;
using System.Collections;

public class Parked : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponentInParent<Car1>().alreadyParked)
			this.GetComponent<SpriteRenderer> ().enabled = true;
	}
}
