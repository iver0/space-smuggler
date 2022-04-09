using System;
using UnityEngine;

public class Morphine : MonoBehaviour, ICollectible
{
    public static event Action<int, int> OnMorphineCollected;
    
    public void Collect()
    { 
        OnMorphineCollected?.Invoke(25, 125);
        Destroy(gameObject);
    }
}
