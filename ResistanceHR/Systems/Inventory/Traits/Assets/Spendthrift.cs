using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Inventory
{
	internal class Spendthrift : T_Inventory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
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
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
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

		public override void RefreshAtLevelStart() { }
		public override void RefreshAtLevelStart(Agent agent)
		{
			BuyRandomShit(agent, UnityEngine.Random.Range(1, 3), 1.0f);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }

	}
}