using RogueLibsCore;

namespace ResistanceHR.Progression
{
	internal class Calculating : T_ExperienceRate
	{
		internal override float ExperienceRate => 2.00f;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Calculating>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 200%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Calculating)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Studious,
						VanillaTraits.Studious2,
						nameof(Dim_Bulb),
						nameof(Moron_the_Merrier),
						nameof(Numskulled),
						nameof(Smooth_Brained),
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 25,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { VanillaTraits.Studious2 },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}