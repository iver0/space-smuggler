using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
	[SerializeField] State _currentState = default;
	[SerializeField] State _remainState = default;
	[SerializeField] State _idleState = default;
	public IBot Bot;
	public BotStats BotStats;
	public Transform PlayerTransform;
	[Header("Listening on")]
	[SerializeField] VoidEventChannelSO _playerDeathEventChannel = default;
	[HideInInspector] public NavMeshAgent NavMeshAgent;
	[HideInInspector] public float StateTimeElapsed;
	bool _aiActive;

	void OnEnable()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
		_playerDeathEventChannel.OnEventRaised += PlayerDeath;
	}

	void OnDisable()
	{
		_playerDeathEventChannel.OnEventRaised -= PlayerDeath;
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
			Gizmos.DrawWireSphere(transform.position, BotStats.LookSphereCastRadius);
		}
	}

	public void TransitionToState(State nextState)
	{
		if (nextState != _remainState)
		{
			_currentState = nextState;
			OnExitState();
		}
	}

	public bool CheckIfCountDownElapsed(float duration)
	{
		StateTimeElapsed += Time.deltaTime;
		return StateTimeElapsed >= duration;
	}

	void OnExitState()
	{
		StateTimeElapsed = 0f;
	}

	void PlayerDeath()
	{
		TransitionToState(_idleState);
	}
}
