using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Punkass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Punkass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You have the signs of the street life written all over you. Including a tattoo on your face that says \"Street Life\". Criminals like you, cops don't.",
					[LanguageCode.Russian] = "У вас длинный список преступлений и каждый коп знает вас в лицо. Они так устали от вас и вашего дерьма, что только и ищут повод, чтобы избить вас.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Punkass)),
					[LanguageCode.Russian] = "Давные преступления",
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
							nameof(Kissass),
							VanillaTraits.FairGame,
							VanillaTraits.TheLaw,
							VanillaTraits.UpperCrusty,
							VanillaTraits.Wanted,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Punkass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.PunkassAffiliated.Contains(otherAgent.agentName)
				|| CAgentGroup.PunkassUnaffiliated.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (CAgentGroup.LawEnforcers.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}