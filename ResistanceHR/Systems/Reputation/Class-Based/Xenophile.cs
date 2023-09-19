using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Xenophile : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Xenophile>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "It's hard not being human. You get it, and nonhumans get you.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Xenophile)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
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
						upgrade = nameof(Xenophile_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Nonhumans.Contains(otherAgent.agentName)
				&& otherAgent.agentName != VanillaAgents.KillerRobot)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}