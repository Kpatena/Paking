using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelComplete : MonoBehaviour {
	
	public static Canvas canvas;
	public static bool isPressed = true;

	void Start()
	{
		// sets canvas to variable and disables
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}

	public static void PopUp()
	{
		canvas.enabled = true;
	}
	
	public void restartScene(string scene){
		isPressed = MuteButton.pressed;
		Application.LoadLevel (scene);
//		if (isPressed == true) {
//			MuteButton.audio.mute = false;
//		} else {
//			MuteButton.audio.mute = true;
//		}
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
	
	public void QuitToSelect(string scene)
	{
		Application.LoadLevel (scene);
	}

	public void NextLevel(string scene)
	{
		Application.LoadLevel (scene);
	}
}
