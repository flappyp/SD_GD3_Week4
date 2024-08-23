using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; //player physics
    public float jumpForce; // how high the player can jump
    public float downForce = 10f; // how fast the player can go down
    public float gravityModifier; //Will change the amount of gravity applied to the player
    public int jumpCount = 0;
    public bool isGrounded; //isGrounded is checking if the player is grounded
    public bool gameOver = false;
    private Animator playerAnim;

    public GameManager gameManager;
    
    private bool isDead;
    public AudioClip deathSound;
    public AudioClip jumpingSound;
    public AudioClip TryAgainSound;
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>(); //getting the player Rigidbody
        Physics.gravity *= gravityModifier; //getting the gravityModifier from the inspector
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;

            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpingSound, 1.0f);
        }

        // Pressing 'S' to go down
        if (Input.GetKey(KeyCode.S) && !isGrounded && !gameOver)
        {
            rb.AddForce(Vector3.down * downForce, ForceMode.Acceleration);
        }
    }

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
            
            playerAudio.PlayOneShot(deathSound, 1.0f);
            playerAudio.PlayOneShot(TryAgainSound, 1.0f);
        }
        if (gameOver)
        {
            gameManager.gameOver();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
            
        }
    }
}
