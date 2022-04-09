using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<int> OnMedkitCollected;
    
    public void Collect()
    { 
        OnMedkitCollected?.Invoke(25);
        Destroy(gameObject);
    }
}
