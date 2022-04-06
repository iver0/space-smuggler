using UnityEngine;

public class Medkit : MonoBehaviour
{
    public PlayerData playerData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & playerData.Health != 100)
        {
            playerData.Health = (playerData.Health < 75) ? playerData.Health + 25 : 100;
            Destroy(gameObject);
        }
    }
}
