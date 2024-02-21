using RogueLibsCore;
using System;

public class M_RHR : MutatorUnlock
{
	public M_RHR() : base() { }
	public M_RHR(string name, bool unlockedFromStart) : base(name, unlockedFromStart)
	{
		IsAvailableInDailyRun = RollInDailyRun;
	}

	//	IRefreshPerLevel
	public bool AlwaysApply => false;

	public virtual bool RollInDailyRun => false;
	public virtual bool ShowInCampaignMutatorList => false;
	public virtual bool ShowInHomeBaseMutatorList => false;
	public virtual bool ShowInLevelMutatorList => false;

	public static string DisplayName(Type type) =>
		"[RHR] " + type.Name.Replace('_', ' ');
}