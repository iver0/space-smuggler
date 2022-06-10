using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceSmuggler
{
    public class Enemy : MonoBehaviour, IBot
    {
        [SerializeField] private Player player;
        private StateController _controller;

        private void Start()
        {
            _controller = GetComponent<StateController>();
            _controller.SetupAI(true);
        }

        public void Attack(int damage)
        {
            player.TakeDamage(damage);
        }
    }
}
