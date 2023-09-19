using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Underclass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Underclass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "People of the underclasses take pride in their rough upbringing. The upper classes don't look kindly on them.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Underclass)),
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
						upgrade = nameof(Underclass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Underclass.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (CAgentGroup.Upperclass.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}