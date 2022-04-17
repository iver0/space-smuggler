using UnityEngine;

namespace SpaceSmuggler
{
	[CreateAssetMenu(menuName = "AI/State")]
	public class State : ScriptableObject
	{
		public Actions[] Actions;
		public Transition[] Transitions;
		public Color SceneGizmoColor = Color.grey;

		public void UpdateState(StateController controller)
		{
			DoActions(controller);
			CheckTransitions(controller);
		}

		void DoActions(StateController controller)
		{
			for (int i = 0; i < Actions.Length; i++)
			{
				Actions[i].Act(controller);
			}
		}

		void CheckTransitions(StateController controller)
		{
			for (int i = 0; i < Transitions.Length; i++)
			{
				bool decisionSucceeded = Transitions[i].Decision.Decide(controller);

				if (decisionSucceeded)
					controller.TransitionToState(Transitions[i].TrueState);
				else
					controller.TransitionToState(Transitions[i].FalseState);
			}
		}
	}
}
