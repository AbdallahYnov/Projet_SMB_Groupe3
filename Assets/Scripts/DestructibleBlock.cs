using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Vérifie si le joueur touche le bloc
        {
            Destroy(gameObject);
        }
    }
}
