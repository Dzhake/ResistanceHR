using ResistanceHR.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Combat_Ranged
{
	internal class Dum_Dum_Bum_Plus : T_BulletModification
	{
		internal override float BulletDamageMultiplier => 1.30f;
		internal override float BulletRangeMultiplier => 0.50f;
		internal override float BulletPenetrationMultiplier => 0.80f;
		internal override float BulletSpeedMultiplier => 0.20f;

		[RLSetup]
		internal static void Setup()
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
					CharacterCreationCost = 6,
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
						prerequisites = { nameof(Myopic) },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
