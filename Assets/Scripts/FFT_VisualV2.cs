using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFT_VisualV2 : FFT_Visual
{



	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate();
	}

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    public override void OnStart()
    {
        FFTCubes = new GameObject[AudioUtils.OUT_SAMPLES];

        float d = Vector3.Distance(startPosT.position, endPosT.position);
        size = d / (float)AudioUtils.OUT_SAMPLES;

        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            GameObject newFFTSingleObj = Instantiate(FFTSinglePrefab, this.transform);
            float frac = i / (float)AudioUtils.OUT_SAMPLES;
            newFFTSingleObj.transform.position = Vector3.Lerp(startPosT.position, endPosT.position, frac);
            newFFTSingleObj.transform.rotation = Quaternion.Slerp(startPosT.rotation, endPosT.rotation, frac);
            newFFTSingleObj.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.Lerp(lowFCol, highFCol, frac);
            FFTCubes[i] = newFFTSingleObj;
        }
    }
}
