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
				//audio.mute = true;
				AudioListener.volume = 0;
			} else {
				//audio.mute = false;
				AudioListener.volume = 1;
			}
		}
	}

	public void MutePressed (){
//		//if (audio.mute) {
//		if (AudioListener.volume == 0){
//			saveButton("released");
//			//audio.mute = false;
//			AudioListener.volume = 1;
//		}
		if (AudioListener.volume != 0) {
			saveButton ("hit");
			//audio.mute = true;
			AudioListener.volume = 0;
		} else {
			saveButton("released");
			//audio.mute = false;
			AudioListener.volume = 1;
		}
	}

	public void saveButton (string pressed){
		PlayerPrefs.SetString ("Pressed", pressed);
	}
}