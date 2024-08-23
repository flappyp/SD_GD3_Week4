using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //player physics
    public float jumpForce; // how high the player can jump
    public float downForce = 10f; // how fast the player can go down
    public float gravityModifier = 1.0f; // Will change the amount of gravity applied to the player
    public int jumpCount = 0;
    public bool isGrounded; // isGrounded is checking if the player is grounded
    public bool gameOver = false;
    private Animator playerAnim;
    private bool isDead;
    public AudioClip deathSound;
    public AudioClip jumpingSound;
    public AudioClip tryAgainSound;
    private AudioSource playerAudio;
    public GameManager gameManager;


    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>(); // getting the player Rigidbody2D
        rb.gravityScale *= gravityModifier; // adjusting the gravity scale
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !gameOver)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;

            Debug.Log("Jump triggered");
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpingSound, 1.0f);
        }

        // Pressing 'S' to go down
        if (Input.GetKey(KeyCode.S) && !isGrounded && !gameOver)
        {
            rb.AddForce(Vector2.down * downForce, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            playerAnim.SetBool("Death_b", true);
            gameOver = true;
            Debug.Log("Game Over!");
            
            

            playerAudio.PlayOneShot(deathSound, 1.0f);
            playerAudio.PlayOneShot(tryAgainSound, 1.0f);
        }
        if (gameOver)
        {
            gameManager.gameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
