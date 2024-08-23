using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private Vector3 spawnPos = new Vector3(10, 15, 0);
    private float startDelay = 2; //how long before the first object spawns
    private float repeatRate = 2; // the time between objects spawing in again

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
       
       

        // If game is still active, spawn new object
        if (playerControllerScript.gameOver == false)
        {
            int index = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[index], spawnPos, objectPrefabs[index].transform.rotation);
        }

    }
}
