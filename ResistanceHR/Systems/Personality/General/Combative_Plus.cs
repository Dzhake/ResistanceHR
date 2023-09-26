using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Combative_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
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
					CharacterCreationCost = -10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
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
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Eat a dick" },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (gc.percentChance(5))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
			else
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}