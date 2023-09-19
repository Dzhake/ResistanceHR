using ResistanceHR.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Combat_Ranged
{
	internal class Powder_Packer : T_BulletModification
	{
		internal override float BulletDamageMultiplier => 0.90f;
		internal override float BulletRangeMultiplier => 1.20f;
		internal override float BulletPenetrationMultiplier => 1.50f;
		internal override float BulletSpeedMultiplier => 1.10f;

		[RLSetup]
		internal static void Setup()
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
					Cancellations = { nameof(Myopic) },
					CharacterCreationCost = 4,
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
						prerequisites = { nameof(Eagle_Eyes) },
						recommendations = { nameof(Eagle_Eyes) },
						upgrade = nameof(Powder_Packer_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
