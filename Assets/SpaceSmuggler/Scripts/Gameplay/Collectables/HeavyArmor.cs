public class HeavyArmor : Collectable
{
    public override void OnCollect()
    {
        playerData.MoveSpeed = 4f;
        playerData.MaxArmor = 125;
        if (playerData.Armor != playerData.MaxArmor)
        {
            if (playerData.Armor < playerData.MaxArmor - 25)
            {
                playerData.Armor += 25;
            }
            else
            {
                playerData.Armor = playerData.MaxArmor;
            }
            Destroy(gameObject);
        }
    }
}
