using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Inventory
{
	internal class Liquidator_Plus : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Liquidator_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You sell off 40% of your inventory every level, at a better rate than before.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Liquidator_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Light_Packer),
						nameof(Luggage_Loser),
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = true,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Trade },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Works with Sucker & Shrewd Negotiator." },
						upgrade = null,
					}
				});
		}

		public override void RefreshAtLevelStart(Agent agent)
		{
			SellRandomShit(agent, (int)(FungibleItems(agent).Count * 0.40f), 1.00f, false);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}