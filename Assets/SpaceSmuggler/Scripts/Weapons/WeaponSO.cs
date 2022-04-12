using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Gameplay/Weapon")]
public class WeaponSO : ScriptableObject
{
    public AudioEvent FiringSound;
    public int Damage;
    public bool IsAutomatic;
    public float FireRate;
    public float Spread;
}
