using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour {
	
	public static int score;
	
	Text text;
	
	void Start(){
		text = GetComponent<Text>();
		score = 0;
	}
	
	void Update(){
		if (score < 0) {
			score = 0;
		}
		text.text = "" + score;
	}
	
	public static void addPoints(int addPoint){
		score += addPoint;
	}

	public static void decreasePoints(){
		score -= 500;
	}
}