using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Lameass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lameass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Dork. Fuckin' dork. You'll never be cool, man.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lameass)),
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
							nameof(Badass),
							nameof(Badass_Plus),
							nameof(Xenophobe),
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Lameass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Badasses.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (CAgentGroup.Lameasses.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}