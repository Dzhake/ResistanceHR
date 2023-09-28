using RogueLibsCore;

namespace ResistanceHR.Progression
{
	internal class Smooth_Brained : T_ExperienceRate
	{
		internal override float ExperienceRate => 0.00f;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Smooth_Brained>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 0%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Smooth_Brained)),
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
						nameof(Numskulled),
					},
					CharacterCreationCost = -32,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 65,
					Unlock =
					{
						categories = {  },
						cantLose = false,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Don't put that in your mouth. Put it down." },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}