using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public PlayerData playerData;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollect();
        }
    }

    public abstract void OnCollect();
}
