using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] GameObject _objectToSpawn;
	[SerializeField] GameObject _parent;
	[SerializeField] int _numberToSpawn = 1;
	[SerializeField] int _limit = 1;
	[SerializeField] float _rate = 1;
	[SerializeField] float _area = 1f;
	float _spawnTimer;

	void Start()
	{
		_spawnTimer = _rate;
	}

	void Update()
	{
		if (_parent.transform.childCount < _limit)
		{
			_spawnTimer -= Time.deltaTime;
			if (_spawnTimer <= 0f)
			{
				for (int i = 0; i < _numberToSpawn; i++)
				{
					Instantiate(
						_objectToSpawn,
						new Vector3(
							this.transform.position.x + GetModifier(),
							this.transform.position.y + GetModifier()
						),
						Quaternion.identity,
						_parent.transform
					);
				}
				_spawnTimer = _rate;
			}
		}
	}

	float GetModifier()
	{
		float modifier = Random.Range(0f, _area);
		if (Random.Range(0, 2) > 0)
			return -modifier;
		else
			return modifier;
	}
}
