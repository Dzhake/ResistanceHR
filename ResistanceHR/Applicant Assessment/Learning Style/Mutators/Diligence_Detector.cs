using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;

namespace RHR.Conduct
{
	class Diligence_Detector : M_ComplianceChip, IRefreshAtEndOfLevelStart
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public Diligence_Detector() : base(nameof(Diligence_Detector)) { }

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true;

		//	IRefreshAtEndOfLevelStart
		public bool BypassUnlockChecks => true; // This will need to run based on the PREVIOUS level's challenges
		public void Refresh() { }
		public void Refresh(Agent agent)
		{
			if (agent.isPlayer == 0)
				return;

			// TODO: Check for last level having this challenge, since this is overflowing their BQ failure to the next level

			logger.LogDebug("Checking BQM for : " + agent.agentRealName);

			if (agent.failingBigQuestLevel
				|| GC.sessionData.bigQuestStatusGame[agent.isPlayer - 1] == "QuestFailed"
				|| GC.sessionData.bigQuestStatusTheme[agent.isPlayer - 1] == "QuestWaitForNextGame"
				|| GC.sessionData.bigQuestStatusTheme[agent.isPlayer - 1] == "QuestStartFromBeginning"
				|| agent.oma.bigQuestObjectCountTotal == 255)
				agent.StartCoroutine("SuicideWhenPossible");
		}
		public bool RunThisLevel() => true;

		//[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new Diligence_Detector())
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you complete your Big Quest. Or else.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Diligence_Detector)),
				});
		}
	}

	[HarmonyPatch(typeof(Quests))]
	class P_Quests_BigQuestMandatory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Quests.SpawnBigQuestFailedText2))]
		private static void MandatoryBigQuest()
		{
			if (GC.challenges.Contains(nameof(Diligence_Detector)))
				foreach (Agent agent in GC.playerAgentList)
					agent.StartCoroutine("SuicideWhenPossible");
		}
	}

	[HarmonyPatch(typeof(StatsScreen))]
	class P_StatsScreen_BQM
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(StatsScreen.DoStatsScreenUnlocks))]
		private static void MaybeExplode(StatsScreen __instance)
		{
			bool quickGame = GC.challenges.Contains(VanillaMutators.QuickGame);
			bool districtQuestComplete = false;
			bool runQuestComplete = false;
			bool gonnaExplode = false;

			if (GC.quests.CanHaveBigQuest(__instance.agent))
			{
				if (GC.quests.BigQuestBasedOnTotal(__instance.agent))
				{
					if (!((
						(!quickGame && (GC.sessionDataBig.curLevel == 3 || GC.sessionDataBig.curLevel == 6 || GC.sessionDataBig.curLevel == 9 || GC.sessionDataBig.curLevel == 12 || GC.sessionDataBig.curLevel == 15))
						|| (quickGame && (GC.sessionDataBig.curLevel == 2 || GC.sessionDataBig.curLevel == 4 || GC.sessionDataBig.curLevel == 6 || GC.sessionDataBig.curLevel == 8 || GC.sessionDataBig.curLevel == 10)))
							&& GC.quests.CheckIfBigQuestCompleteTheme(__instance.agent, false)))
						gonnaExplode = true;

					if (!(((!quickGame && GC.sessionDataBig.curLevel == 15)
						|| (quickGame && GC.sessionDataBig.curLevel == 10))
						&& GC.quests.CheckIfBigQuestCompleteRun(__instance.agent, false) && !GC.challenges.Contains("Endless")))
						gonnaExplode = true;
				}
				else if (__instance.agent.oma.bigQuestObjectCountTotal != 0)
				{
					if (GC.quests.CheckIfBigQuestCompleteFloor(__instance.agent))
					{
						if (GC.quests.CheckIfBigQuestCompleteTheme(__instance.agent, false))
							districtQuestComplete = true;

						if (GC.quests.CheckIfBigQuestCompleteRun(__instance.agent, false) && !GC.challenges.Contains("Endless"))
							runQuestComplete = true;
					}
					else
					{
						if (GC.sessionData.bigQuestStatusGame[__instance.agent.isPlayer - 1] != "QuestWaitForNextGame" && GC.sessionData.bigQuestStatusGame[__instance.agent.isPlayer - 1] != "QuestStartFromBeginning")
							gonnaExplode = true;

						if (GC.sessionData.bigQuestStatusTheme[__instance.agent.isPlayer - 1] != "QuestWaitForNextArea")
							gonnaExplode = true;
					}
				}
				else if (GC.quests.CheckIfBigQuestCompleteTheme(__instance.agent, false))
				{
					districtQuestComplete = true;

					if (GC.quests.CheckIfBigQuestCompleteRun(__instance.agent, false) && !GC.challenges.Contains("Endless"))
						runQuestComplete = true;
				}

				if (gonnaExplode)
					__instance.agent.StartCoroutine("SuicideWhenPossible");
			}
		}
	}
}