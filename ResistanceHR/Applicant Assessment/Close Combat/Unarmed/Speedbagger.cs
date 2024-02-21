using BunnyLibs;
using RogueLibsCore;

namespace RHR.Melee_Combat
{
	public class Speedbagger : T_RHR, IRefreshAtEndOfLevelStart
	{
		public bool BypassUnlockChecks => false;
		public void Refresh() { }
		public void Refresh(Agent agent)
		{
			agent.agentInvDatabase.fist.rapidFire = true;
		}
		public bool RunThisLevel() => true;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Speedbagger>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your fists have Rapid Fire.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Speedbagger)),
				})
				.WithUnlock(new TraitUnlock
				{
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
					UnlockCost = 15,
					Unlock =
					{
						categories = { CTraitCategory.Unarmed },
					}
				});
		}

		public override void OnAdded()
		{
			Owner.agentInvDatabase.fist.rapidFire = true;
		}
		public override void OnRemoved()
		{
			Owner.agentInvDatabase.fist.rapidFire = false;
		}
	}
}