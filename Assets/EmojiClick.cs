using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EmojiClick : MonoBehaviour {
	TextTimer textTimer;
	Score scoreObj;

	void Start() {
//		Debug.Log (name + " started.");
		scoreObj = GameObject.Find ("Score").GetComponent<Score> ();
	}

	void Awake() {
		textTimer = GameObject.Find ("GameObject").GetComponent<TextTimer>();
	}

	public void checkEmoji() {
		
		scoreObj.neverText = false;
		// Get the name of the sprite of active button
		string spriteName = "";
		Button[] rBtns = {textTimer.r1, textTimer.r2, textTimer.r3};
		Button aBtn;

		aBtn = rBtns [textTimer.responseNum];
		spriteName = aBtn.GetComponent<Image> ().sprite.name;
		// Compare the names
		if (name == spriteName) {
			GameObject.Find ("Speedometer").GetComponent<AudioSource> ().Play ();
			// If right, advance the current emoji
//			Debug.Log ("Right One!");
			textTimer.responseNum++;
			aBtn.interactable = true;
		} else {
			GameObject.Find ("Phone").GetComponent<AudioSource> ().Play ();
//			Debug.Log("WRONG! This button is " + name + " and you should have clicked " + spriteName);
			scoreObj.perfectRun = false;
			scoreObj.ResetMulti();
		}

	}
}
