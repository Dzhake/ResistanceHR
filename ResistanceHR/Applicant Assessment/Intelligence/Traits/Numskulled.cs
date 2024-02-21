using RogueLibsCore;

namespace RHR.Progression
{
	public class Numskulled : T_ExperienceRate
	{
		public override float ExperienceRate => 0.25f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Numskulled>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 25%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Numskulled)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Studious,
						VanillaTraits.Studious2,
						nameof(Brainiac),
						nameof(Dim_Bulb),
						nameof(Moron_the_Merrier),
						nameof(Smooth_Brained),
					},
					CharacterCreationCost = -24,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 50,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "A good helmet"},
						upgrade = null,
					}
				});
		}

		

	}
}