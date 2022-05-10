using UnityEngine;

namespace SpaceSmuggler
{
    [CreateAssetMenu(fileName = "WaitDecision", menuName = "AI/Decisions/Wait")]
    public class WaitDecision : Decisions
    {
        public override bool Decide(StateController controller)
        {
            bool countdownElapsed = Wait(controller);
            return countdownElapsed;
        }

        bool Wait(StateController controller)
        {
            bool countdown = controller.CheckIfCountDownElapsed(controller.BotStats.AttackRate);
            return countdown;
        }
    }
}
