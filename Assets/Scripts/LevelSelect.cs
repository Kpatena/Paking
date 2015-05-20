using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelSelect : MonoBehaviour {

	public string level1;
	public string level2;
	public string level3;
	public string level4;
	public string level5;
	public string level6;
	public string level7;
	public string level8;
	public string level9;
	public string level10;
	public string mainMenu;
	public static bool didItQuit;

	public void LevelOne(){
		Application.LoadLevel (level1);
		Time.timeScale = 1;
	}

	public void LevelTwo(){
		Application.LoadLevel (level2);
		Time.timeScale = 1;
	}

	public void LevelThree(){
		Application.LoadLevel (level3);
		Time.timeScale = 1;
	}

	public void LevelFour(){
		Application.LoadLevel (level4);
		Time.timeScale = 1;
	}

	public void LevelFive(){
		Application.LoadLevel (level5);
		Time.timeScale = 1;
	}

	public void LevelSix(){
		Application.LoadLevel (level6);
		Time.timeScale = 1;
	}

	public void LevelSeven(){
		Application.LoadLevel (level7);
		Time.timeScale = 1;
	}

	public void LevelEight(){
		Application.LoadLevel (level8);
		Time.timeScale = 1;
	}

	public void LevelNine(){
		Application.LoadLevel (level9);
		Time.timeScale = 1;
	}

	public void LevelTen(){
		Application.LoadLevel (level10);
		Time.timeScale = 1;
	}

	public void PressedBack(){
		Application.LoadLevel (mainMenu);
	}
}
