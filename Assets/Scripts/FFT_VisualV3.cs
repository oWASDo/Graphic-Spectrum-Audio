using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type0
{
    FIRST,
    SECOND,
    THIRD,
    FORTH,
    FIFTH
}
public class FFT_VisualV3 : FFT_Visual
{
    private float[] floats;
    public Type0 T;
    // Use this for initialization
    void Start()
    {
        OnStart();
        floats = new float[]
        {
            0.2f,0.4f,0.8f,1f,0.8f,0.4f,0.2f,0.1f
        };
    }

    // Update is called once per frame
    void Update()
    {
        //SetColor();
        OnUpdate();
    }

    public override void OnStart()
    {
        FFTCubes = new GameObject[AudioUtils.OUT_SAMPLES];
        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            GameObject part = Instantiate(FFTSinglePrefab, transform);
            FFTCubes[i] = part;
            part.transform.localPosition = new Vector3(0, 0, 0);
            part.transform.localRotation = Quaternion.Euler(-90f, 45f * i, 0);
        }

    }
    public override void OnUpdate()
    {

        for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
        {
            ParticleSystem sis = transform.GetChild(i).GetComponent<ParticleSystem>();
            ParticleSystem.Particle[] particlsese = new ParticleSystem.Particle[8];
            int partsNum = sis.GetParticles(particlsese);
            //Debug.Log(partsNum);
            for (int j = 0; j < partsNum; j++)
            {
                if (averageOut)
                {
                    Transform t = sis.transform;
                    Quaternion q = new Quaternion(t.localRotation.x, t.localRotation.y, t.localRotation.z, t.localRotation.w);
                    sis.transform.localRotation = Quaternion.Euler(-90f, (-45f * j) / 8, 0);
                    Vector3 vect = Vector3.zero;

                    switch (T)
                    {
                        case Type0.FIRST:
                            vect = EffectOne(t, i, j, FFTAnalyzer.Out[i]);
                            break;

                        case Type0.SECOND:
                            vect = EffectTwo(t, i, j, FFTAnalyzer.Out[i]);
                            break;
                        case Type0.THIRD:
                            vect = EffectThree(t, i, j, FFTAnalyzer.Out[i]);
                            break;
                        case Type0.FORTH:
                            vect = EffectForth(t, i, j, FFTAnalyzer.Out[i]);
                            break;
                        case Type0.FIFTH:
                            vect = EffectFifth(t, i, j, FFTAnalyzer.Out[i]);
                            break;
                    }
                    particlsese[j].position = vect;
                    sis.transform.localRotation = q;

                }
                else if (avBufferedOut)
                {
                    Transform t = sis.transform;
                    Quaternion q = new Quaternion(t.localRotation.x, t.localRotation.y, t.localRotation.z, t.localRotation.w);
                    sis.transform.localRotation = Quaternion.Euler(-90f, (-45f * j) / 8, 0);
                    Vector3 vect = Vector3.zero;

                    switch (T)
                    {
                        case Type0.FIRST:
                            vect = EffectOne(t, i, j, FFTAnalyzer.OutBuffered[i]);
                            break;

                        case Type0.SECOND:
                            vect = EffectTwo(t, i, j, FFTAnalyzer.OutBuffered[i]);
                            break;

                        case Type0.THIRD:
                            vect = EffectThree(t, i, j, FFTAnalyzer.OutBuffered[i]);
                            break;

                        case Type0.FORTH:
                            vect = EffectForth(t, i, j, FFTAnalyzer.OutBuffered[i]);
                            break;
                        case Type0.FIFTH:
                            vect = EffectFifth(t, i, j, FFTAnalyzer.OutBuffered[i]);
                            break;
                    }
                    particlsese[j].position = vect;
                    sis.transform.localRotation = q;
                }
                else if (avBuffNormalizedOut)
                {
                    Transform t = sis.transform;
                    Quaternion q = new Quaternion(t.localRotation.x, t.localRotation.y, t.localRotation.z, t.localRotation.w);
                    sis.transform.localRotation = Quaternion.Euler(-90f, (-45f * j) / 8, 0);
                    Vector3 vect = Vector3.zero;

                    switch (T)
                    {
                        case Type0.FIRST:
                            vect = EffectOne(t, i, j, FFTAnalyzer.OutBuffNormalized[i]);
                            break;
                        case Type0.SECOND:
                            vect = EffectTwo(t, i, j, FFTAnalyzer.OutBuffNormalized[i]);
                            break;
                        case Type0.THIRD:
                            vect = EffectThree(t, i, j, FFTAnalyzer.OutBuffNormalized[i]);
                            break;
                        case Type0.FORTH:
                            vect = EffectForth(t, i, j, FFTAnalyzer.OutBuffNormalized[i]);
                            break;
                        case Type0.FIFTH:
                            vect = EffectFifth(t, i, j, FFTAnalyzer.OutBuffNormalized[i]);
                            break;
                    }
                    particlsese[j].position = vect;
                    sis.transform.localRotation = q;
                }
            }
            sis.SetParticles(particlsese, partsNum);
        }
    }

    Vector3 EffectOne(Transform t, int i, int j, float analyzerLevel)
    {
        return (-t.right * ((analyzerLevel + startSize) * (FFTBoost * (j % AudioUtils.OUT_SAMPLES / 2))));
    }
    Vector3 EffectTwo(Transform t, int i, int j, float analyzerLevel)
    {
        return (-t.right * ((analyzerLevel + startSize) * (FFTBoost * j)));
    }
    Vector3 EffectThree(Transform t, int i, int j, float analyzerLevel)
    {
        return (-t.right * ((analyzerLevel + startSize) * (FFTBoost * floats[j])));
    }
    Vector3 EffectForth(Transform t, int i, int j, float analyzerLevel)
    {
        return (-t.right * ((analyzerLevel + startSize) * (Vector2.Lerp(new Vector2(FFTBoost, 0), new Vector2(FFTBoost * floats[j], 0), Time.deltaTime * j).x)));
    }
    Vector3 EffectFifth(Transform t, int i, int j, float analyzerLevel)
    {
        return (-t.right * ((analyzerLevel + startSize) * (FFTBoost)));
    }

}
