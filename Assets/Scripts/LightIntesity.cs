using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntesity : MonoBehaviour {

	float  MaxIntensity;
	public Light light;
	// Use this for initialization
	void Start () {
		MaxIntensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		AudioSource audSource = GetComponent<AudioSource> ();
		if (audSource != null) {
			//float[] data = new float[audSource.clip.samples];
			//audSource.clip.GetData (data,audSource.timeSamples);
			//Debug.Log (data[audSource.clip.samples - 1]);
			//audSource.ou
			float[] sample = audSource.GetOutputData(1024,0);
			float sum = 0;
			for (int i = 0; i < sample.Length; i++) {
				sum += sample [i];
			}
			//float avarage = sum / sample.Length - 1;
			//Debug.Log (sum);

			light.intensity = Mathf.Abs (sum) * 5;
		}
	}
}
