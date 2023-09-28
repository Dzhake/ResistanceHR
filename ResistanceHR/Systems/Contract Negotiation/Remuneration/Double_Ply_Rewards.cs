using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Double_Ply_Rewards : T_QuestRewards
	{
		public override int? RewardItemBaseQty => 1;
		public override List<string> RewardItems => new List<string>() { VanillaItems.FreeItemVoucher, VanillaItems.HiringVoucher };
		public override float RewardMoneyMultiplier => 1f;
		public override float RewardXPMultiplier => 1f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Double_Ply_Rewards>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance shows their appreciation with this stack of Resistance coupons! They are totally really actually valid. The smell? That's <i>value</i>!",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Double_Ply_Rewards), "Double-Ply Rewards"),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Supply_Drops),
						nameof(Liquid_Lunch),
						nameof(Monkey_Rewards),
						nameof(Smoke_Up_Johnny),
					},
					CharacterCreationCost = 5,
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