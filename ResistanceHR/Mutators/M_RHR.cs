using RogueLibsCore;
using System;

namespace ResistanceHR
{
	public class M_RHR : MutatorUnlock
	{
		public M_RHR() : base() { }
		public M_RHR(string name, bool unlockedFromStart) : base(name, unlockedFromStart)
		{
			IsAvailableInDailyRun = RollInDailyRun;
		}

		public virtual bool RollInDailyRun => false;
		public virtual bool ShowInCampaignMutatorList => false;
		public virtual bool ShowInHomeBaseMutatorList => false;
		public virtual bool ShowInLevelMutatorList => false;

		public static string DesignerName(Type type, string custom = null) =>
			"[RHR] " +
				type.Namespace.Split('.')[2].Replace('_', ' ') +
				" - " +
				(custom.Replace('_', ' ')
					?? type.Name.Replace('_', ' '));
		public static string LongishDocumentationName(Type type) =>
			type.Namespace.Split('.')[2].Replace('_', ' ') +
			" - " +
			type.Name.Replace('_', ' ');
		public static string PlayerName(Type type) =>
			"[RHR] " + type.Name.Replace('_', ' ');
		public string TextName => DesignerName(GetType());
	}
}