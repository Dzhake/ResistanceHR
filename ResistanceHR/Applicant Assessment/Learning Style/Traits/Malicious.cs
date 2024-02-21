using RogueLibsCore;

namespace RHR.Ethics
{
	public class Malicious : T_RHR
	{
		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Malicious>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Enables XP bonuses for wrongdoing.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Malicious)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
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