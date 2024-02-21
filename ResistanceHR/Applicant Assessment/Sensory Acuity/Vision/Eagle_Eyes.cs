using RogueLibsCore;

namespace ResistanceHR.Vision_Range
{
	internal class Eagle_Eyes : T_VisionRange
	{
		internal override float ZoomLevel => 0.80f;

		//[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Eagle_Eyes>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You can see further than normal.",
					[LanguageCode.Russian] = "Вы можете видеть дальше, чем обычно. Чёрт! Это же ненормально!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Eagle_Eyes)),
					[LanguageCode.Russian] = "Орлиные глаза",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Myopic),
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
					Unlock =
					{
						cantLose = true,
						cantSwap = false,
						categories = {  },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Uh this is bugged. I think don't even use it yet." },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}