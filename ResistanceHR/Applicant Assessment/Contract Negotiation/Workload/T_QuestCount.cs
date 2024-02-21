using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System.Linq;

namespace RHR.Quest_Modifiers
{
	public abstract class T_QuestCount : T_RHR
	{
		public T_QuestCount() : base() { }

		public abstract int QuestCount { get; }
	}

	[HarmonyPatch(typeof(Quests))]
	public static class P_Quests_QuestCount
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(Quests.setupQuests))]
		private static bool SetQuestCount()
		{
			T_QuestCount trait = GC.playerAgentList.SelectMany(pa => pa.GetTraits<T_QuestCount>()).FirstOrDefault();

			if (!(trait is null))
				GC.quests.questTriesTotal = trait.QuestCount;

			return true;
		}
	}

	[HarmonyPatch(typeof(ExitPoint))]
	public static class P_ExitPoint_QuestCount
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(ExitPoint.DetermineIfCanExit))]
		private static bool AllowExitWithZeroQuests(ref bool __result)
		{
			if (GC.quests.numQuests == 0)
			{
				__result = true;
				return false;
			}

			return true;
		}
	}
}