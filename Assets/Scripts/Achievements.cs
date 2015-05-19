using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Achievements : MonoBehaviour {

	Canvas canvas;

	public static bool noCollisions = false;
	public static bool allStars = false;
	public static bool BeaTENtheGame = false;
	public Button b;
	public Cheeves[] AchieveList;
	const string privateCode = "rPORE27MGUeUnYiDZ4KB5gKvFn881dpUqi2JEfrNG14g";
	const string publicCode = "5559b8cc6e51b6238c7462d4";
	const string webURL = "http://dreamlo.com/lb/";

	public Image star;
	public Image ten; 
	public Image collision;
	
	void Start ()
	{
		star = star.GetComponent<Image> ();
		ten = ten.GetComponent<Image> ();
		collision = collision.GetComponent<Image> ();

		Debug.Log (PlayerPrefs.GetInt ("NC"));
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		b.onClick.AddListener(CheckAchievements);  // This also works
	}
	
	private void CheckAchievements()
	{
		if (PlayerPrefs.GetInt ("NC") == 1) {
			Color c = collision.color;
			c.a = 1f;
			collision.color = c;
			noCollisions = true;
		} else {
			Color c = collision.color;
			c.a = 0.5f;
			collision.color = c;
		}

		if (PlayerPrefs.GetInt ("AS") == 1) {
			Color c = star.color;
			c.a = 1f;
			star.color = c;
			allStars = true;
		} else {
			Color c = star.color;
			c.a = 0.5f;
			star.color = c;
		}

		if (PlayerPrefs.GetInt ("BT") == 1) {
			Color c = ten.color;
			c.a = 1f;
			ten.color = c;
			BeaTENtheGame = true;
		} else {
			Color c = ten.color;
			c.a = 0.5f;
			ten.color = c;
		}
	}


//	//*****Add*****//
//	public void AddNewAchievemtns(string username, int noCollisions, int allStar, int beaten) {
//		StartCoroutine (UploadAchievements(username, noCollisions, allStar, beaten));
//	}
//	
//	IEnumerator UploadAchievements(string username, int noCollisions, int allStar, int beaten) {
//		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + noCollisions + "/" + allStar + "/" + beaten);
//		yield return www;
//		
//		if (string.IsNullOrEmpty (www.error))
//			print ("Upload Successful");
//		else {
//			print ("Error Uploading" + www.error);
//		}
//	}
//
//	/******Download******/
//	public void DownloadAchievements() {
//		StartCoroutine ("DownloadAchievementsFromDatabase");
//	}
//	IEnumerator DownloadAchievementsFromDatabase() {
//		WWW www = new WWW (webURL + publicCode + "/pipe/");
//		yield return www;
//		
//		if (string.IsNullOrEmpty (www.error))
//			Check (www.text);
//		else {
//			print ("Error Downloading" + www.error);
//		}
//	}
//	
//	public void Check(string textStream) {
//		string[] entries = textStream.Split (new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
//		AchieveList = new Cheeves[entries.Length];
//		
//		for (int i = 0; i < entries.Length; i++) {
//			string[] entryInfo = entries[i].Split (new char[] {'|'});
//			string username = entryInfo[0];
//			int noCollisions = int.Parse (entryInfo[1]);
//			int allStar = int.Parse (entryInfo[2]);
//			int beaten = int.Parse (entryInfo[3]);
//			AchieveList[i] = new Cheeves(username, noCollisions, allStar, beaten);
//			if (PlayerPrefs.GetString ("Username") == AchieveList[i].username) {
//				PlayerPrefs.SetInt ("NC", AchieveList[i].noCollisions);
//				PlayerPrefs.SetInt ("AS", AchieveList[i].allStar);
//				PlayerPrefs.SetInt ("BT", AchieveList[i].beaten);
//			} else {
//				PlayerPrefs.SetInt ("NC", 0);
//				PlayerPrefs.SetInt ("AS", 0);
//				PlayerPrefs.SetInt ("BT", 0);
//			}
//
//			PlayerPrefs.Save ();
//		}
//	}

	public void displayAchievements(){
		canvas.enabled = !canvas.enabled;
	}
}

public struct Cheeves {
	public string username;
	public int noCollisions;
	public int allStar;
	public int beaten;
	
	public Cheeves(string _username, int _noCollisions, int _allStar, int _beaten) {
		username = _username;
		noCollisions = _noCollisions;
		allStar = _allStar;
		beaten = _beaten;
		
	}
}
