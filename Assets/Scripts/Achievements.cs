using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Achievements : MonoBehaviour {

	Canvas canvas;

	public Button b;
	const string privateCode = "rPORE27MGUeUnYiDZ4KB5gKvFn881dpUqi2JEfrNG14g";
	const string publicCode = "5559b8cc6e51b6238c7462d4";
	const string webURL = "http://dreamlo.com/lb/";
	
	void Start ()
	{

		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
//	private void CheckAchievements()
//	{
//		if (PlayerPrefs.GetInt ("NC") == 1) {
//			Color c = collision.color;
//			c.a = 1f;
//			collision.color = c;
//			Debug.Log ("Worked NC");
//		} else {
//			Color c = collision.color;
//			c.a = 0.5f;
//			collision.color = c;
//			Debug.Log ("Not Worked NC");
//		}
//
//		if (PlayerPrefs.GetInt ("AS") == 1) {
//			Color c = star.color;
//			c.a = 1f;
//			star.color = c;
//			Debug.Log ("Worked AS");
//		} else {
//			Color c = star.color;
//			c.a = 0.5f;
//			star.color = c;
//		}
//
//		if (PlayerPrefs.GetInt ("BT") == 1) {
//			Color c = ten.color;
//			c.a = 1f;
//			ten.color = c;
//		} else {
//			Color c = ten.color;
//			c.a = 0.5f;
//			ten.color = c;
//		}
//	}


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

public struct NC{
	public string username;
	public int noCollisions;
	
	public NC(string _username, int _noCollisions) {
		username = _username;
		noCollisions = _noCollisions;
		
	}
}

public struct AS{
	public string username;
	public int allStar;

	public AS(string _username, int _allStar) {
		username = _username;
		allStar = _allStar;
	}
}

public struct BT{
	public string username;
	public int beaten;
	
	public BT(string _username, int _beaten) {
		username = _username;
		beaten = _beaten;
		
	}
}
