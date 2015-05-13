using UnityEngine;
using System.Collections;

public class CollisionIndicator : MonoBehaviour {

	public AudioSource Honk;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Indicator") {
			this.GetComponent<SpriteRenderer> ().enabled = true;
			Honk = GetComponentInChildren<AudioSource> ();
			Honk.Play ();
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Indicator") {
			this.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Indicator") {
			this.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

}
	

