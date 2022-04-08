using UnityEngine;

public class Medkit : Collectable
{
    public override void OnCollect()
    {
        if (playerData.Health < playerData.MaxHealth - 25)
        {
            playerData.Health += 25;
        }
        else
        {
            playerData.Health = playerData.MaxHealth;
        }
    }
}
