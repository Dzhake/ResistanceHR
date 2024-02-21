using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Quest_Modifiers
{
	public class Monkey_Rewards : T_QuestRewards
	{
		public override int? RewardItemBaseQty => 3;
		public override List<string> RewardItems => new List<string>() { VanillaItems.Banana };
		public override float RewardMoneyMultiplier => 1f;
		public override float RewardXPMultiplier => 1f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Monkey_Rewards>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Someone made a typo. But we honor our promises, so we'll pay you in Bananas.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Monkey_Rewards)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Double_Ply_Rewards),
						nameof(Liquid_Lunch),
						nameof(Supply_Drops),
						nameof(Smoke_Up_Johnny),
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		

	}
}