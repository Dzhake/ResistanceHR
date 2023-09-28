using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Inventory
{
	internal class Luggage_Loser : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Luggage_Loser>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You lose your entire inventory each level.",
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
					IsUnlocked = Core.DebugMode,
					UnlockCost = 30,
					Unlock =
					{
						cantLose = false,
						cantSwap = false,
						categories = { },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Maybe get your shit together." },
						upgrade = null,
					}
				});
		}

		public override void RefreshAtLevelStart(Agent agent)
		{
			agent.inventory.ClearInventory(false);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}