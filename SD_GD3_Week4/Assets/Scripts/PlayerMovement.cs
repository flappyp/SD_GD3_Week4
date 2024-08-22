using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; //player physics
    public float jumpForce; // how high the player can jump
    public float gravitiyModifier; //Will change the amount of gravity applied to the player
    public int jumpCount = 0;
    public bool isGrounded; //isGrounded is checking for if the player is grounded
    public bool gameOver = false;
    private Animator playerAnim;

    public GameManager gameManager;
    public ParticleSystem dirtParticle;
    private bool isDead;
    public AudioClip deathSound;
    public AudioClip jumpingSound;
    private AudioSource playerAudio;
  


    // Start is called before the first frame update
    // getting the player rigidbody that  is in the inspector and has also been state at the top.
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>(); //getting the player Rigidbody
        Physics.gravity *= gravitiyModifier; //getting the gravityModifier from the inspector
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Getting the space bar press and checking if the player is grounded and if true than the player can jump
      void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !gameOver)
        {
           
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;

            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpingSound, 1.0f);
        }
    }
    //Is checking for collision on the ground and the tag and if grounded is true than player can jump
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {

            isGrounded = true;
            jumpCount = 0;
            dirtParticle.Play();
            
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(deathSound, 1.0f);
        }
        if (gameOver == true)
        {
            
            gameManager.gameOver();
            
        
        }


    }
    //checking for the collison on the ground and if it is false than the player cant jump
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {

            isGrounded = false;
            dirtParticle.Stop();
        }


    }

}
