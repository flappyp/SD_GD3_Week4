using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public int score = 0; 
    public TextMeshProUGUI scoreText;  

    void Start()
    {
        UpdateScoreText(); 
    }

    public void AddScore(int points)
    {
        score += points;  
        UpdateScoreText();  
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;  
    }
}
