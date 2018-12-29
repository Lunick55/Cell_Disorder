using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public void goToMain()
    {
        SceneManager.LoadScene("Main");
    }

	public void goToStart()
	{
		SceneManager.LoadScene("Start");
	}

	public void goToEnd()
	{
		SceneManager.LoadScene ("End");
	}

	public void goToAbout()
	{
		SceneManager.LoadScene ("About");
	}

    public void goToControls()
    {
        SceneManager.LoadScene("Controls");
    }

	public void goToWin()
	{
		SceneManager.LoadScene("Win");
	}

    public void quitGame()
    {
        Application.Quit();
    }

}
