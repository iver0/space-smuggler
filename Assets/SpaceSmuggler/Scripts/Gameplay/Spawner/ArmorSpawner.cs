using UnityEngine;

public class ArmorSpawner : Spawner
{
    void Update()
    {
        position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        Spawn(SpawnPrefab, prefabTag, spawnMax, position);
    }
}
