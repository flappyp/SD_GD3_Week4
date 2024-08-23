using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30; //declaring the speed of the object
    private PlayerMovement PlayerMovementScript; //calling the player movement script
    private float leftBound = -15; //the max of where the objects can go
    private ScoreManager scoreManager; //calling the scoremanager script
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>(); //getting the player rb
        scoreManager = FindObjectOfType<ScoreManager>(); //getting the scoreManager
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovementScript.gameOver == false) //if gameover = false let the player move
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // moving the object to the left and applying the speed
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // if an obstacle gets destroyed add 1 to the score count.
        {
            scoreManager.AddScore(1); //adding 1 to score
            GameObject.FindObjectOfType<SpawnManager>().score++; 
            Debug.Log("Score"); //showing the score in the console
            Destroy(gameObject); //destroying the obstacles 


        }
    }
}
       



