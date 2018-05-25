using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCamera : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Texture texture = cam.targetTexture;
		GetComponent<Renderer> ().material.SetTexture ("Albedo", texture);
	}
}
