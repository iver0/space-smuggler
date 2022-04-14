using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
	[SerializeField] State _currentState;
	[SerializeField] State _remainState;
	public EnemyStats EnemyStats;
	public Transform PlayerTransform;
	[HideInInspector] public NavMeshAgent NavMeshAgent;
	bool _aiActive;

	void Awake()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void SetupAI(bool aiActivation)
	{
		_aiActive = aiActivation;
		NavMeshAgent.updateRotation = false;
		NavMeshAgent.updateUpAxis = false;
		if (_aiActive)
			NavMeshAgent.enabled = true;
		else
			NavMeshAgent.enabled = false;
	}

	void Update()
	{
		if (!_aiActive)
			return;
		_currentState.UpdateState(this);
	}

	void OnDrawGizmos()
	{
		if (_currentState != null)
		{
			Gizmos.color = _currentState.SceneGizmoColor;
			Gizmos.DrawWireSphere(transform.position, EnemyStats.LookSphereCastRadius);
		}
	}

	public void TransitionToState(State nextState)
	{
		if (nextState != _remainState)
			_currentState = nextState;
	}
}
