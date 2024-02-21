using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Liquidator : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

		public override void Refresh(Agent agent)
		{
			SellRandomShit(agent, (int)(FungibleItems(agent).Count * 0.20f), 0.75f, false);
		}

		

	}
}