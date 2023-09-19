using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;

namespace ResistanceHR.Conduct
{
	class Discovery_Disincentivizer : M_ComplianceChip
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true;

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new M_RHR(nameof(Discovery_Disincentivizer), true))
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you not anger any quest chunk NPCs. Or else.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = PlayerName(typeof(Discovery_Disincentivizer)),
				});
		}
	}

	[HarmonyPatch(typeof(Relationships))]
	class P_Relationships_NoAlerts
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Relationships.AddToAngerStat))]
		private static void CheckAlert(Relationships __instance, Agent otherAgent)
		{
			Agent agent = (Agent)AccessTools.DeclaredField(typeof(Relationships), "agent").GetValue(__instance);
			Quest currentQuest = agent.GetCurrentQuest();

			if (currentQuest != null
				&& currentQuest.angeredOnQuest[otherAgent.isPlayer]
				&& GC.challenges.Contains(nameof(Discovery_Disincentivizer)))
				otherAgent.StartCoroutine("SuicideWhenPossible");
		}
	}
}