using RogueLibsCore;


namespace RHR.Ethics
{
	public class Conscientious : T_RHR
	{
		//	Maybe additional bonuses for good deeds like freeing slaves?
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Conscientious>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Enables XP penalties for wrongdoing.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Conscientious)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                    },
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
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