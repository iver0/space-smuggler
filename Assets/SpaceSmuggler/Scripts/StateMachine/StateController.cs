using UnityEngine;
using UnityEngine.AI;

namespace SpaceSmuggler
{
    /// <summary>
    /// Handles AI states.
    /// </summary>
    public class StateController : MonoBehaviour
    {
        #region Fields
        [SerializeField] State _currentState = default;
        [SerializeField] State _remainState = default;
        [SerializeField] State _idleState = default;
        public IBot Bot;
        [Tooltip("AI specialization scriptable object")]
        public BotStats BotStats;
        [Tooltip("AI's target")]
        public Transform Target;
        [Header("Listening on")]
        [SerializeField] VoidEventChannelSO _playerDeathEventChannel = default;
        [HideInInspector] public NavMeshAgent NavMeshAgent;
        [HideInInspector] public float StateTimeElapsed;
        bool _aiActive;
        #endregion

        #region LifeCycle
        void Awake()
        {
            Bot = gameObject.GetComponent<IBot>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            NavMeshAgent.updateRotation = false;
            NavMeshAgent.updateUpAxis = false;
            NavMeshAgent.speed = BotStats.MoveSpeed;
        }

        void OnEnable()
        {
            _playerDeathEventChannel.OnEventRaised += PlayerDeath;
        }

        void OnDisable()
        {
            _playerDeathEventChannel.OnEventRaised -= PlayerDeath;
        }

        public void SetupAI(bool aiActivation)
        {
            _aiActive = aiActivation;
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
        #endregion

        #region Methods
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
        #endregion
    }
}
