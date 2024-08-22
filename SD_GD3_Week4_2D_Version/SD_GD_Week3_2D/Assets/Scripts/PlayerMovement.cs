using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 4.5f;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Check for space bar press to instantiate the projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the projectile at the player's position with the default rotation
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally based on input
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        // Keep the player within the bounds of xRange
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
