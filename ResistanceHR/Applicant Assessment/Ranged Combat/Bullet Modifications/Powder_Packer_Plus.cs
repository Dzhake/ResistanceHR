using RogueLibsCore;

namespace RHR.Combat_Ranged
{
	public class Powder_Packer_Plus : T_BulletModification
	{
		public override float BulletDamageMultiplier => 0.85f;
		public override float BulletRangeMultiplier => 1.40f;
		public override float BulletPenetrationMultiplier => 2.00f;
		public override float BulletSpeedMultiplier => 1.20f;

		[RLSetup]
		public static void Setup()
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
					Cancellations = {  },
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = true,
					Unlock =
					{
						categories = { VTraitCategory.Guns },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						upgrade = null,
					}
				});
		}
		

	}
}
