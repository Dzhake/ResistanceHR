using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Inventory
{
	internal class Index_Funder : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Index_Funder>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You accrue modest interest (3 - 8%) on your money every level. Sensible.",
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
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Trade },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Just keep working forever! You won't feel like a chump, I promise." },
						upgrade = null,
					}
				});
		}

		public override void RefreshAtLevelStart(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);
			money.invItemCount = (int)(money.invItemCount * UnityEngine.Random.Range(1.03f, 1.08f));
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}