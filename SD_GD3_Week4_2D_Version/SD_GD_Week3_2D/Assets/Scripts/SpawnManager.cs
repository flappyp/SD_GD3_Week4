using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; 
    private float spawnRangeX = 4.5f; 
    private float spawnPosY = 13f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);


    }
    
   
        void SpawnRandomAnimal()
    {

        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY);


        int animalIndex = Random.Range(0, animalPrefabs.Length);


        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);





    }

}
