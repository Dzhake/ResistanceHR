using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Light_Packer : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Light_Packer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You lose all but five items between each level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Light_Packer)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Liquidator),
						nameof(Luggage_Loser),
					},
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = false,
						cantSwap = false,
						categories = { },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			SellRandomShit(agent, FungibleItems(agent).Count - 5, 0.0f, true);
		}

		

	}
}