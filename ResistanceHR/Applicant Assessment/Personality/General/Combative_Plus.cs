using RogueLibsCore;

namespace RHR.Reputation
{
	public class Combative_Plus : T_Reputation
	{
		public override int Priority => 1000;
		public override string GetRelationshipTo(Agent otherAgent)
		{
			if (gc.percentChance(5))
				return VRelationship.Hostile;
			else
				return VRelationship.Annoyed;
		}
		public override bool IsRival(Agent otherAgent) => false;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Combative_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You chew with your mouth open. And for this, you get what you deserve.",
					[LanguageCode.Russian] = "Вы чавкаете во время еды. У вас в этом мире нету ни единого друга. Вы подонок. Все кто с вами встречаются раздражены, включая меня.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Combative_Plus)),
					[LanguageCode.Russian] = "Обьективно неприятный",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -16,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = {
							VanillaTraits.Antisocial,
							VanillaTraits.Charismatic,
							VanillaTraits.FairGame,
							VanillaTraits.FriendoftheCommonFolk,
							nameof(Combative),
							VanillaTraits.IdeologicalClash,
							VanillaTraits.Malodorous,
							nameof(Polarizing),
							VanillaTraits.Suspicious,
							VanillaTraits.Wanted,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Eat a dick" },
						upgrade = null,
					}
				});
		}
	}
}