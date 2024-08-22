using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab; // allows me to add gameobjects in the inspector window
    private Vector3 spawnPos = new Vector3(25, 0, 0); // declaring where the objects will spawn in the game
    private float startDelay = 2; //how long before the first object spawns
    private float repeatRate = 2; // the time between objects spawing in again
    private PlayerMovement PlayerMovementScript;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); //repeating the spawnobstacle function along with te start and repeat delays
        PlayerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void SpawnObstacle()
    {
        if (PlayerMovementScript.gameOver == false)


        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length); //getting the obstacleIndex and randomizing what obejct is being spawned 
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);

        }
    }
}
