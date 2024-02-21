using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Spendthrift : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spendthrift>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You buy random shit every level. You'll even go into debt to do it.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spendthrift)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Light_Packer),
						nameof(Luggage_Loser),
					},
					CharacterCreationCost = -4,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						cantLose = false,
						cantSwap = false,
						categories = { VTraitCategory.Trade },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Works with Sucker & Shrewd Negotiator." },
						upgrade = nameof(Spendthrift_Plus),
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			BuyRandomShit(agent, UnityEngine.Random.Range(1, 3), 1.0f);
		}

		


	}
}