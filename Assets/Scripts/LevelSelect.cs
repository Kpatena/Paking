using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelSelect : MonoBehaviour {

	public string level1;
	public string level2;
	public string mainMenu;
	public static bool didItQuit;

	public void LevelOne(){
		Application.LoadLevel (level1);
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Time.timeScale = 1;
	}

	public void LevelTwo(){
		Application.LoadLevel (level2);
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Time.timeScale = 1;
	}

	public void PressedBack(){
		Application.LoadLevel (mainMenu);
	}

	public void LevelLock(){
	}
}
