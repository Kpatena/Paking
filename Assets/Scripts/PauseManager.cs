using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
	Canvas canvas;
	
	void Start()
	{
		// sets canvas to variable and disables
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	void Update()
	{
		// PAUSES IF ESCAPE KEY IS PRESSED
		//if (Input.GetKeyDown(KeyCode.Escape))
		//{
		//	Pause();
		//}
	}
	
	public void Pause()
	{
		// enables the pause canvas and stops the game
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void restartScene(string scene){
		// restarts the scene and starts the game time again
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Application.LoadLevel (scene);
	}
	
	public void Quit()
	{
		// stops the editor playing if in editor
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		// quits application if running standalone
		#else 
		Application.Quit();
		#endif
	}
}
