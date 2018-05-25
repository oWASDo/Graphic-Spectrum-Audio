using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]
public class StartAfterSeconds : MonoBehaviour {

	AudioSource audS;
	public float Delay;
	// Use this for initialization
	void Awake () {
		audS = GetComponent<AudioSource> ();
		audS.PlayDelayed (Delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
