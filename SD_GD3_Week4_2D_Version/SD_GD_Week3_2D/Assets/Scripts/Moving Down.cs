using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMovingDown : MonoBehaviour
{
    public float speed = 10f;       
    public int scoreValue = 1;     

    private ScoreManager scoreManager;  

    void Start()
    {
       
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Fish"))
        {
            if (scoreManager != null)
            {
                // Add score when hit
                scoreManager.AddScore(scoreValue);
            }
            // Destroy the object when hit
            Destroy(gameObject);
            // Destroy the projectile when hit
            Destroy(other.gameObject);
        }
    }
}
