using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Text_Timer : MonoBehaviour
{
    public GameObject[] notes;
    private int x = 0;

    void Start()
    {   
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Goal"))
        {
            StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        int i = x;
        int j = notes.Length;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Goal"))
        {
            while (i < j)
            {
                yield return new WaitForSeconds(1);
                notes[i].SetActive(true);
                yield return new WaitForSeconds(4);
                notes[i].SetActive(false);
                i += 1;
            }

            SceneManager.LoadScene("Finale");
        } else {
            if (GameObject.Find("Cube") == true)
            {
                while (i < 3)
                {
                    notes[i].SetActive(true);
                    yield return new WaitForSeconds(4);
                    notes[i].SetActive(false);
                    i += 1;
                    x = i;
                }
            } else {
                while (i < j)
                {
                    notes[i].SetActive(true);
                    yield return new WaitForSeconds(4);
                    notes[i].SetActive(false);
                    i += 1;
                    x = i;
                }
            }
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Goal"))
        {
            StartCoroutine(Delay());
        }
    }
}
