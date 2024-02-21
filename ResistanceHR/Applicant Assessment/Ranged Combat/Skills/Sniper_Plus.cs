using RogueLibsCore;

namespace RHR.Combat_Ranged
{
	public class Sniper_Plus : T_CombatRanged
	{
		//[RLSetup]
		public static void Setup()
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
					Cancellations = { },
					CharacterCreationCost = 8,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Guns },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						recommendations = { nameof(Powder_Packer), /*nameof(Stealth_Bastard_Deluxe)*/ },
						upgrade = null,
					}
				});
		}
		

	}
}