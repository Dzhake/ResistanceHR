using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Debt
{
	internal class Bank_Debt_250 : T_Debt, ISetupAgentStats, IRefreshAtLevelStart
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		internal override string statusEffectName => VanillaEffects.InDebt1;
		internal override string enforcerClassName => VanillaAgents.Assassin; // vanilla
		internal override int debtAmount => 250;
		internal override string currencyItemName => VanillaItems.Money;
		internal override float debtToEnforcerCountRatio => 50f; // vanilla

		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Bank_Debt_250>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You owe $250 to the Bank. They are not happy about this.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Bank_Debt_250))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -4,
					IsAvailable = false,
					IsAvailableInCC = true,
					UnlockCost = 0,
					Upgrade = null,
					Unlock =
					{
						categories = { VTraitCategory.Trade },
						cantLose = true,
						removal = false,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }

		public void SetupAgentStats(Agent agent)
		{
			throw new System.NotImplementedException();
		}
	}
}