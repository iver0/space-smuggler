using UnityEngine;

namespace SpaceSmuggler
{
	public abstract class Decisions : ScriptableObject
	{
		public abstract bool Decide(StateController controller);
	}
}
