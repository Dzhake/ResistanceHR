namespace RHR.Conduct
{
	public abstract class M_ComplianceChip : M_RHR
	{
		public M_ComplianceChip(string name) : base(name, true) { }

		public override bool ShowInCampaignMutatorList => true;
		public override bool ShowInHomeBaseMutatorList => true;
		public override bool ShowInLevelMutatorList => true;
	}
}
