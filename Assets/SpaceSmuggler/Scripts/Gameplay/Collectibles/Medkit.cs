using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> OnMedkitCollected;
    
    public void Collect()
    { 
        OnMedkitCollected?.Invoke(gameObject, 25);
    }
}
