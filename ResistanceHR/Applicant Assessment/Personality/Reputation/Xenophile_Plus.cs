using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Xenophile_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Xenophile_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Wow, the kumbaya stuff sure turned into \"Kill all humans\" pretty fast. Nonhumans are Loyal, humans are Annoyed but give bonus XP for neutralizing.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Xenophile_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
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
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			!CAgentGroup.Nonhumans.Contains(otherAgent.agentName);

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Nonhumans.Contains(otherAgent.agentName)
				&& otherAgent.agentName != VanillaAgents.KillerRobot)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);
			else if (!CAgentGroup.Nonhumans.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}