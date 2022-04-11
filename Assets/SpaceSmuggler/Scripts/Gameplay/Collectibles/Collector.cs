using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        var collectible = collision.GetComponent<ICollectible>();
        collectible?.Collect();
    }
}
