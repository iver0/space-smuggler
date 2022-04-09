using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<int, GameObject> OnMedkitCollected;
    
    public void Collect()
    {
        Debug.Log("Collect()");
        OnMedkitCollected?.Invoke(25, gameObject);
    }
}
