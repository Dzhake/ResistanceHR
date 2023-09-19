namespace ResistanceHR.Inventory
{
	internal abstract class M_Inventory : M_RHR
	{
		public M_Inventory() : base() { }

		public override bool ShowInCampaignMutatorList => true;
		public override bool ShowInHomeBaseMutatorList => true;
		public override bool ShowInLevelMutatorList => true;
	}
}
