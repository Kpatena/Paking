using UnityEngine;
using System.Collections;

public class CollisionIndicator : MonoBehaviour {

	public AudioSource Honk;
	private float rotateValue = 2f;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Indicator" && this.GetComponentInParent<Car1>().touchedLot == false && other.GetComponentInParent<Car1>().touchedLot == false) {
			this.GetComponent<SpriteRenderer> ().enabled = true;
			Honk = GetComponentInChildren<AudioSource> ();
			Honk.Play ();
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Indicator" && this.GetComponentInParent<Car1>().touchedLot == false && other.GetComponentInParent<Car1>().touchedLot == false) {
			this.GetComponent<SpriteRenderer> ().enabled = true;
			this.transform.rotation = Quaternion.AngleAxis(rotateValue *Time.deltaTime, Vector3.down);

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Indicator") {
			this.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

}
	

