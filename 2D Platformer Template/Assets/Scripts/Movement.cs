using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement
    public float jumpForce = 10f; // Force applied when the player jumps
    public float descendMultiplier = 2f; // Multiplier for the descending speed
    public LayerMask groundLayer; // Layer mask to check if the player is grounded

    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle left and right movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.IsTouchingLayers(coll, groundLayer);

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Handle faster descending
        if (!isGrounded && Input.GetAxis("Vertical") < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - descendMultiplier * Time.deltaTime);
        }

        // Update animations
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("VerticalVelocity", rb.velocity.y);
    }
}
