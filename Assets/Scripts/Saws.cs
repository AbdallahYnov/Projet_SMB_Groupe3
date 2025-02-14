using UnityEngine;
using UnityEngine.SceneManagement;

public class Saws : MonoBehaviour
{
    public float rotationSpeed = 200f; // Vitesse de rotation de la scie

    void Update()
    {
        // Faire tourner la scie en continu
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Vérifie si c'est le joueur
        {
            KillPlayer(collision.gameObject);
        }
    }

    void KillPlayer(GameObject player)
    {
        // Vérifie si le joueur a le script PlayerDeath
        PlayerDeath playerDeath = player.GetComponent<PlayerDeath>();

        if (playerDeath != null)
        {
            playerDeath.Die();
        }
        else
        {
            // Si le script n'est pas trouvé, redémarre directement la scène
            Debug.LogWarning("Le joueur n'a pas le script PlayerDeath ! Restart forcé.");
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
