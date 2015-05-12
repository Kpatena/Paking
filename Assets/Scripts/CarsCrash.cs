using UnityEngine;
using System.Collections;

public class CarsCrash : MonoBehaviour 
{
	public GameObject Crash;
	public GameObject Car;
	
	void OnTriggerEnter2D(Collider2D other)
	{

		/**********************MOVING**************************/
		if (other.tag == "BoxCollider") {
			this.GetComponentInParent<Car1>().Reset ();
			this.GetComponentInParent<Car1>().RemoveParkingTimer ();
			AddPoints.decreasePoints ();
			Instantiate (Crash, this.transform.position, this.transform.rotation); 
			Destroy (Car);
		}

		/**********************PARKING***************************/
		if (other.tag == "WestStall") {
			if (this.GetComponentInParent<Car1>().touchedLot == false && this.GetComponentInParent<Car1>().alreadyParked == false) {
				if (other.GetComponent<LotBehaviour> () != null) {
					this.GetComponentInParent<Car1>().Reset ();
					this.GetComponentInParent<Car1>().touchedLot = true;
					this.GetComponentInParent<Car1>().positioner = other.transform.position;
					this.GetComponentInParent<Car1>().rotater = Quaternion.Euler (0, 0, 90);
					this.GetComponentInParent<Car1>().WestStall = true;
				}
			}
		}

		if (other.tag == "EastStall") {
			if (this.GetComponentInParent<Car1>().touchedLot == false && this.GetComponentInParent<Car1>().alreadyParked == false) {
				if (other.GetComponent<LotBehaviour> () != null) {
					this.GetComponentInParent<Car1>().Reset ();
					this.GetComponentInParent<Car1>().touchedLot = true;
					this.GetComponentInParent<Car1>().positioner = other.transform.position;
					this.GetComponentInParent<Car1>().rotater = Quaternion.Euler (0, 0, 270);
					this.GetComponentInParent<Car1>().EastStall = true;
				}
			}
		}

		if (other.tag == "NorthStall") {
			if (this.GetComponentInParent<Car1>().touchedLot == false && this.GetComponentInParent<Car1>().alreadyParked == false) {
				if (other.GetComponent<LotBehaviour> () != null) {
					this.GetComponentInParent<Car1>().Reset ();
					this.GetComponentInParent<Car1>().touchedLot = true;
					this.GetComponentInParent<Car1>().positioner = other.transform.position;
					this.GetComponentInParent<Car1>().rotater = Quaternion.Euler (0, 0, 360);
					this.GetComponentInParent<Car1>().NorthStall = true;
				}
			}
		}

		if (other.tag == "SouthStall") {
			if (this.GetComponentInParent<Car1>().touchedLot == false && this.GetComponentInParent<Car1>().alreadyParked == false) {
				if (other.GetComponent<LotBehaviour> () != null) {
					this.GetComponentInParent<Car1>().Reset ();
					this.GetComponentInParent<Car1>().touchedLot = true;
					this.GetComponentInParent<Car1>().positioner = other.transform.position;
					this.GetComponentInParent<Car1>().rotater = Quaternion.Euler (0, 0, 180);
					this.GetComponentInParent<Car1>().SouthStall = true;
				}
			}
		}

		/************************EXITING**************************/
		if (other.tag == "Exit") {
			if (this.GetComponentInParent<Car1>().touchedLot == true) {

			}
		}
	}
}
