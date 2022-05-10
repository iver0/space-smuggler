using UnityEngine;

namespace SpaceSmuggler
{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "AI/Actions/Attack")]
    public class AttackAction : Actions
    {
        public override void Act(StateController controller)
        {
            controller.NavMeshAgent.isStopped = true;
            Attack(controller);
        }

        void Attack(StateController controller)
        {
            RaycastHit2D hit = Physics2D.CircleCast(controller.transform.position, controller.BotStats.LookSphereCastRadius, controller.transform.forward, controller.BotStats.AttackRange);

            Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * controller.BotStats.AttackRange, Color.green);

            if (hit && hit.collider.CompareTag("Player"))
            {
                if (controller.CheckIfCountDownElapsed(controller.BotStats.AttackRate))
                    controller.Bot.Attack(controller.BotStats.AttackDamage);
            }
        }
    }
}
