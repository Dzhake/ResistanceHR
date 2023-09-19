using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Loadout_Rewards : T_QuestRewards
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
			RogueLibs.CreateCustomTrait<Loadout_Rewards>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Quest rewards are your loadout items.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Loadout_Rewards)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Double_Ply_Rewards),
						nameof(Lump_Sum_Rewards),
						nameof(Monkey_Rewards),
						nameof(Unpaid_Internship),
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
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

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}