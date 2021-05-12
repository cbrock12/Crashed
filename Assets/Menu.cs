using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static readonly string level = "level";
    private float index;

    void Start()
    {
        Cursor.visible = true;
    }

    public void Restart()
    {
        index = PlayerPrefs.GetFloat(level);
        int lastIndex = (int)index;
        SceneManager.LoadScene(lastIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
