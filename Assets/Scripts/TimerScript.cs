using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    float countDownSeconds = 0; //Seconds Timer
    int countDownMinutes = 0; //Minute Timer
    public Text textSeconds;
    public Text textMinutes;

    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
        countDownSeconds += Time.deltaTime;
        if (countDownSeconds < 10)
        {
            textSeconds.text = "0" + ((int)countDownSeconds).ToString(); //Displays seconds
        }
        else
        {
            textSeconds.text = ((int)countDownSeconds).ToString(); //Displays seconds
        }
        textMinutes.text = countDownMinutes.ToString() + ":"; //Displays Minutes

        if ((int)countDownSeconds >= 60)
        {
            Debug.Log("SPAWN FLU WAVE");
            countDownMinutes++;
            countDownSeconds = 0;
        }

		if ((int)countDownMinutes == 3 && (int)countDownSeconds == 20) 
		{
			GameObject.Find("InfoManager").GetComponent<SceneManagerScript> ().goToWin();
		}

		GameObject.Find("InfoManager").GetComponent<InfoManagerScript> ().setTime((int)countDownSeconds, countDownMinutes);
	}
}
