using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Quest_Modifiers
{
	public class Supply_Drops : T_QuestRewards
	{
		public override int? RewardItemBaseQty => null;
		public override List<string> RewardItems =>
			Owner.customCharacterData.items.Where(i => i != VanillaItems.Money).ToList();
		//(List<string>)AccessTools.DeclaredField(typeof(SessionDataBig), ("characterStartingItems" + Owner.isPlayer).ToString()).GetValue(gc.sessionDataBig);
		public override float RewardMoneyMultiplier => 0f;
		public override float RewardXPMultiplier => 1f;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Supply_Drops>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Quest rewards are your loadout items.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Supply_Drops)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Double_Ply_Rewards),
						nameof(Liquid_Lunch),
						nameof(Monkey_Rewards),
						nameof(Smoke_Up_Johnny),
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
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