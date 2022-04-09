using System;
using UnityEngine;

public class LightArmor : MonoBehaviour, ICollectible
{
    public static event Action<int, GameObject> OnLightArmorCollected;
    
    public void Collect()
    {
        OnLightArmorCollected?.Invoke(25, gameObject);
    }
}
