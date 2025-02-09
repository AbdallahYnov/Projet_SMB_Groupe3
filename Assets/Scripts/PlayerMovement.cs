using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Mouvement")]
    public float moveSpeed = 8f; // Vitesse de déplacement
    public float acceleration = 10f; // Accélération vers la vitesse max
    public float deceleration = 15f; // Décélération
    public float airControl = 0.5f; // Contrôle en l'air
    public float friction = 0.05f; // Friction naturelle

    [Header("Saut")]
    public float jumpForce = 14f; // Puissance du saut
    public int maxJumps = 1; // Nombre maximum de sauts
    private int jumpsLeft;

    [Header("Mur & Glissade")]
    public float wallSlideSpeed = 3f; // Vitesse de glissade
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

        // Vérifie si les objets nécessaires sont assignés
        if (groundCheck == null || wallCheck == null)
        {
            Debug.LogError("ERREUR : GroundCheck ou WallCheck n'est pas assigné !");
        }
        else
        {
            Debug.Log("GroundCheck et WallCheck correctement assignés.");
        }

        jumpsLeft = maxJumps;
        Debug.Log("Sauts disponibles au départ : " + jumpsLeft);
    }

    void Update()
    {
        // Récupère l'entrée horizontale
        horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log("Input horizontal détecté : " + horizontal);

        // Vérifie si le personnage est au sol ou contre un mur
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, Vector2.right * transform.localScale.x, 0.4f, wallLayer);

        Debug.Log("Sol détecté : " + isGrounded);
        Debug.Log("Mur détecté : " + isTouchingWall);

        // Réinitialise les sauts au sol
        if (isGrounded)
        {
            jumpsLeft = maxJumps;
            Debug.Log("Sauts réinitialisés : " + jumpsLeft);
        }

        // Gestion du saut
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpsLeft > 0)
            {
                Jump();
                Debug.Log("Saut effectué, sauts restants : " + jumpsLeft);
            }
            else
            {
                Debug.Log("Aucun saut disponible !");
            }
        }

        // Glissade murale
        if (isTouchingWall && !isGrounded && rb.linearVelocity.y < 0)
        {
            WallSlide();
            Debug.Log("Glissade murale activée.");
        }
        else
        {
            isWallSliding = false;
        }

        // Wall Jump
        if (Input.GetButtonDown("Jump") && isWallSliding)
        {
            WallJump();
            Debug.Log("Wall Jump effectué.");
        }
    }

    void FixedUpdate()
    {
        // Calcul du déplacement horizontal
        float targetSpeed = horizontal * moveSpeed;
        float speedDif = targetSpeed - rb.linearVelocity.x;

        // Détermine l'accélération selon la situation
        float accelRate = isGrounded ? acceleration : acceleration * airControl;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x + speedDif * accelRate * Time.fixedDeltaTime, rb.linearVelocity.y);
        Debug.Log("Vitesse actuelle du personnage : " + rb.linearVelocity);

        // Ajoute de la friction si le joueur ne bouge pas
        if (horizontal == 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * (1 - friction), rb.linearVelocity.y);
            Debug.Log("Friction appliquée, vitesse horizontale réduite : " + rb.linearVelocity.x);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        jumpsLeft--;
        Debug.Log("Le personnage saute avec une force de : " + jumpForce);
    }

    private void WallSlide()
    {
        isWallSliding = true;

        // Limite la vitesse de chute
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -wallSlideSpeed);
        Debug.Log("Glissade murale en cours, vitesse limitée à : " + rb.linearVelocity.y);
    }

    private void WallJump()
    {
        isWallSliding = false;

        // Applique une force en diagonale
        rb.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForceX, wallJumpForceY);

        // Change la direction du personnage
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Debug.Log("Wall Jump effectué, nouvelle direction du personnage.");
    }

    void OnDrawGizmosSelected()
    {
        // Visualisation des points de détection
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
            Debug.Log("Gizmo pour GroundCheck dessiné.");
        }
        else
        {
            Debug.LogWarning("GroundCheck n'est pas assigné !");
        }

        if (wallCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * transform.localScale.x * 0.4f);
            Debug.Log("Gizmo pour WallCheck dessiné.");
        }
        else
        {
            Debug.LogWarning("WallCheck n'est pas assigné !");
        }
    }
}
