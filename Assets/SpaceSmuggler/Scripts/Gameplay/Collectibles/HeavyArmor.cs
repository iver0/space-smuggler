using System;
using UnityEngine;

public class HeavyArmor : MonoBehaviour, ICollectible
{
    public static event Action<int, GameObject> OnHeavyArmorCollected;
    
    public void Collect()
    {
        OnHeavyArmorCollected?.Invoke(25, gameObject);
    }
}
