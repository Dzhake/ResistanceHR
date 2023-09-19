using RogueLibsCore;

namespace ResistanceHR.Ethics
{
	internal class Malicious : T_RHR
	{
		//[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}