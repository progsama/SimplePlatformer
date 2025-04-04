using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.AddScore(1);
        Destroy(gameObject);
        }
    }

