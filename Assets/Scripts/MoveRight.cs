using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveRight : MonoBehaviour
{
	public static int movementSpeed = 5;
	float seconds = 6;
	float secondsTwo = 10;
	float milliseconds = 0;
	float timerDone = 0;
	float startTimer = 0;
	public GameObject Crash;
	public GameObject Exclamation;
	public GameObject Timer;
	public GameObject CountDown5;
	public GameObject CountDown4;
	public GameObject CountDown3;
	public GameObject CountDown2;
	public GameObject CountDown1;
	private GameObject ReadyToMove;
	private GameObject Destroy5;
	private GameObject Destroy4;
	private GameObject Destroy3;
	private GameObject Destroy2;
	private GameObject Destroy1;
	bool yes1 = true;
	bool yes2 = true;
	bool yes3 = true;
	bool yes4 = true;
	bool yes5 = true;
	Vector3 positioner;
	Quaternion rotater;

	void Update(){


		if (movementSpeed == 0) {
			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.transform.rotation, 10 * Time.deltaTime); 
			this.transform.position = Vector3.MoveTowards(this.transform.position, positioner, 60 * Time.deltaTime);

			if(secondsTwo == 0){ //Use this part to start moving again and destroy exclamation mark
				Destroy (ReadyToMove);
			}

			if(seconds == 0){
				startTimer++;
				if(timerDone == 0){
					timerDone++;
					Destroy (Destroy1);
					ReadyToMove = Instantiate (Exclamation, this.transform.position, this.transform.rotation) as GameObject;
				}
				return;
			}

			if(startTimer == 0){
				if(seconds == 5){
					if(yes5 == true){
						yes5 = false;
						Destroy5 = Instantiate (CountDown5, this.transform.position, this.transform.rotation) as GameObject;
					}
				}
				if(seconds == 4){
					if(yes4 == true){
						yes4 = false;
						Destroy (Destroy5);
						Destroy4 = Instantiate (CountDown4, this.transform.position, this.transform.rotation) as GameObject;
					}
				}
				if(seconds == 3){
					if(yes3 == true){
						yes3 = false;
						Destroy (Destroy4);
						Destroy3 = Instantiate (CountDown3, this.transform.position, this.transform.rotation) as GameObject;
					}
				}
				if(seconds == 2){
					if(yes2 == true){
						yes2 = false;
						Destroy (Destroy3);
						Destroy2 = Instantiate (CountDown2, this.transform.position, this.transform.rotation) as GameObject;
					}
				}
				if(seconds == 1){
					if(yes1 == true){
						yes1 = false;
						Destroy (Destroy2);
						Destroy1 = Instantiate (CountDown1, this.transform.position, this.transform.rotation) as GameObject;
					}
				}
			}
			if(this.transform.position == positioner){
				if (milliseconds <= 0) {
					seconds--;
					secondsTwo--;
					milliseconds = 100;
				}
				
				milliseconds -= Time.deltaTime * 100;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<LotBehaviour> () != null) {
			positioner = other.transform.position;
			//rotater = other.transform.rotation;
			movementSpeed = 0;
		}
	}
}