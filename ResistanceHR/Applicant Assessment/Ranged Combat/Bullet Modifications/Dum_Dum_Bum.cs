using RogueLibsCore;

namespace RHR.Combat_Ranged
{
	public class Dum_Dum_Bum : T_BulletModification
	{
		public override float BulletDamageMultiplier => 1.15f;
		public override float BulletRangeMultiplier => 0.75f;
		public override float BulletPenetrationMultiplier => 0.90f;
		public override float BulletSpeedMultiplier => 0.90f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Dum_Dum_Bum>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your bullets have lower speed and distance, but deal more damage.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Dum_Dum_Bum)),
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
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Dum_Dum_Bum_Plus),
					}
				});
		}
		

	}
}
