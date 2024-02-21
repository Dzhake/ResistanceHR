using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Luggage_Loser : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Luggage_Loser>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your entire inventory gets mysteriously lost in between levels.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Luggage_Loser)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Light_Packer),
					},
					CharacterCreationCost = -16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
					Unlock =
					{
						cantLose = false,
						cantSwap = false,
						categories = { },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Send a birthday card to the Chief of Customs Enforcement with $1,200 inside." },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			logger.LogDebug("Refresh: Luggage_Loser");
			agent.inventory.EquipWeapon(agent.inventory.fist);
			int moneyCount = agent.inventory.money.invItemCount;
			agent.inventory.ClearInventory(false);
			agent.inventory.AddItem(VanillaItems.Money, moneyCount);
		}

		

	}
}