using RogueLibsCore;

namespace RHR.Combat_Ranged
{
	public class Powder_Packer : T_BulletModification
	{
		public override float BulletDamageMultiplier => 0.90f;
		public override float BulletRangeMultiplier => 1.20f;
		public override float BulletPenetrationMultiplier => 1.50f;
		public override float BulletSpeedMultiplier => 1.10f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Powder_Packer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your bullets fly faster, further, and penetrate armor. But they deal slightly less damage.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Powder_Packer)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						categories = { VTraitCategory.Guns },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						upgrade = nameof(Powder_Packer_Plus),
					}
				});
		}
		

	}
}
