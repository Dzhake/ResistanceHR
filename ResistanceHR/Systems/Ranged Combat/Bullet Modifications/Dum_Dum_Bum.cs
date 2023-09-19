using ResistanceHR.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Combat_Ranged
{
	internal class Dum_Dum_Bum : T_BulletModification
	{
		internal override float BulletDamageMultiplier => 1.15f;
		internal override float BulletRangeMultiplier => 0.75f;
		internal override float BulletPenetrationMultiplier => 0.90f;
		internal override float BulletSpeedMultiplier => 0.90f;

		[RLSetup]
		internal static void Setup()
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
					CharacterCreationCost = 3,
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
						prerequisites = { nameof(Myopic) },
						recommendations = { },
						upgrade = nameof(Dum_Dum_Bum_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
