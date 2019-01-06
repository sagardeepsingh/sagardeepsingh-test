using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public GameObject scoreText;
    public GameObject streakText;
    TMP_Text scoreTextMesh;
    TMP_Text streakTextMesh;
    public int score;
    Color streakTempColor;
    public int streakCount;
    public int highScore;
    public int timeBonus = 0;

    // Use this for initialization
    void Start () {

        //Initialize Components and set default score
        scoreTextMesh = scoreText.GetComponent<TMP_Text>();
        streakTextMesh = streakText.GetComponent<TMP_Text>();
        score = 0;
        streakCount = 1;
        highScore = PlayerPrefs.GetInt("High Score");

    }
	
	// Update is called once per frame
	void Update () {

        //Update Score
        scoreTextMesh.SetText(score.ToString());

        //Update Streak
        streakTextMesh.SetText(streakCount.ToString() + "x");

       
    }

    public void UpdateScore(int hitPoints, Color colliderColor)
    {
        // Calculate Streak count
        if(colliderColor == streakTempColor)
        {
            streakCount++;
        }
        else
        {
            streakCount = 1;
        }


        //add streak multiplier
        int streakScore = streakCount * hitPoints;
        score = score+streakScore;

        //assign streak temporary variable to save for next
        streakTempColor = colliderColor;

    }
    public void FinalScore(){

        //Update the final Score on game over panel
        score = score + timeBonus; //if applicable, otherwise, initialised at 0
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
        }

        GameObject.Find("ScoreFinal").GetComponent<TMP_Text>().SetText("Score : " + score.ToString() + " (Time Bonus : " +timeBonus + ")");
        GameObject.Find("HighScore").GetComponent<TMP_Text>().SetText("High Score : " + highScore.ToString());
    }
}
