using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Lifestyle_Creeper : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);
			money.invItemCount = (int)(money.invItemCount / 2f);
		}

		

	}
}