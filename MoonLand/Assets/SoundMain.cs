﻿
using UnityEngine;

public class SoundMain : MonoBehaviour {

	private AudioSource mainSound;
	void Awake () {
		if(Sonido.soundOn){
		mainSound=GetComponent<AudioSource>();
		mainSound.Play();
		//mainSound.volume=0.2f;
		}
		}
	
	// Update is called once per frame
}
