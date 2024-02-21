using RogueLibsCore;

namespace RHR.Reputation
{
	public class Combative : T_Reputation
	{
		public override int Priority => 1000;
		public override string GetRelationshipTo(Agent otherAgent)
		{
			if (gc.percentChance(20))
			{
				if (gc.percentChance(5))
					return VRelationship.Hostile;
				else
					return VRelationship.Annoyed;
			}

			return null;
		}
		public override bool IsRival(Agent otherAgent) => false;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Combative>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You have a certain way with people! A very annoying way.",
					[LanguageCode.Russian] = "Вы крайне раздражительны, вы даже не умеете общатся с людьми! Это оооочень... раздражает."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Combative)),
					[LanguageCode.Russian] = "Вообще неприятный",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = {
							VanillaTraits.Antisocial,
							VanillaTraits.Charismatic,
							VanillaTraits.FairGame,
							VanillaTraits.FriendoftheCommonFolk,
							VanillaTraits.IdeologicalClash,
							VanillaTraits.Malodorous,
							VanillaTraits.Suspicious,
							VanillaTraits.Wanted,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Smile a little more" },
						upgrade = null,
					}
				});
		}
	}
}