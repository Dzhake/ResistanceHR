using RogueLibsCore;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Workaholic : T_QuestCount
	{
		public override int QuestCount => 4;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Workaholic>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Guaranteed four quests per level. Are you just avoiding your ugly spouse?",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Workaholic)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Rushin_Revolution)
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}