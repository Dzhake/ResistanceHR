using RogueLibsCore;

namespace ResistanceHR.Progression
{
	internal class Numskulled : T_ExperienceRate
	{
		internal override float ExperienceRate => 0.25f;

		[RLSetup]
		internal static void Setup()
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
					CharacterCreationCost = -30,
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
						recommendations = { "A good helmet"},
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}