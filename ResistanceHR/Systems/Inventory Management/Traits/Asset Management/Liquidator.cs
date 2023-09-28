using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Inventory
{
	internal class Liquidator : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Liquidator>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You sell off 20% of your inventory every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Liquidator)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Light_Packer),
						nameof(Luggage_Loser),
					},
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Trade },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Works with Sucker & Shrewd Negotiator." },
						upgrade = nameof(Liquidator_Plus),
					}
				});
		}

		public override void RefreshAtLevelStart(Agent agent)
		{
			SellRandomShit(agent, (int)(FungibleItems(agent).Count * 0.20f), 0.75f, false);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}