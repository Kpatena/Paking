using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public static int initialScore;
	
	public static Text scoreText;
	
	void Start(){

		scoreText = GetComponent<Text>();

		initialScore = 0;

	}
	
	void Update(){

		if (initialScore < 0) {

			initialScore = 0;

		}

		scoreText.text = "Score: " + initialScore.ToString ();

	}
	
	public static void addPoints(int addPoint){

		initialScore += addPoint;

	}
	
	public static void decreasePoints(){

		if (initialScore > 0)
			initialScore -= 50;

	}
}
