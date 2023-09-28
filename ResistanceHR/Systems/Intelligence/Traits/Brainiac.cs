using RogueLibsCore;

namespace ResistanceHR.Progression
{
	internal class Brainiac : T_ExperienceRate
	{
		internal override float ExperienceRate => 3.00f;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Brainiac>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 300%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Brainiac)),
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
					CharacterCreationCost = 24,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 50,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { VanillaTraits.Studious2 },
						recommendations = { "Stop talking about trains at parties. Ask other people what they're interested in." },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}