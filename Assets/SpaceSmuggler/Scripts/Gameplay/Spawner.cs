using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Parent;
    public int NumberToSpawn = 1;
    public int Limit = 1;
    public float Rate = 1;
    public float Area = 1f;
    float _spawnTimer;

    void Start()
    {
        _spawnTimer = Rate;
    }

    void Update()
    {
        if (Parent.transform.childCount < Limit)
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0f)
            {
                for (int i = 0; i < NumberToSpawn; i++)
                {
                    Instantiate(
                        ObjectToSpawn,
                        new Vector3(
                            this.transform.position.x + GetModifier(),
                            this.transform.position.y + GetModifier()
                        ),
                        Quaternion.identity,
                        Parent.transform
                    );
                }
                _spawnTimer = Rate;
            }
        }
    }

    float GetModifier()
    {
        float modifier = Random.Range(0f, Area);
        if (Random.Range(0, 2) > 0)
            return -modifier;
        else
            return modifier;
    }
}
