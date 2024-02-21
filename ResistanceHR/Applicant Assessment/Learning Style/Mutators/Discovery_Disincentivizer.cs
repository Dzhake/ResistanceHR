using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;

namespace RHR.Conduct
{
	class Discovery_Disincentivizer : M_ComplianceChip
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public Discovery_Disincentivizer() : base(nameof(Discovery_Disincentivizer)) { }

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true;

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new Discovery_Disincentivizer())
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you not anger any quest chunk NPCs. Or else.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Discovery_Disincentivizer)),
				});
		}
	}

	[HarmonyPatch(typeof(Relationships))]
	class P_Relationships_NoAlerts
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Relationships.AddToAngerStat))]
		private static void CheckAlert(Relationships __instance, Agent otherAgent)
		{
			// BUG: Guard saw me after retrieval quest was completed, and it triggered this  
				//[Error: Unity Log] IndexOutOfRangeException: Index was outside the bounds of the array.
				//Stack trace:
				//ResistanceHR.Conduct.P_Relationships_NoAlerts.CheckAlert(Relationships __instance, Agent otherAgent)(at < 56a93082b53a47afb87607955572a1a9 >:0)
				//Relationships.AddToAngerStat(Agent otherAgent, Relationship rel)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//DebugulationsUponYe.SetRel(Relationships __instance, Agent otherAgent, System.String newRel, System.Boolean cameFromServer)(at < 56a93082b53a47afb87607955572a1a9 >:0)
				//Relationships.SetRel(Agent otherAgent, System.String newRel, System.Boolean cameFromServer)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//Relationships.SetRel(Agent otherAgent, System.String newRel)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//Relationships.DetermineRel(Agent otherAgent, Relationship myRel)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//Relationships.SetRelHate(Agent otherAgent, System.Int32 newHate)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//Relationships.OwnCheck(Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.Int32 tagType, System.String ownCheckType, System.Boolean extraSprite, System.Int32 strikes, Fire fire)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//GameController.OwnCheck(Agent otherAgent, UnityEngine.GameObject affectedGameObject, System.String ownCheckType, System.Int32 strikes, Fire fire)(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//Fire +< DoOwnChecks > d__65.MoveNext()(at<c91d003c54a541caabaa8c305d5e31e5>:0)
				//UnityEngine.SetupCoroutine.InvokeMoveNext(System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress)(at<a5d0703505154901897ebf80e8784beb>:0)

			Agent agent = (Agent)AccessTools.DeclaredField(typeof(Relationships), "agent").GetValue(__instance);
			Quest currentQuest = agent.GetCurrentQuest();

			if (currentQuest != null
					&& GC.challenges.Contains(nameof(Discovery_Disincentivizer))
					&& currentQuest.angeredOnQuest[otherAgent.isPlayer])
				otherAgent.StartCoroutine("SuicideWhenPossible");
		}
	}
}