using RogueLibsCore;

namespace RHR.Vision_Range
{
	public class Myopic_Plus : T_VisionRange
	{
		public override float ZoomLevel => 2.00f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Myopic_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You can't see your own hands in front of your face. I'm giving you the finger, right now!",
					[LanguageCode.Russian] = "Обычно вы держите людей на расстоянии вытянотой руки, жаль что вы их всё равно не видите.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Myopic_Plus)),
					[LanguageCode.Russian] = "близорукость +",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Myopic)
					},
					CharacterCreationCost = -16,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {  },
						isUpgrade = false,
						prerequisites = { nameof(Myopic) },
						recommendations = { "A telescope strapped to your face" },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
