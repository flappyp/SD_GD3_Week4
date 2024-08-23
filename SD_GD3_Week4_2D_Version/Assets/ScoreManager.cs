using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; //starting score is zero
    public TMP_Text scoreText; // getting the TMPro text

    public void AddScore(int value)
    {

        score += value;  
        UpdateScoreUI();

    }

    void UpdateScoreUI()
    {

        scoreText.text = "SCORE : " + score.ToString(); //converting and int to text
    }




}

