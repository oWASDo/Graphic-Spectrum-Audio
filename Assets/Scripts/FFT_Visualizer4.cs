using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFT_Visualizer4 : FFT_Visual
{
    
    public ParticleSystem sis0, sis1;
    public float Range;
    // Use this for initialization
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
    public override void OnStart()
    {
        sis0 = Instantiate(FFTSinglePrefab, transform).GetComponent<ParticleSystem>();
        sis1 = Instantiate(FFTSinglePrefab, transform).GetComponent<ParticleSystem>();
        sis1.transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    public void PerformAudio(float[] floats)
    {
        if (averageOut || avBufferedOut)
        {
            if (floats[0] > 0.05f || floats[1] > 0.05f || floats[2] > 0.05f)
            {
                sis0.Emit(3);
                sis1.Emit(3);
            }
            else if (floats[3] > 0.05f || floats[4] > 0.05f || floats[5] > 0.05f)
            {
                sis0.Emit(2);
                sis1.Emit(2);
            }
            else if (floats[6] > 0.05f || floats[7] > 0.05f)
            {
                sis0.Emit(1);
                sis1.Emit(1);
            }
        }
        else
        {
            if (floats[0] > Range || floats[1] > Range || floats[2] > Range)
            {
                sis0.Emit(3);
                sis1.Emit(3);
            }
            else if (floats[3] > Range || floats[4] > Range || floats[5] > Range)
            {
                sis0.Emit(2);
                sis1.Emit(2);
            }
            else if (floats[6] > Range || floats[7] > Range)
            {
                sis0.Emit(1);
                sis1.Emit(1);
            }
        }
    }

    public override void OnUpdate()
    {
        if (averageOut)
        {
            PerformAudio(FFTAnalyzer.Out);
        }
        else if (avBufferedOut)
        {
            PerformAudio(FFTAnalyzer.OutBuffered);
        }
        else if (avBuffNormalizedOut)
        {
            PerformAudio(FFTAnalyzer.OutBuffNormalized);
        }
    }
}
