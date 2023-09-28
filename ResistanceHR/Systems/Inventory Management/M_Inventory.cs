namespace ResistanceHR.Inventory
{
	internal abstract class M_Inventory : M_RHR, IRefreshAtEndOfLevelStart
	{
		public M_Inventory() : base() { }

		public override bool ShowInCampaignMutatorList => true;
		public override bool ShowInHomeBaseMutatorList => true;
		public override bool ShowInLevelMutatorList => true;

		public abstract void RefreshAtLevelStart();
		public abstract void RefreshAtLevelStart(Agent agent);
		public bool RefreshThisLevel(int level) =>
			gc.sessionDataBig.curLevelEndless > 1;
	}
}
