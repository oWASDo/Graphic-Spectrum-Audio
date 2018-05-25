using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FFT_Analyzer : MonoBehaviour
{
    AudioSource ASource;
    float[] FFTSamples;
    public float[] Out;
    //---
    float[] decrease;
    public float[] OutBuffered;
    public float startDecreaseVal = 0.005f;
    public float decreaseMul = 1.2f;
    //---
    float[] topValues;
    public float[] OutBuffNormalized;
    
    void Start()
    {
        FFTSamples = new float[AudioUtils.FFT_SAMPLES];
        Out = new float[AudioUtils.OUT_SAMPLES];
        //---
        OutBuffered = new float[AudioUtils.OUT_SAMPLES];
        decrease = new float[AudioUtils.OUT_SAMPLES];
        //---
        OutBuffNormalized = new float[AudioUtils.OUT_SAMPLES];
        topValues = new float[AudioUtils.OUT_SAMPLES];

        ASource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ASource.isPlaying)
        {
            GetFFT();
            GetOutputSamples();
            //---
            GetOutBuffered();
            //---
            GetOutBufferedNorm();
        }
	}

    void GetFFT()
    {
        ASource.GetSpectrumData(FFTSamples, 0, FFTWindow.Blackman);
    }

    void GetOutputSamples()
    {
        //n (0, 512)
        int n = 0;

        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            float average = 0;
            //We must have a result of 2 for i=0, 4 for i=1, etc.
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            //Eg. If we are at the beginning, the first interval of 8 OUT_SAMPLES we are interested in is the SubBass interval,
            //Which is covered with 2 Samples of 43Hz. So we have to Sum the first 2 entry of FFTSamples and divide the result
            //by 2 to get an everage value. So Out[0] = (FFTSamples[0] + FFTSamples[1]) / 2
            for (int j = 0; j < sampleCount; j++)
            {
                //We multiply by (n+1) to compensate for the fact that the peaks get lower at higher frequencies
                average += FFTSamples[n] * (n+1);
                n++;
            }
            average /= sampleCount;
            //Here we compensate again, because values are too small
            Out[i] = average*10;
        }
    }


    void GetOutBuffered()
    {
        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            if (Out[i] > OutBuffered[i])
            {
                OutBuffered[i] = Out[i];
                decrease[i] = startDecreaseVal;
            }
            else
            {
                OutBuffered[i] -= decrease[i];
                if (OutBuffered[i] < 0)
                    OutBuffered[i] = 0;
                decrease[i] *= decreaseMul;
            }
        }
    }

    void GetOutBufferedNorm()
    {
        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            if (topValues[i] < OutBuffered[i])
            {
                topValues[i] = OutBuffered[i];
            }
            OutBuffNormalized[i] = OutBuffered[i] / topValues[i];
        }
    }
}
