using RogueLibsCore;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Rushin_Revolution : T_QuestCount
	{
		public override int QuestCount => 0;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Rushin_Revolution>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "No quests. Bum rush the Mayor. Take a long weekend.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Rushin_Revolution), "Rushin' Revolution"),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Workaholic)
					},
					CharacterCreationCost = 16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 25,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { nameof(Workaholic) },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}