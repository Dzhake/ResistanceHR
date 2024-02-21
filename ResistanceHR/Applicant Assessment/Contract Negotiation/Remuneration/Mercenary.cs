using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Mercenary : T_QuestRewards
	{
		public override int? RewardItemBaseQty => null;
		public override List<string> RewardItems => new List<string>() { VanillaItems.Money };
		public override float RewardMoneyMultiplier => 2f;
		public override float RewardXPMultiplier => 0f;

		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mercenary>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "No XP or reward item for quests. Just da cash!",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mercenary)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Trade },
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