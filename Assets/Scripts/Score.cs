using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    int score = 0;
    public Text text;

    //Public function call to add an inputted score value
    public void addScore(int val)
    {
        score+= val;
        text.text = score.ToString();
    }

    //Public function call to subtract an inputted score value
    public void subtractScore(int val)
    {
        score-= val;
        text.text = score.ToString();
    }
}
