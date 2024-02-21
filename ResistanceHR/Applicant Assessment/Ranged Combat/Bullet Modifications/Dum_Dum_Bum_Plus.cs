using RogueLibsCore;

namespace RHR.Combat_Ranged
{
	public class Dum_Dum_Bum_Plus : T_BulletModification
	{
		public override float BulletDamageMultiplier => 1.30f;
		public override float BulletRangeMultiplier => 0.50f;
		public override float BulletPenetrationMultiplier => 0.80f;
		public override float BulletSpeedMultiplier => 0.80f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Dum_Dum_Bum_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your bullets have lowerer speed and distance, but deal even morer damage.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Dum_Dum_Bum_Plus)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
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
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}
