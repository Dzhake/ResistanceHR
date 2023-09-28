using System.Collections.Generic;

namespace ResistanceHR.Loot
{
	internal abstract class T_Loot : T_RHR
	{
		public abstract List<string> RewardItems { get; }

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
