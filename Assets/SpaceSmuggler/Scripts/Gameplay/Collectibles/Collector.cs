using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var collectible = collision.GetComponent<ICollectible>();
            collectible?.Collect();
        }
    }
}
