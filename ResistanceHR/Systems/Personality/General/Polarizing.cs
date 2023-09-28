using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Polarizing : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Polarizing>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "People are split on you, but at least they remember you!",
					[LanguageCode.Russian] = "Каждый раз когда с вами встречается новый человек у него всегда будет о вас мнение, хорошее или плохое, зато вас заметили!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Polarizing)),
					[LanguageCode.Russian] = "Популяризация",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 1,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						cancellations = {
							VanillaTraits.Antisocial,
							VanillaTraits.Charismatic,
							VanillaTraits.FairGame,
							VanillaTraits.FriendoftheCommonFolk,
							nameof(Combative),
							VanillaTraits.Malodorous,
							nameof(Combative_Plus),
							VanillaTraits.Suspicious,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Polarizing_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (gc.percentChance(50))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}