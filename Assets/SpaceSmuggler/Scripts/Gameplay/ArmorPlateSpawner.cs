using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPlateSpawner : MonoBehaviour
{
    public GameObject ArmorPlatePrefab;
    GameObject[] armorPlates;

    void Update()
    {
        armorPlates = GameObject.FindGameObjectsWithTag("Armor Plate");

        if (armorPlates.Length < 2)
        {
            Instantiate(ArmorPlatePrefab, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity, gameObject.transform);
        }
    }
}
