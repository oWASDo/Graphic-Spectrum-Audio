using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChannel : MonoBehaviour {

	public bool[] ToGet= new bool[AudioUtils.OUT_SAMPLES];
	public bool ModifyBlue, ModifyRed, ModifyGreen; 
	public bool OutBufferMode,OutMode,OutBuffNormalized;
	public FFT_Analyzer FFTAnalyzer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Avarage = 0;
		int TrueBool = 0;
		for (int i = 0; i < ToGet.Length; i++) {
			if (ToGet[i]) {
				if (OutBufferMode) {
					Avarage += FFTAnalyzer.OutBuffered [i];
				}
				else if (OutMode) {
					Avarage += FFTAnalyzer.Out [i];
				}
				else if (OutBuffNormalized) 
				{
					Avarage += FFTAnalyzer.OutBuffNormalized[i];
				}
				TrueBool++;
			}
		}
		Avarage = Avarage / TrueBool;

		int numberOfChild = transform.childCount;

		for (int i = 0; i < numberOfChild; i++) {
			if (ModifyGreen) {
				transform.GetChild (i).GetComponent<Light>().color = new Color(0,Avarage,0);
			}
			else if (ModifyBlue) {
				transform.GetChild (i).GetComponent<Light>().color = new Color(0,0,Avarage);
			}
			else if (ModifyRed) {
				transform.GetChild (i).GetComponent<Light>().color = new Color(Avarage,0,0);
			}
		}
	}
}

