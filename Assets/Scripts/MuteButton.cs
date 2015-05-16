using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour {

	public static AudioSource audio;
	string savedPressed;

	void Awake() {
		audio = GetComponent<AudioSource>();
		savedPressed = PlayerPrefs.GetString ("Pressed");
		if (savedPressed != null) {
			if(savedPressed == "hit"){
				audio.mute = true; 
			} else {
				audio.mute = false;
			}
		}
	}

	public void MutePressed (){
		if (audio.mute) {
			saveButton("released");
			audio.mute = false;
		} else {
			saveButton("hit");
			audio.mute = true;
		}
	}

	public void saveButton (string pressed){
		PlayerPrefs.SetString ("Pressed", pressed);
	}
}