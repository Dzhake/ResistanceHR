using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Inventory
{
	internal class Lock_and_Loadout : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lock_and_Loadout>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You receive a resupply of your item loadout at the start of new floors.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lock_and_Loadout)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 25,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void RefreshAtLevelStart(Agent myAgent)
		{
			List<string> loadout = new List<string>((List<string>)AccessTools.DeclaredField(typeof(SessionDataBig), "characterStartingItems" + Owner.isPlayer.ToString()).GetValue(GC.sessionDataBig));

			foreach (string itemName in loadout)
			{
				InvItem item = new InvItem();
				item.invItemName = itemName;
				item.SetupDetails(false);
				item.invItemCount = item.initCount;
				myAgent.inventory.AddItem(item);
			}

			return;
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}