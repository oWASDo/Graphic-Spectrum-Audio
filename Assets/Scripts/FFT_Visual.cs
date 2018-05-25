using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFT_Visual : MonoBehaviour {
    public GameObject FFTSinglePrefab;
    protected GameObject[] FFTCubes;
    public FFT_Analyzer FFTAnalyzer;

    public bool averageOut, avBufferedOut, avBuffNormalizedOut;

    //--- single FFTprefab features
    public Transform startPosT, endPosT; //The equalizer cubes will be placed between startPosT and endPosT
    protected float size; //x scale, depending on the distance between startPosT and endPosT
    public float depth = 1.5f; //z scale
    public Color lowFCol, highFCol; //we'll interpolate also color between the equalizer cubes
    //---

    //FFT_Analyzer output might be too low to visualize. We need a minimum size (startSize) and a boost value
    //just in case we want to increase the entire effect
    public float FFTBoost = 1;
    public float startSize = 1;

    void Start () {
        OnStart();
       
    }

    virtual public void OnStart()
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
            newFFTSingleObj.transform.GetComponent<Renderer>().material.color = Color.Lerp(lowFCol, highFCol, frac);
            FFTCubes[i] = newFFTSingleObj;
        }
    }

	void Update () {
        OnUpdate();
    }
    virtual public void OnUpdate()
    {
        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            if (averageOut)
                FFTCubes[i].transform.localScale = new Vector3(size, FFTAnalyzer.Out[i] * FFTBoost + startSize, depth);
            else if (avBufferedOut)
                FFTCubes[i].transform.localScale = new Vector3(size, FFTAnalyzer.OutBuffered[i] * FFTBoost + startSize, depth);
            else if (avBuffNormalizedOut)
                FFTCubes[i].transform.localScale = new Vector3(size, FFTAnalyzer.OutBuffNormalized[i] * FFTBoost + startSize, depth);
        }
    }
}
