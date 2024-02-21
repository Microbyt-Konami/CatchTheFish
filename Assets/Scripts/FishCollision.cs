using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore();
        }

        if (collision.gameObject.CompareTag("FishDestroyer"))
        {
            Destroy(gameObject);
            LivesManager.instance.RemoveLife();
        }
    }
}
