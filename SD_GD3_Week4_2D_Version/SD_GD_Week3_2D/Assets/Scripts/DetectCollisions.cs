using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}