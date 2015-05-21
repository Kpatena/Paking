using UnityEngine;
using System.Collections;

public class StockCarMove : MonoBehaviour {

	public float movementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.up * movementSpeed * Time.deltaTime); 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "BoxCollider") {
			Destroy (this.gameObject);
		}
		if (other.tag == "Wall") {
			Destroy (this.gameObject);
		}
	}
}
