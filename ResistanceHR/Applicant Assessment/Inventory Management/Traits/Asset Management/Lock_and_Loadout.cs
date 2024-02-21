using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Inventory
{
	public class Lock_and_Loadout : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lock_and_Loadout>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You receive a resupply of your item loadout at the start of new floors.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lock_and_Loadout)), //	You fucking dork, resist the urge to put an ampersand because it matches vanilla
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
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

		public override void Refresh(Agent myAgent)
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

		

	}
}