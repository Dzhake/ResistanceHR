using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Index_Funder : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Index_Funder>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You accrue modest interest (4 - 8%) on your money every level. Sensible.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Index_Funder)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Trade },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Just keep working forever! You won't feel like a chump, I promise." },
						upgrade = nameof(Index_Funder_Plus),
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);
			money.invItemCount = (int)(money.invItemCount * UnityEngine.Random.Range(1.04f, 1.08f));
		}

		

	}
}