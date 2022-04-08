using UnityEngine;

public class LightArmor : Collectable
{
    public override void OnCollect()
    {
        playerData.MoveSpeed = 10f;
        playerData.MaxArmor = 75;
    }
}
