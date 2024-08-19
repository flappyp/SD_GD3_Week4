using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; //player physics
    public float jumpForce; // how high the player can jump
    public float gravitiyModifier; //Will change the amount of gravity applied to the player

    public bool isGrounded; //isGrounded is checking for if the player is grounded
    // Start is called before the first frame update
    // getting the player rigidbody that  is in the inspector and has also been state at the top.
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting the player Rigidbody
        Physics.gravity *= gravitiyModifier; //getting the gravityModifier from the inspector
    }

    // Update is called once per frame
    // Getting the space bar press and checking if the player is grounded and if true than the player can jump
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }
    //Is checking for collision on the ground and the tag and if grounded is true than player can jump
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {

            isGrounded = true;

        }


    }
    //checking for the collison on the ground and if it is false than the player cant jump
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {

            isGrounded = false;

        }


    }

}
