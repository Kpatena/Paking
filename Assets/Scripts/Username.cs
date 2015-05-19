using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Username : MonoBehaviour {
	const string privateCode = "rPORE27MGUeUnYiDZ4KB5gKvFn881dpUqi2JEfrNG14g";
	const string publicCode = "5559b8cc6e51b6238c7462d4";
	const string webURL = "http://dreamlo.com/lb/";
	public InputField input;
	public Text t;
	public Cheeves[] AchieveList;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("NC", 0);
		PlayerPrefs.SetInt ("AS", 0);
		PlayerPrefs.SetInt ("BT", 0);
		DownloadAchievements ();
		input.onEndEdit.AddListener(username);  // This also works
		if (PlayerPrefs.GetString ("Username") == null)
			t.text = "Welcome Guest!";
		else
			t.text = "Welcome " + PlayerPrefs.GetString ("Username") + "!";
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	private void username(string name) {
		PlayerPrefs.SetString ("Username", name);
		Debug.Log (PlayerPrefs.GetString ("Username"));
		t.text = "Welcome " + name + "!";
		DownloadAchievements ();
		PlayerPrefs.Save ();
	}

	public void DownloadAchievements() {
		StartCoroutine ("DownloadAchievementsFromDatabase");
	}
	IEnumerator DownloadAchievementsFromDatabase() {
		WWW www = new WWW (webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error))
			Check (www.text);
		else {
			print ("Error Downloading" + www.error);
		}
	}
	
	public void Check(string textStream) {
		string[] entries = textStream.Split (new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		AchieveList = new Cheeves[entries.Length];
		
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries[i].Split (new char[] {'|'});
			string username = entryInfo[0];
			int noCollisions = int.Parse (entryInfo[1]);
			int allStar = int.Parse (entryInfo[2]);
			int beaten = int.Parse (entryInfo[3]);
			AchieveList[i] = new Cheeves(username, noCollisions, allStar, beaten);
			if (PlayerPrefs.GetString ("Username") == AchieveList[i].username) {
				PlayerPrefs.SetInt ("NC", AchieveList[i].noCollisions);
				PlayerPrefs.SetInt ("AS", AchieveList[i].allStar);
				PlayerPrefs.SetInt ("BT", AchieveList[i].beaten);
			} else {
				PlayerPrefs.SetInt ("NC", 0);
				PlayerPrefs.SetInt ("AS", 0);
				PlayerPrefs.SetInt ("BT", 0);
			}

		}
	}
}
