//====================================================================================
//Name: Spencer Fritz
//Date Due: 11/22/2026
//Description: Homework02 – Endless runner
//====================================================================================
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 8f;
    public float leftLimit = -7f;
    public float rightLimit = 7f;
    public TMP_Text gameOverText;
    public GameObject playAgainButton;
    public GameObject mainMenuButton;
    public ScoreManager scoreManager;
    public TMP_Text gemTimerText;
    public bool GemActive
    {
        get 
        { 
            return gemTimer > 0; 
        }
    }
    public Sprite runSprite1;
    public Sprite runSprite2;
    public Sprite jumpSprite;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded = true;
    private float gemTimer = 0f;
    private string activeGem = "";
    private SpriteRenderer spriteRenderer;
    private float runTimer = 0f;
    private bool useRunSprite1 = true;

    void Start()
    {
        //get player Rigidbody
        rb = GetComponent<Rigidbody2D>();

        //get sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //get left and right input
        moveInput = Input.GetAxisRaw("Horizontal");

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; 
        }

        //gem timer
        if (gemTimer > 0)
        {
            //count timer
            gemTimer -= Time.unscaledDeltaTime;

            //show active gem
            gemTimerText.text = activeGem + ": " + Mathf.CeilToInt(gemTimer);

            //timer finished
            if (gemTimer <= 0)
            {
                //reset slow gem
                if (activeGem == "Slow Gem")
                {
                    Time.timeScale = 1f;
                }

                //hide timer
                gemTimerText.gameObject.SetActive(false);
                activeGem = "";
            }
        }

        //jump sprite
        if (!isGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else
        {
            //run animation
            runTimer += Time.deltaTime;

            if (runTimer >= 0.15f)
            {
                //switch run sprite
                useRunSprite1 = !useRunSprite1;

                if (useRunSprite1)
                {
                    spriteRenderer.sprite = runSprite1;
                }
                else
                {
                    spriteRenderer.sprite = runSprite2;
                }

                runTimer = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        //move left and right
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //keep player on screen
        float xPosition = Mathf.Clamp(rb.position.x, leftLimit, rightLimit);
        rb.position = new Vector2(xPosition, rb.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //touching ground
        if (collision.gameObject.name.Contains("Ground"))
        {
            isGrounded = true;
        }

        //hit obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //show game over
            gameOverText.gameObject.SetActive(true);

            //show play again
            playAgainButton.SetActive(true);

            //show main menu
            mainMenuButton.SetActive(true);

            //save score
            HighScoreManager.SaveScore(scoreManager.GetScore());

            //stop game
            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //fell out of bounds
        if (collision.CompareTag("DeathZone"))
        {
            //show game over
            gameOverText.gameObject.SetActive(true);

            //show play again
            playAgainButton.SetActive(true);

            //show main menu
            mainMenuButton.SetActive(true);

            //save score
            HighScoreManager.SaveScore(scoreManager.GetScore());

            //stop game
            Time.timeScale = 0f;
        }

        //collect coin
        if (collision.CompareTag("Coin"))
        {
            //add points
            scoreManager.AddScore(100);

            //remove coin
            Destroy(collision.gameObject);
        }

        //collect speed gem
        if (collision.CompareTag("SpeedGem"))
        {
            //increase speed
            moveSpeed = 12f;

            //show speed timer
            activeGem = "Speed Gem";
            gemTimer = 10f;
            gemTimerText.gameObject.SetActive(true);

            //gem timer
            if (gemTimer > 0)
            {
                gemTimer -= Time.deltaTime;

                //show active gem
                gemTimerText.text = activeGem + ": " + Mathf.CeilToInt(gemTimer);

                //hide timer
                if (gemTimer <= 0)
                {
                    gemTimerText.gameObject.SetActive(false);
                    activeGem = "";
                }
            }

            //start timer
            Invoke("ResetSpeed", 10f);

            //remove gem
            Destroy(collision.gameObject);
        }

        //collect jump gem
        if (collision.CompareTag("JumpGem"))
        {
            //increase jump
            jumpForce = 14f;

            //show jump timer
            activeGem = "Jump Gem";
            gemTimer = 10f;
            gemTimerText.gameObject.SetActive(true);

            //gem timer
            if (gemTimer > 0)
            {
                gemTimer -= Time.deltaTime;

                //show active gem
                gemTimerText.text = activeGem + ": " + Mathf.CeilToInt(gemTimer);

                //hide timer
                if (gemTimer <= 0)
                {
                    gemTimerText.gameObject.SetActive(false);
                    activeGem = "";
                }
            }

            //start timer
            Invoke("ResetJump", 10f);

            //remove gem
            Destroy(collision.gameObject);
        }

        //collect slow gem
        if (collision.CompareTag("SlowGem"))
        {
            //slow game
            Time.timeScale = 0.5f;

            //show slow timer
            activeGem = "Slow Gem";
            gemTimer = 10f;
            gemTimerText.gameObject.SetActive(true);

            //remove gem
            Destroy(collision.gameObject);
        }
    }

    void ResetSpeed()
    {
        //reset speed
        moveSpeed = 3f;
    }

    void ResetJump()
    {
        //reset jump
        jumpForce = 8f;
    }

    void ResetTime()
    {
        //reset game speed
        Time.timeScale = 1f;
    }


}