using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 14;
    private float lowerBound = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);

        }
        else if (transform.position.y < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);

        }
    }
}
