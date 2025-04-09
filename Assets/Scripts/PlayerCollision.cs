using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explotionParticles, starParticles;

    private void OnTriggerExit2D(Collider2D collision)
    {
        int pointsPerObstacle = 1;
        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.AddScore(pointsPerObstacle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Star star = collision.GetComponent<Star>();
        if (star != null)
        {
            GameManager.Instance.AddScore(star.GetPoints());
            Instantiate(starParticles, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.StopGame();
        Instantiate(explotionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}
