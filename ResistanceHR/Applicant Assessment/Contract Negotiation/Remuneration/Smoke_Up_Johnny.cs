using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Quest_Modifiers
{
	public class Smoke_Up_Johnny : T_QuestRewards
	{
		public override int? RewardItemBaseQty => 3;
		public override List<string> RewardItems => new List<string>() { VanillaItems.Cigarettes };
		public override float RewardMoneyMultiplier => 1f;
		public override float RewardXPMultiplier => 1f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Smoke_Up_Johnny>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You wanted to get paid in smokes. Wooooow, look at the cool guy here.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Smoke_Up_Johnny), "Smoke Up, Johnny!"),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Double_Ply_Rewards),
						nameof(Liquid_Lunch),
						nameof(Supply_Drops),
						nameof(Monkey_Rewards),
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
						recommendations = { "Matt Dabrowski says: <i>Smoking is fun, kids!</i>" },
						upgrade = null,
					}
				});
		}

		

	}
}