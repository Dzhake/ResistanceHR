using RogueLibsCore;

namespace RHR.Progression
{
	public class Moron_the_Merrier : T_ExperienceRate
	{
		public override float ExperienceRate => 0.50f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Moron_the_Merrier>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 50%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Moron_the_Merrier)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Studious,
						VanillaTraits.Studious2,
						nameof(Brainiac),
						nameof(Dim_Bulb),
						nameof(Numskulled),
						nameof(Smooth_Brained),
					},
					CharacterCreationCost = -16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true, // test
						prerequisites = { },
						recommendations = { "The Police are always hiring." },
						upgrade = null,
					}
				});
		}

		

	}
}