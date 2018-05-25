using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FFTType
{
	OUT, OUT_BUFFER, OUT_BUFFER_NORMALIZED
}

public class SetEqualizer : MonoBehaviour {

	public FFT_Analyzer FFTAnalyzer;
	public FFTType Type;
	private Transform[] objs;
	public float StartHighOffset;
	// Use this for initialization
	void Start () {
		objs = new Transform[transform.childCount];
		for (int i = 0; i < objs.Length; i++) {
			objs [i] = transform.GetChild (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
		{
			if (Type == FFTType.OUT) {
				objs [i].transform.localScale = new Vector3 (0.5f, StartHighOffset + FFTAnalyzer.Out[i],0.5f);
			}
			else if (Type == FFTType.OUT_BUFFER) {
				objs [i].transform.localScale = new Vector3 (0.5f, StartHighOffset + FFTAnalyzer.OutBuffered[i],0.5f);
			}
			else if (Type == FFTType.OUT_BUFFER_NORMALIZED) {
				objs [i].transform.localScale = new Vector3 (0.5f, StartHighOffset + FFTAnalyzer.OutBuffNormalized[i],0.5f);
			}
		}
	}
}
