using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour {

	public static AudioSource audio;
	public static bool pressed;

	void Awake() {
		audio = GetComponent<AudioSource>();
		if(LevelComplete.isPressed == false){
			audio.mute = true;
		}
	}

	public void MutePressed (){
		//DontDestroyOnLoad (this);
		if (audio.mute) {
			pressed = true;
			audio.mute = false;
		} else {
			pressed = false;
			audio.mute = true;
		}
	}
}