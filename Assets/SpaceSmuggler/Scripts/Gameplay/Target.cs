using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    TargetDataSO _targetData;

    public void TakeDamage(int damage)
    {
        _targetData.Health -= damage;
        if (_targetData.Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
