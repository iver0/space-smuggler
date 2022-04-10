using UnityEngine;

public interface ICollectible
{
    public void Collect();

    public void DestroyCollectible(GameObject collectible);
}
