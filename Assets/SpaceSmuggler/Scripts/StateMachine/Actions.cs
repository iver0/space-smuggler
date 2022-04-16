using UnityEngine;

public abstract class Actions : ScriptableObject
{
	public abstract void Act(StateController controller);
}
