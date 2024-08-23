using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f; // declaring the speed of the object
    private PlayerMovement playerMovementScript;
    private float leftBound = -15f;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed); // moving the object to the left and applying the speed
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            scoreManager.AddScore(1);
            GameObject.FindObjectOfType<SpawnManager>().score++;

            Debug.Log("Score");
            Destroy(gameObject);
        }
    }
}
