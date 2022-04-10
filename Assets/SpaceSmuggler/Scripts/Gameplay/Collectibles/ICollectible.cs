using UnityEngine;

public interface ICollectible
{
    public void Collect();

    public void OnItemCollected(GameObject item);
}
