using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	Text text;

	void Start(){
		text = GetComponent<Text>();
	}

	void Update(){
		text.text = ScoreManager.initialScore.ToString();
	}
}

