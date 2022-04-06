using UnityEngine;

public class ArmorSpawner : MonoBehaviour
{
    public GameObject ArmorPrefab;
    GameObject[] totalArmor;

    void Update()
    {
        totalArmor = GameObject.FindGameObjectsWithTag("Armor");

        if (totalArmor.Length < 2)
        {
            Instantiate(ArmorPrefab, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity, gameObject.transform);
        }
    }
}
