using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreStars : MonoBehaviour {

	public float enableStar;

	// Use this for initialization
	void Start () {
		//this.GetComponent<SpriteRenderer> ().enabled = false;
		this.GetComponent<Image> ().enabled = false;
	}
	
	void Update(){
		if(LevelComplete.canvas.enabled){
			if(ScoreManager.initialScore >= enableStar){
				//allow stars to be visible like in indicator
				//this.GetComponent<SpriteRenderer> ().enabled = true;
				this.GetComponent<Image> ().enabled = true;
			}
		}
	}
}
