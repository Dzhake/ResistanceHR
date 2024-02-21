using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Index_Funder_Plus : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Index_Funder_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You accrue a pretty good interest (8 - 12%) on your money every level. Not bad!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Index_Funder_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = true,
					UnlockCost = 0,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Trade },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);
			money.invItemCount = (int)(money.invItemCount * UnityEngine.Random.Range(1.08f, 1.12f));
		}

		

	}
}