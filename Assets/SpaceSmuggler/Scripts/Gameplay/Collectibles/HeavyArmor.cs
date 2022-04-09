using System;
using UnityEngine;

public class HeavyArmor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int> OnHeavyArmorCollected;
    
    public void Collect()
    {
        OnHeavyArmorCollected?.Invoke(gameObject, 25, 125);
    }
}
