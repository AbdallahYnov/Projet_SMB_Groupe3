using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float moveSpeed = 8f; // Vitesse de déplacement de base
    public float acceleration = 10f; // Accélération vers la vitesse max
    public float deceleration = 15f; // Décélération quand on lâche la touche
    public float airControl = 0.5f; // Contrôle en l'air
    public float friction = 0.05f; // Friction pour un glissement naturel
    
    [Header("Saut")]
    public float jumpForce = 14f; // Puissance du saut
    public int maxJumps = 1; // Nombre de sauts max (1 au sol, 1 pour le wall jump)
    private int jumpsLeft;

    [Header("Mur & Glissade")]
    public float wallSlideSpeed = 3f; // Vitesse de glissade contre le mur
    public float wallJumpForceX = 10f; // Force horizontale du wall jump
    public float wallJumpForceY = 12f; // Force verticale du wall jump
    private bool isWallSliding;

    [Header("Vérifications")]
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;
    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, Vector2.right * transform.localScale.x, 0.4f, wallLayer);

        // Réinitialisation du saut lorsqu'on touche le sol
        if (isGrounded)
        {
            jumpsLeft = maxJumps;
        }

        // Saut normal
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // ✅ Utilisation correcte de velocity
            jumpsLeft--;
        }

        // Glissade contre un mur
        if (isTouchingWall && !isGrounded && rb.linearVelocity.y < 0)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed); // ✅ Correction

            // Si Shift est pressé, on ralentit encore plus la glissade
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed / 2); // ✅ Correction
            }
        }
        else
        {
            isWallSliding = false;
        }

        // Wall Jump
        if (Input.GetButtonDown("Jump") && isWallSliding)
        {
            rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForceX, wallJumpForceY); // ✅ Correction
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        float targetSpeed = horizontal * moveSpeed;
        float speedDif = targetSpeed - rb.linearVelocity.x; // ✅ Correction

        float accelRate = isGrounded ? acceleration : acceleration * airControl;
        float movement = Mathf.Abs(speedDif) * accelRate * Time.fixedDeltaTime;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x + Mathf.Sign(speedDif) * movement, rb.linearVelocity.y); // ✅ Correction

        // Ajout de friction si le joueur ne bouge pas
        if (horizontal == 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * (1 - friction), rb.linearVelocity.y); // ✅ Correction
        }
    }
}
