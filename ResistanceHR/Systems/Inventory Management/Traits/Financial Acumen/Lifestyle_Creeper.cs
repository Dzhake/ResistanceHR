using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Inventory
{
	internal class Lifestyle_Creeper : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lifestyle_Creeper>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You find a way to waste 50% of your money in between levels. Do you think people are impressed?!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lifestyle_Creeper)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Try meal prep instead of eating out." },
						upgrade = null,
					}
				});
		}

		public override void RefreshAtLevelStart(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);
			money.invItemCount = (int)(money.invItemCount / 2f);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}