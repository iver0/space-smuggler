using UnityEngine;

public class Armor : MonoBehaviour
{
    public PlayerData playerData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") & playerData.Armor != playerData.MaxArmor)
        {
            playerData.Armor = (playerData.Armor < playerData.MaxArmor - 25) ? playerData.Armor + 25 : playerData.MaxArmor;
            Destroy(gameObject);
        }
    }
}
