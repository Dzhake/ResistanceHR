using RogueLibsCore;

namespace RHR.Combat_Ranged
{
	public class Sniper : T_CombatRanged
	{
		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Sniper>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Past a certain distance, Revolver hits deal massive damage. This minimum range is reduced on unaware targets.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Sniper)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {  },
					CharacterCreationCost = 4,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Guns },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						recommendations = { nameof(Powder_Packer) },
						upgrade = nameof(Sniper_Plus),
					}
				});
		}
		

	}
}