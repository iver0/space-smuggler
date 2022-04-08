using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public string prefabTag = "";
    public int spawnMax = 0;
    public Vector3 position = new Vector3(0, 0, 0);

    public void Spawn(GameObject spawnPrefab, string prefabTag, int spawnMax, Vector3 position)
    {
        if (GameObject.FindGameObjectsWithTag(prefabTag).Length < spawnMax)
        {
            Instantiate(spawnPrefab, position, Quaternion.identity, gameObject.transform);
        }
    }
}
