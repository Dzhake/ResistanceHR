using ResistanceHR.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Combat_Ranged
{
	internal class Sniper_Plus : T_CombatRanged
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Sniper_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Using a silent ranged weapon while hidden behind a Bush or other object will not remove you from concealment.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Sniper_Plus)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { nameof(Myopic) },
					CharacterCreationCost = 8,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Guns },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { nameof(Eagle_Eyes) },
						recommendations = { nameof(Powder_Packer), /*nameof(Stealth_Bastard_Deluxe)*/ },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
