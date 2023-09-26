namespace ResistanceHR.Conduct
{
	internal abstract class M_ComplianceChip : M_RHR
	{
		public M_ComplianceChip() : base() { }

		public override bool ShowInCampaignMutatorList => true;
		public override bool ShowInHomeBaseMutatorList => true;
		public override bool ShowInLevelMutatorList => true;
	}
}
