using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public GameObject Open;
	public GameObject Locked;
	private static readonly string Lock = "Lock";

    void Start()
    {
		Open.SetActive(false);
		Locked.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
		if (other.gameObject.tag == "Player")
		{

			if (PlayerPrefs.GetFloat(Lock) == 1)
			{

				Open.SetActive(true);

				if (Input.GetButtonDown("Enter")) 
				{

					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				}
			} else {

				Locked.SetActive(true);
			}
		}
    }

    void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Open.SetActive(false);
			Locked.SetActive(false);
		}
    }
}
