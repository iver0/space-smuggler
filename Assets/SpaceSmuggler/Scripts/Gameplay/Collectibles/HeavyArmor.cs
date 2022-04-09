using System;
using UnityEngine;

public class HeavyArmor : MonoBehaviour, ICollectible
{
    public static event Action<int, int> OnHeavyArmorCollected;
    
    public void Collect()
    {
        OnHeavyArmorCollected?.Invoke(25, 125);
        Destroy(gameObject);
    }
}
