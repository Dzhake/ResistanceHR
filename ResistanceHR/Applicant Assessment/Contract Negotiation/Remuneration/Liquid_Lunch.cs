using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Quest_Modifiers
{
	public class Liquid_Lunch : T_QuestRewards
	{
		public override int? RewardItemBaseQty => null;
		public override List<string> RewardItems => new List<string>() { VanillaItems.Cocktail, VanillaItems.Beer, VanillaItems.Whiskey };
		public override float RewardMoneyMultiplier => 1f;
		public override float RewardXPMultiplier => 1f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Liquid_Lunch>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Don't be ashamed, a whole lot of people take this option. We're just cutting out the middleman.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Liquid_Lunch)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Double_Ply_Rewards),
						nameof(Monkey_Rewards),
						nameof(Smoke_Up_Johnny),
						nameof(Supply_Drops),
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