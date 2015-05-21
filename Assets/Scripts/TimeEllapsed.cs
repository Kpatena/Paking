using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeEllapsed : MonoBehaviour {

	const string privateCode = "rPORE27MGUeUnYiDZ4KB5gKvFn881dpUqi2JEfrNG14g";
	const string publicCode = "5559b8cc6e51b6238c7462d4";
	const string webURL = "http://dreamlo.com/lb/";

	public float minutes = 3;
	public float seconds = 0;
	public float milliseconds = 0; 
	public bool ifLevel10;
	bool PopUp = false;
	private AudioSource Victory;
	public Image collision;
	public Image astar;
	public Image BT;
	private AudioSource backgroundMusic;
	private string nocoll = "noCollisions";
	private string ast = "allStar";
	private string beat = "beaten";

	Text text;
	
	void Start(){
		collision.GetComponent<Image>().enabled = false;
		astar.GetComponent<Image>().enabled = false;
		BT.GetComponent<Image>().enabled = false;
		PlayerPrefs.SetInt("noCrash", 0);
		PlayerPrefs.Save ();
		Debug.Log (PlayerPrefs.GetInt ("noCrash"));
		text = GetComponent<Text>();
		PopUp = false;
	}
	
	void Update(){
		if (minutes == 0 && seconds == 0) {
//			#if UNITY_EDITOR
//			UnityEditor.EditorApplication.isPlaying = false;
//			#endif
			if(PopUp == false){
				PopUp = true;
				LevelComplete.PopUp();
				Time.timeScale = Time.timeScale == 0 ? 1 : 0;
				Victory = GetComponentInChildren<AudioSource>();
				Victory.Play ();
				if (PlayerPrefs.GetInt("noCrash")== 0) {
					collision.GetComponent<Image>().enabled = true;
					AddNCAchievement(PlayerPrefs.GetString ("Username") + nocoll, 1);
					PlayerPrefs.SetInt("noCrash", 1);
					PlayerPrefs.Save ();
				}
				if(ScoreManager.initialScore >= 2500) {
					astar.GetComponent<Image>().enabled = true;
					AddASAchievement(PlayerPrefs.GetString ("Username") + ast, 1);
				}

				if(ifLevel10 && ScoreManager.initialScore >= 2500) {
					BT.GetComponent<Image>().enabled = true;
					AddBTAchievement(PlayerPrefs.GetString ("Username") + beat, 1);
				}

			}
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

	//*****Add no collision achievement to database*****//
	public void AddNCAchievement(string username, int noCollisions) {
		StartCoroutine (UploadNCAchievement(username, noCollisions));
	}
		
	IEnumerator UploadNCAchievement(string username, int noCollisions) {
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + noCollisions);
		yield return www;
			
		if (string.IsNullOrEmpty (www.error))
			print ("Upload Successful");
		else {
			print ("Error Uploading" + www.error);
		}
	}

	//*****Add all-star achievement to database*****//
	public void AddASAchievement(string username, int aStar) {
		StartCoroutine (UploadASAchievement(username, aStar));
	}
	
	IEnumerator UploadASAchievement(string username, int aStar) {
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + aStar);
		yield return www;
		
		if (string.IsNullOrEmpty (www.error))
			print ("Upload Successful");
		else {
			print ("Error Uploading" + www.error);
		}
	}

	//*****Add beatten achievement to database*****//
	public void AddBTAchievement(string username, int beat) {
		StartCoroutine (UploadASAchievement(username, beat));
	}
	
	IEnumerator UploadBTAchievement(string username, int beat) {
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + beat);
		yield return www;
		
		if (string.IsNullOrEmpty (www.error))
			print ("Upload Successful");
		else {
			print ("Error Uploading" + www.error);
		}
	}
}