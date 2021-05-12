using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Finale"))
        {
            Application.Quit();
        } else {
            SceneManager.LoadScene(1);
        }
    }
}
