using RogueLibsCore;

namespace ResistanceHR.Progression
{
	internal class Moron_the_Merrier : T_ExperienceRate
	{
		internal override float ExperienceRate => 0.50f;

		[RLSetup]
		internal static void Setup()
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
					CharacterCreationCost = -20,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "The Police are always hiring." },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}