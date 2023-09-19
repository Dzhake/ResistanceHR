using RogueLibsCore;

namespace ResistanceHR.Combat_Ranged
{
	internal class Wetworker : T_CombatRanged
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Wetworker>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Bullet attacks from behind within melee range do 2x damage. 10x if you're invisible or hidden.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Wetworker)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { VanillaTraits.Loud },
					CharacterCreationCost = 8,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Guns },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
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
