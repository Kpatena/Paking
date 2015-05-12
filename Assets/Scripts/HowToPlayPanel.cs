using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class HowToPlayPanel : MonoBehaviour {
	
	Canvas canvas;
	
	void Start()
	{
		// sets canvas to variable
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}

	public void displayRules(){
		canvas.enabled = !canvas.enabled;
	}
}