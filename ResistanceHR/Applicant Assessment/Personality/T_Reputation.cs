using BunnyLibs;

namespace RHR.Reputation
{
	public abstract class T_Reputation : T_RHR, ISetupRelationshipOriginal
	{
		public abstract string GetRelationshipTo(Agent otherAgent);
		public abstract bool IsRival(Agent otherAgent);
		public abstract int Priority { get; }
	}
}