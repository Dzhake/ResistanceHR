using RogueLibsCore;

namespace RHR.Reputation
{
	public class Polarizing_Plus : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent)
		{
			if (gc.percentChance(50))					//		50%
			{
				if (gc.percentChance(40))					//      20%
				{
					if (gc.percentChance(20))
						return VRelationship.Aligned;			//		 4%
					else
						return VRelationship.Loyal;				//		16%
				}
				else
					return VRelationship.Friendly;				//		30%
			}
			else										//		50%
			{
				if (gc.percentChance(40))                                                   
					return VRelationship.Hostile;				//      20%
				else
					return VRelationship.Annoyed;				//      30%
			}
		}
		public override bool IsRival(Agent otherAgent) => false;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Polarizing_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Everyone has an opinion about you.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Polarizing_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
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
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}