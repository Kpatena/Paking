using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainMenu : MonoBehaviour {

	Canvas canvas;

	public string play;
	public string mainMenu;

	void Start()
	{
		// sets canvas to variable
		canvas = GetComponent<Canvas>();
	}

	public void LevelSelect(){
		Application.LoadLevel (play);
	}
	
	public void Rules(){
		canvas.enabled = !canvas.enabled;
	}
	
	public void QuitGame(){
		Application.Quit ();
	}
	
	public void PressedBack(){
		Application.LoadLevel (mainMenu);
	}
}