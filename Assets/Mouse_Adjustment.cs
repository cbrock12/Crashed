using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Adjustment : MonoBehaviour
{
    private static readonly string Sensitivity = "Sensitivity";
    private float SenFloat = 1;

    public void updateSensitivity(float Sen)
    {
        SenFloat = Sen;
        PlayerPrefs.SetFloat(Sensitivity, SenFloat);
    }
}
