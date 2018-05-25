using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeOfSpectrum
{
    SIMPLE
}
public enum TypeOfAnalyzerSetting
{
    OUT,
    OUT_BUFFERED,
    OUT_UFFERED_NORMALIZED
}

[CreateAssetMenu(fileName = "Settings", menuName = "Setting")]
public class Settings : ScriptableObject
{

    public TypeOfSpectrum SpectrumType;
    public TypeOfAnalyzerSetting AnalyzerType;
    public Color firstColor;
    public Color secondColor;
    public GameObject objectToSpawn;
    public float StartSize, SizeMultiplayer;

    public void SetStartSizeVlaue(string value)
    {
        StartSize = float.Parse(value);
    }
    public void SetMultiplayValaue(string value)
    {
        SizeMultiplayer = float.Parse(value);
    }
    public void SetAnalyzerSetting(int number)
    {
        AnalyzerType = (TypeOfAnalyzerSetting)number;
    }
}
