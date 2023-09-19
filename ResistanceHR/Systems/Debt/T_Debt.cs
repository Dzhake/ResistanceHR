using BepInEx.Logging;
using System.Linq;

namespace ResistanceHR.Debt
{
	internal abstract class T_Debt : T_RHR, IRefreshAtLevelStart
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		internal abstract string statusEffectName { get; }
		internal abstract string enforcerClassName { get; }
		internal abstract int debtAmount { get; } // 
		internal abstract string currencyItemName { get; } // Banana, Organ, Blood Pack, 
		internal abstract float debtToEnforcerCountRatio { get; } // Vanilla is $50 per Assassin

		public override void OnAdded() { }
		public override void OnRemoved() { }

		public void RefreshAtLevelStart(Agent agent)
		{
			agent.statusEffects.AddStatusEffect(statusEffectName, 9999);
			StatusEffect statusEffectObject = agent.statusEffects.StatusEffectList.FirstOrDefault(se => se.statusEffectName == statusEffectName);
			GC.sessionData.debtAmount[Owner.isPlayer - 1] = debtAmount;

			if (statusEffectObject is null)
				return;

			statusEffectObject.dontRemoveOnDeath = true; // Dead deadbeats don't get a break
		}

		public bool RefreshThisLevel(int curLevelEndless) =>
			curLevelEndless == 1;
	}
}