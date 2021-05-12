using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Adjustment : MonoBehaviour
{
    private static readonly string AudioPref = "AudioPref";
    private float AudioFloat;
    public AudioSource AudioSource;

    public void updateVol(float volume)
    {
        AudioSource.volume = volume;
        AudioFloat = volume;
        PlayerPrefs.SetFloat(AudioPref, volume);
    }
}