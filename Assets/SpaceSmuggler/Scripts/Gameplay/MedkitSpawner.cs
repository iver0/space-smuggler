using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    public GameObject MedkitPrefab;
    GameObject[] medkits;

    void Update()
    {
        medkits = GameObject.FindGameObjectsWithTag("Medkit");

        if (medkits.Length < 2)
        {
            Instantiate(MedkitPrefab, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity, gameObject.transform);
        }
    }
}
