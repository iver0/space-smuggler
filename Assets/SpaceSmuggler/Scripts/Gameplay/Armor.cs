using UnityEngine;

public class Armor : MonoBehaviour
{
    public PlayerData playerData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & playerData.Armor != 100)
        {
            playerData.Armor = (playerData.Armor < 75) ? playerData.Armor + 25 : 100;
            Destroy(gameObject);
        }
    }
}
