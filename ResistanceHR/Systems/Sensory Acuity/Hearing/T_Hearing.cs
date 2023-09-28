namespace ResistanceHR.Hearing
{
	internal abstract class T_Hearing : T_RHR
	{
		public override void OnAdded() { }
		public override void OnRemoved() { }

		public abstract float hearingRange { get; }

		public bool CanHearAgent(Agent hearer, Agent target)
		{


			return true;
		}
	}
}