public class LightArmor : Collectable
{
    public override void OnCollect()
    {
        playerData.MoveSpeed = 6f;
        playerData.MaxArmor = 75;
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
