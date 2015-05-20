using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Username : MonoBehaviour {
	const string privateCode = "rPORE27MGUeUnYiDZ4KB5gKvFn881dpUqi2JEfrNG14g";
	const string publicCode = "5559b8cc6e51b6238c7462d4";
	const string webURL = "http://dreamlo.com/lb/";
	public InputField input;
	public Text t;
	public NC[] NCAchieveList;
	public AS[] ASAchieveList;
	public BT[] BTAchieveList;
	private string ncoll = "noCollisions";
	private string aStar = "allStar";
	private string beat = "beaten";
	private bool gotUserNC = false;
	private bool gotUserAS = false;
	private bool gotUserBT = false;
	public Button b;

	public Image star;
	public Image ten; 
	public Image collision;

	// Use this for initialization
	void Start () {
		star = star.GetComponent<Image> ();
		ten = ten.GetComponent<Image> ();
		collision = collision.GetComponent<Image> ();

		input.onEndEdit.AddListener(username);  // This also works
		b.onClick.AddListener(checkAchievements);
		if (PlayerPrefs.GetString ("Username") == null)
			t.text = "Welcome Guest!";
		else
			t.text = "Welcome " + PlayerPrefs.GetString ("Username") + "!";
	}

	private void username(string name) {
		PlayerPrefs.SetString ("Username", name);
		t.text = "Welcome " + name + "!";
		gotUserNC = false;
		gotUserAS = false;
		gotUserBT = false;
		DownloadNCAchievement ();
		DownloadASAchievement ();
		DownloadBTAchievement ();
		PlayerPrefs.Save ();
	}

	private void checkAchievements() {
		DownloadNCAchievement ();
		DownloadASAchievement ();
		DownloadBTAchievement ();
		PlayerPrefs.Save ();
	}

	//**uploading the no collisions achievement from database**//
	public void DownloadNCAchievement() {
		StartCoroutine ("DownloadNCAchievementFromDatabase");
	}

	IEnumerator DownloadNCAchievementFromDatabase() {
		WWW www = new WWW (webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error))
			CheckNC (www.text);
		else {
			print ("Error Downloading" + www.error);
		}
	}
	
	public void CheckNC(string textStream) {
		string[] entries = textStream.Split (new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		NCAchieveList = new NC[entries.Length];
		
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries [i].Split (new char[] {'|'});
			string username = entryInfo [0];
			int noCollisions = int.Parse (entryInfo [1]);
			NCAchieveList [i] = new NC (username, noCollisions);
			if (PlayerPrefs.GetString ("Username") + ncoll == NCAchieveList [i].username) {
				Debug.Log ("Got User");
				gotUserNC = true;
				if (NCAchieveList [i].noCollisions == 1) {
					Color c = collision.color;
					c.a = 1f;
					collision.color = c;
					Debug.Log ("Worked NC");
				} else {
					Color c = collision.color;
					c.a = 0.5f;
					collision.color = c;
					Debug.Log ("Not Worked NC");
				}

			} else if (gotUserNC == false){
				Color c = collision.color;
				c.a = 0.5f;
				collision.color = c;
			}
		}
	}


	//**uploading the all-star achievement from database**//
	public void DownloadASAchievement() {
		StartCoroutine ("DownloadASAchievementFromDatabase");
	}

	IEnumerator DownloadASAchievementFromDatabase() {
		WWW www = new WWW (webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error))
			CheckAS (www.text);
		else {
			print ("Error Downloading" + www.error);
		}
	}
	
	public void CheckAS(string textStream) {
		string[] entries = textStream.Split (new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		ASAchieveList = new AS[entries.Length];
		
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries [i].Split (new char[] {'|'});
			string username = entryInfo [0];
			int _allStar = int.Parse (entryInfo [1]);
			ASAchieveList [i] = new AS (username, _allStar);
			if (PlayerPrefs.GetString ("Username") + aStar == ASAchieveList [i].username) {
				gotUserAS = true;
				if (ASAchieveList [i].allStar == 1) {
					Color c = star.color;
					c.a = 1f;
					star.color = c;
					Debug.Log ("Worked AS");
				} else {
					Color c = star.color;
					c.a = 0.5f;
					star.color = c;
				}
			
			} else if (gotUserAS == false) {
				Color c = collision.color;
				c.a = 0.5f;
				star.color = c;
			}
		}
	}


	//**uploading the beaTen achievement from database**//
	public void DownloadBTAchievement() {
		StartCoroutine ("DownloadBTAchievementFromDatabase");
	}

	IEnumerator DownloadBTAchievementFromDatabase() {
		WWW www = new WWW (webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error))
			CheckBT (www.text);
		else {
			print ("Error Downloading" + www.error);
		}
	}
	
	public void CheckBT(string textStream) {
		string[] entries = textStream.Split (new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		BTAchieveList = new BT[entries.Length];
		
		for (int i = 0; i < entries.Length; i++) {
			string[] entryInfo = entries[i].Split (new char[] {'|'});
			string username = entryInfo[0];
			int beaten = int.Parse (entryInfo[1]);
			BTAchieveList[i] = new BT(username, beaten);
			if (PlayerPrefs.GetString ("Username")+ beat == BTAchieveList[i].username) {
				gotUserBT = true;
				if (BTAchieveList [i].beaten == 1) {
					Color c = ten.color;
					c.a = 1f;
					ten.color = c;
				} else if (gotUserBT == false){
					Color c = ten.color;
					c.a = 0.5f;
					ten.color = c;
				}
			} else if (gotUserBT == false) {
				Color c = collision.color;
				c.a = 0.5f;
				ten.color = c;
			}

		}
	}
}
