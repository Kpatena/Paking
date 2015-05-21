using UnityEngine;
using System.Collections;

public class RotateText : MonoBehaviour {

	int counter = 0;
	public GameObject button;

	// Update is called once per frame
	void Update () {
		if (counter < 10) {
			button.transform.Rotate (Vector3.right * Time.deltaTime);
			counter++;
		}
		if (counter > 10) {
			button.transform.Rotate (Vector3.left * Time.deltaTime);
			counter++;
			if (counter == 20){
				counter = 0;
			}
		}

	}
}
