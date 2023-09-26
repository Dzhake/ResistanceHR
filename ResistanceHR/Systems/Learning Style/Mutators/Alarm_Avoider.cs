using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using UnityEngine;

namespace ResistanceHR.Conduct
{
	class Alarm_Avoider : M_ComplianceChip
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true;

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new M_RHR(nameof(Alarm_Avoider), true))
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you not set off any alarms. Or else.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = PlayerName(typeof(Alarm_Avoider)),
				});
		}
	}

	[HarmonyPatch(typeof(SpawnerMain))]
	class P_SpawnerMain_DiscretionMandatory
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(SpawnerMain.SpawnNoise), new[] { typeof(Vector3), typeof(float), typeof(PlayfieldObject), typeof(string), typeof(Agent), typeof(bool), typeof(Agent) })]
		private static void Asplode(Vector3 noisePos, string noiseType)
		{
			if (noiseType == "Alarm"
				&& GC.challenges.Contains(nameof(Alarm_Avoider)))
			{
				for (int i = 0; i < GC.playerAgentList.Count; i++)
				{
					Agent agent = GC.playerAgentList[i];
					if (noisePos == agent.transform.position)
						agent.StartCoroutine("SuicideWhenPossible");
				}
			}
		}
	}
}