using RogueLibsCore;

namespace RHR.Reputation
{
	public class Polarizing : T_Reputation
	{
		public override int Priority => 1000;
		public override string GetRelationshipTo(Agent otherAgent)
		{
			if (gc.percentChance(50))
				return VRelationship.Friendly;
			else
				return VRelationship.Annoyed;

			return null;
		}
		public override bool IsRival(Agent otherAgent) => false;

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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
	}
}