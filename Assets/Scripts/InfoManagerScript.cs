using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoManagerScript : MonoBehaviour {

	int finalTimeSeconds;
	int finalTimeMinutes;
	Text scoreText;

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SceneManager.GetActiveScene ().name == "End" || SceneManager.GetActiveScene ().name == "Win") 
		{
			scoreText = GameObject.Find ("Canvas").transform.Find("scoreText").GetComponent<Text> ();

			if (finalTimeSeconds < 10)
			{
				scoreText.text = finalTimeMinutes + ":" + "0" + finalTimeSeconds; //Displays seconds
			}
			else scoreText.text = finalTimeMinutes + ":" + finalTimeSeconds;

			Destroy (gameObject);
		}
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			GetComponent<SceneManagerScript> ().goToMain ();
		}
	}

	public void setTime(int sec, int min)
	{
		finalTimeMinutes = min;
		finalTimeSeconds = sec;
	}
}
