using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Move the object upwards in its local space
        transform.Translate(Vector2.up * Time.deltaTime * speed);

       
    }
}
