using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab; // allows me to add gameobjects in the inspector window
    public Vector2 spawnPos = new Vector2(18, -3); // declaring where the objects will spawn in the game (2D)
    private float startDelay = 2f; // how long before the first object spawns
    private float repeatRate = 2f; // the time between objects spawning again
    private PlayerMovement playerMovementScript;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);// this repeatts the spawn function and the start delay and the repeat Rate
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>(); // finding the playermovement scripts
    }

    void SpawnObstacle()
    {
        if (playerMovementScript.gameOver == false) // gameover bool is set to false this means that obstcales will spawn if the game over equals true obstcales stop spawning
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length); // getting random obstacles from the index thats in the inspector
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, Quaternion.identity); //repeating the spawn position 
        }
    }
}
