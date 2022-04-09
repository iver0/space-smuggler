using System;
using UnityEngine;

public class Armor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> OnArmorCollected;
    
    public void Collect()
    {
        OnArmorCollected?.Invoke(gameObject, 25);
    }
}
