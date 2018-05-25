using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Settings set;
    public Transform From, To;
    public List<GameObject> gos;
    public FFT_Analyzer analyzer;
    private void Awake()
    {
        gos = new List<GameObject>();
        if (set.SpectrumType == TypeOfSpectrum.SIMPLE)
        {
            for (int i = 0; i < AudioUtils.OUT_SAMPLES; i++)
            {
                float frac = i / (float)AudioUtils.OUT_SAMPLES;
                Vector3 position = Vector3.Lerp(From.position, To.position, frac);
                GameObject go = Instantiate(set.objectToSpawn, position, Quaternion.identity, transform);
                go.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Vector4.Lerp(set.firstColor, set.secondColor, frac);
                gos.Add(go);
            }
        }
    }
    private void Update()
    {
        if (set.SpectrumType == TypeOfSpectrum.SIMPLE)
        {
            float[] levels = OutType();
            for (int i = 0; i < gos.Count; i++)
            {
                gos[i].transform.localScale = new Vector3(1f, (set.StartSize + levels[i]) * set.SizeMultiplayer, 1f);
            }
        }
    }
    private float[] OutType()
    {
        if (set.AnalyzerType == TypeOfAnalyzerSetting.OUT)
        {
            return analyzer.Out;
        }
        else if (set.AnalyzerType == TypeOfAnalyzerSetting.OUT_BUFFERED)
        {
            return analyzer.OutBuffered;
        }
        else if (set.AnalyzerType == TypeOfAnalyzerSetting.OUT_UFFERED_NORMALIZED)
        {
            return analyzer.OutBuffNormalized;
        }
        return null;
    }


}
