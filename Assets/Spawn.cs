using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public GameObject text;
	public GameObject enemy;
	private static readonly string Lock = "Lock";

    void Start()
    {
		PlayerPrefs.SetFloat(Lock, 0);
		text.SetActive(false);
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("First Floor"))
		{

			enemy.SetActive(false);
		}
    }

    void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Player")
		{

			text.SetActive(true);

			if (Input.GetKey("e")) 
			{

				text.SetActive(false);
				PlayerPrefs.SetFloat(Lock, 1);
				if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("First Floor"))
				{

					enemy.SetActive(true);
				}

				GameObject.Find("Cube").SetActive(false);
			}
		}
    }
}
