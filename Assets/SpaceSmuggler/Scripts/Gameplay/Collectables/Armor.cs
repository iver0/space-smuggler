using UnityEngine;

public class Armor : Collectable
{
    public override void OnCollect()
    {
        if (playerData.Armor < playerData.MaxArmor - 25)
        {
            playerData.Armor += 25;
        }
        else
        {
            playerData.Armor = playerData.MaxArmor;
        }
    }
}
