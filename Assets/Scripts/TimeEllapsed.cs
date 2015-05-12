using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeEllapsed : MonoBehaviour {
	
	float minutes = 3;
	float seconds = 0;
	float milliseconds = 0; 

	Text text;
	
	void Start(){
		text = GetComponent<Text>();
	}
	
	void Update(){
		if (minutes == 0 && seconds == 0) {
			return;			
		}
		if (milliseconds <= 0) {
			if (seconds <= 0) {
				minutes--;
				seconds = 59;
			} else if (seconds >= 0) {
				seconds--;
			}
			milliseconds = 100;
		}
		milliseconds -= Time.deltaTime * 100;
		text.text = string.Format ("{0:0}:{1:00}", minutes, seconds);
	}
}