using System;
using UnityEngine;

public class Armor : MonoBehaviour, ICollectible
{
    public static event Action<int, GameObject> OnArmorCollected;
    
    public void Collect()
    {
        OnArmorCollected?.Invoke(25, gameObject);
    }
}
