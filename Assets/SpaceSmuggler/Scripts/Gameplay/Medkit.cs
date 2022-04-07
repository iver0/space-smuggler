using UnityEngine;

public class Medkit : MonoBehaviour
{
    public PlayerData playerData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & playerData.Health != playerData.MaxHealth)
        {
            playerData.Health = (playerData.Health < playerData.MaxHealth - 25) ? playerData.Health + 25 : playerData.MaxHealth;
            Destroy(gameObject);
        }
    }
}
