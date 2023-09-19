using ResistanceHR.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Combat_Ranged
{
	internal class Powder_Packer_Plus : T_BulletModification
	{
		internal override float BulletDamageMultiplier => 0.85f;
		internal override float BulletRangeMultiplier => 1.40f;
		internal override float BulletPenetrationMultiplier => 2.00f;
		internal override float BulletSpeedMultiplier => 1.20f;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Powder_Packer_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your bullets fly fasterer, furtherer, and penetrate armorer. But they deal slightly lesser damage.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Powder_Packer_Plus)),
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
						prerequisites = { nameof(Eagle_Eyes), nameof(Powder_Packer) },
						recommendations = { nameof(Eagle_Eyes) },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
