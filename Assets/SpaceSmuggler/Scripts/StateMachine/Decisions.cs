using UnityEngine;

public abstract class Decisions : ScriptableObject
{
	public abstract bool Decide(StateController controller);
}
