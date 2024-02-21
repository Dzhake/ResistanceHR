using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Quest_Modifiers
{
	public abstract class T_QuestRewards : T_RHR, IRefreshAtEndOfLevelStart
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public T_QuestRewards() : base() { }

		public abstract int? RewardItemBaseQty { get; }
		public abstract List<string> RewardItems { get; }
		public List<string> RewardItemPool = new List<string>() { };
		public abstract float RewardMoneyMultiplier { get; }
		public abstract float RewardXPMultiplier { get; }

		public bool BypassUnlockChecks => false;
		public void Refresh(Agent agent)
		{
			ResetPool();
		}
		public void Refresh() { }
		public void RefreshInactive() { }
		public bool RunThisLevel() => true;

		private void ResetPool()
		{
			RewardItemPool = new List<string>(RewardItems);
		}
		public string RollItemName()
		{
			if (RewardItemPool.Count == 0)
				ResetPool();

			int index = UnityEngine.Random.Range(0, RewardItemPool.Count);
			string itemName = RewardItemPool[index];
			RewardItemPool.RemoveAt(index);
			return itemName;
		}

		public override void OnAdded()
		{
			ResetPool();
		}
	}

	[HarmonyPatch(typeof(Quests))]
	public static class P_Quests_QuestRewards
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(Quests.GetLevelExitChallengeItem))]
		private static bool SetQuestRewards(Quests __instance, ref InvItem __result)
		{
			T_QuestRewards trait = GC.playerAgentList.SelectMany(pa => pa.GetTraits<T_QuestRewards>()).FirstOrDefault();

			if (trait is null || trait.RewardItems.Count == 0)
				return true;

			InvItem invItem = new InvItem();
			invItem.invItemName = trait.RollItemName();
			invItem.SetupDetails(false);

			if (trait.RewardItemBaseQty is null)
				invItem.invItemCount = invItem.rewardCount;
			else
				invItem.invItemCount = (int)trait.RewardItemBaseQty;

			__result = invItem;

			return false;
		}
	}
}