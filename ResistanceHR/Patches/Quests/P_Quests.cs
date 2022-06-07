using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Challenges.Quest_Rewards;
using RogueLibsCore;
using System.Linq;

namespace ResistanceHR.Patches.Questicles
{
    [HarmonyPatch(declaringType: typeof(Quests))]
	public static class P_Quests
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(Quests.GetLevelExitChallengeItem))]
		private static bool GetLevelExitChallengeItem_Prefix(Quests __instance, ref InvItem __result)
		{
			C_QuestRewards challenge = RogueFramework.Unlocks.OfType<C_QuestRewards>().Where(c => c.IsEnabled).FirstOrDefault();

			if (challenge is null)
				return true;

			if (challenge.RewardItems.Any())
            {
				string rewardName = challenge.RewardItems[UnityEngine.Random.Range(0, challenge.RewardItems.Count - 1)];
				
				InvItem invItem = new InvItem();
				invItem.invItemName = rewardName;
				invItem.SetupDetails(false);

				// rewardCount is the vanilla number of that reward item.
				if (rewardName == VanillaItems.Money)
                {
					if (challenge is Unpaid_Internship)
						invItem.invItemCount = 0;
					else
						invItem.invItemCount = GC.playerAgent.inventory.MoneyAdjustForPlayers(UnityEngine.Random.Range(30, 70)) * 2;
				}
				else
					invItem.invItemCount = invItem.rewardCount;
			}

			return false;
		}
	}
}