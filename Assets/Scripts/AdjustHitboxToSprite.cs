using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class AdjustHitboxToSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        AdjustCollider();
    }

    void Update()
    {
        AdjustCollider(); // This ensures the hitbox updates if the sprite changes
    }

    void AdjustCollider()
    {
        if (spriteRenderer != null && boxCollider != null)
        {
            Bounds bounds = spriteRenderer.bounds;

            // Convert world size to local size
            boxCollider.size = transform.InverseTransformVector(bounds.size);

            // Convert world center to local position
            boxCollider.offset = transform.InverseTransformPoint(bounds.center);
        }
    }
}