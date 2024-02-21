using BunnyLibs;

namespace RHR.Inventory
{
	public abstract class M_Inventory : M_RHR, IRefreshAtEndOfLevelStart
	{
		public M_Inventory() : base() { }

		public override bool ShowInCampaignMutatorList => true;
		public override bool ShowInHomeBaseMutatorList => true;
		public override bool ShowInLevelMutatorList => true;

		public bool BypassUnlockChecks => false;
		public abstract void Refresh();
		public abstract void Refresh(Agent agent);
		public void RefreshInactive() { }
		public bool RunThisLevel() =>
			gc.sessionDataBig.curLevelEndless > 1;
	}
}
