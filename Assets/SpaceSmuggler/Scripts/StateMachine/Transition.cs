namespace SpaceSmuggler
{
	[System.Serializable]
	public class Transition
	{
		public Decisions Decision;
		public State TrueState;
		public State FalseState;
	}
}
