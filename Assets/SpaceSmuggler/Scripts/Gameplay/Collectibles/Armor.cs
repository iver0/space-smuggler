using System;
using UnityEngine;

public class Armor : MonoBehaviour, ICollectible
{
    public static event Action<int> OnArmorCollected;
    
    public void Collect()
    {
        OnArmorCollected?.Invoke(25);
        Destroy(gameObject);
    }
}
