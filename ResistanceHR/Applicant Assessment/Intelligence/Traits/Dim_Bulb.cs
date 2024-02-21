using RogueLibsCore;

namespace RHR.Progression
{
	public class Dim_Bulb : T_ExperienceRate
	{
		public override float ExperienceRate => 0.75f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Dim_Bulb>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 75%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Dim_Bulb)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Studious,
						VanillaTraits.Studious2,
						nameof(Brainiac),
						nameof(Moron_the_Merrier),
						nameof(Numskulled),
						nameof(Smooth_Brained),
					},
					CharacterCreationCost = -8,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						categories = {  },
						cantLose = false,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Oh, you! Just have fun out there!" },
						upgrade = nameof(Moron_the_Merrier),
					}
				});
		}

		

	}
}