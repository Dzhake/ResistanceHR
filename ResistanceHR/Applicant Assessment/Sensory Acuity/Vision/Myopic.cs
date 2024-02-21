using RogueLibsCore;

namespace RHR.Vision_Range
{
	public class Myopic : T_VisionRange
	{
		public override float ZoomLevel => 1.50f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Myopic>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You can't see too far. In fact, you can't even see regular-far, or even far enough!",
					[LanguageCode.Russian] = "Вы не можете видеть слишком далеко.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Myopic)),
					[LanguageCode.Russian] = "Близорукость",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						//nameof(Eagle_Eyes),
					},
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {  },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Glasses" },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
