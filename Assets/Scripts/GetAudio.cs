using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetAudio : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        string[] mics = Microphone.devices;
        
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(mics[0], true, 1, 44100);
        aud.loop = true;

        while (!(Microphone.GetPosition(null) > 0)) { }

        aud.Play();
    }
}
