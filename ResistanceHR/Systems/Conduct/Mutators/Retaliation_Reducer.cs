﻿using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;

namespace ResistanceHR.Conduct
{
	class Retaliation_Reducer : M_ComplianceChip
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true;

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new M_RHR(nameof(Retaliation_Reducer), true))
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you refrain from neutralizing NPCs inside quest chunks. Or else.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = PlayerName(typeof(Retaliation_Reducer)),
				});
		}
	}

	[HarmonyPatch(typeof(Relationships))]
	class P_Relationships_RetaliationReducer
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Relationships.AddToKillStat))]
		private static void CheckKill(Relationships __instance, Agent otherAgent)
		{
			Agent agent = (Agent)AccessTools.DeclaredField(typeof(Relationships), "agent").GetValue(__instance);
			Quest currentQuest = agent.GetCurrentQuest();

			if (!(agent is null) && !(currentQuest is null) && currentQuest.questType != ""
					&& currentQuest.killedOnQuest[otherAgent.isPlayer] // NRE?
					&& GC.challenges.Contains(nameof(Retaliation_Reducer)))
				otherAgent.StartCoroutine("SuicideWhenPossible");
		}
	}
}