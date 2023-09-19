using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Lameass_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lameass_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Damn, you just keep getting uncooler. Extra XP for eliminating the cool.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lameass_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
					Unlock =
					{
						cancellations = {
							VanillaTraits.FairGame,
							nameof(Xenophobe),
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			CAgentGroup.Badasses.Contains(otherAgent.agentName);

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Lameasses.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);
			else if (CAgentGroup.Badasses.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}