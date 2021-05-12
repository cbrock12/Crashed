using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Set : MonoBehaviour
{
    private static readonly string AudioPref = "AudioPref";
    private float AudioFloat;
    public AudioSource AudioSource;
    
    void Start()
    {
        AudioFloat = PlayerPrefs.GetFloat(AudioPref);
        AudioSource.volume = AudioFloat;
    }
}
