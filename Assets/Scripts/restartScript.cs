using UnityEngine;
using System.Collections;

public class restartScript : MonoBehaviour {
	public void restartScene(string scene){
		Application.LoadLevel (scene);
	}
}
