using RogueLibsCore;

namespace ResistanceHR.Vision_Range
{
	internal class Eagle_Eyes_Plus : T_VisionRange
	{
		internal override float ZoomLevel => 0.25f; //0.60f; // Lower value for testing only

		//[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Eagle_Eyes_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You can see further than <i>abnormal</i>.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Eagle_Eyes_Plus)),
					[LanguageCode.Russian] = "Орлиные глаза +",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = true,
						cantSwap = false,
						categories = {  },
						isUpgrade = false,
						//prerequisites = { nameof(Eagle_Eyes) },
						recommendations = { "Uh this is bugged. I think don't even use it yet." },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
