using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float initialTime;

	private Text timeText;

	// Use this for initialization
	void Start () {

		timeText = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (initialTime <= 0) {

				
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
			Application.Quit();

		} else {

			initialTime -= Time.deltaTime;

			timeText.text = "" + Mathf.Round (initialTime);

		}

	}
}
