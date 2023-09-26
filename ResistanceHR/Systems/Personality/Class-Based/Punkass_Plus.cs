using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Punkass_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Punkass_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Non-gang criminals are now loyal instead of friendly. Cops are hostile but give bonus XP for neutralizing.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Punkass_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = {
							nameof(Kissass),
							VanillaTraits.FairGame,
							VanillaTraits.TheLaw,
							VanillaTraits.UpperCrusty,
							VanillaTraits.Wanted,
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
			CAgentGroup.LawEnforcers.Contains(otherAgent.agentName);

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.PunkassUnaffiliated.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);
			else if (CAgentGroup.PunkassAffiliated.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (CAgentGroup.LawEnforcers.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}