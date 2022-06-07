using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Traits.Vision_Range;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ResistanceHR.Patches
{
	[HarmonyPatch(declaringType: typeof(Agent))]
    public static class P_Agent
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		// TODO: Transpilerize
		/// <summary>
		/// View Distance Agent activation
		/// </summary>
		/// <param name="__instance"></param>
		/// <param name="__result"></param>
		/// <returns></returns>
		[HarmonyPrefix, HarmonyPatch(methodName: nameof(Agent.AgentOnCamera))]
		public static bool AgentOnCamera_Prefix(Agent __instance, ref bool __result)
		{
			if (__instance.isPlayer != 0)
			{
				__instance.onCamera = true;

				__result = true;
				return false;
			}

			if (GC.serverPlayer)
			{
				if ((!__instance.brain.active && !__instance.oma._dead && !__instance.frozen && !__instance.wasPossessed2 && GC.serverPlayer &&
					GC.loadCompleteReally && !GC.loadLevel.recentlyStartedLevel && !__instance.oma.mindControlled) || __instance.objectAgent)
				{
					__instance.onCamera = false;

					__result = false;
					return false;
				}
			}
			else if ((!__instance.brain.active && !__instance.dead && !__instance.frozen && !__instance.wasPossessed2 && GC.serverPlayer &&
				GC.loadCompleteReally && !GC.loadLevel.recentlyStartedLevel) || __instance.objectAgent)
			{
				__instance.onCamera = false;

				__result = false;
				return false;
			}

			Vector2 v = __instance.tr.position;
			Vector2 vector = GC.playerAgent.agentCamera.originalCamera.WorldToViewportPoint(v);
			float x = vector.x / T_VisionRange.GetZoomLevel(__instance);
			float y = vector.y / T_VisionRange.GetZoomLevel(__instance);

			if (x > -0.1f && x < 1.1f &&
				y > -0.1f && y < 1.1f)
			{
				__instance.onCamera = true;

				__result = true;
				return false;
			}

			if (GC.coopMode || GC.fourPlayerMode)
			{
				vector = GC.playerAgent2.agentCamera.originalCamera.WorldToViewportPoint(v);
				x = vector.x / T_VisionRange.GetZoomLevel(__instance);
				y = vector.y / T_VisionRange.GetZoomLevel(__instance);

				if (x > -0.1f && x < 1.1f &&
					y > -0.1f && y < 1.1f)
				{
					__instance.onCamera = true;

					__result = true;
					return false;
				}

				if (GC.fourPlayerMode)
				{
					vector = GC.playerAgent3.agentCamera.originalCamera.WorldToViewportPoint(v);
					x = vector.x / T_VisionRange.GetZoomLevel(__instance);
					y = vector.y / T_VisionRange.GetZoomLevel(__instance);

					if (x > -0.1f && x < 1.1f &&
						y > -0.1f && y < 1.1f)
					{
						__instance.onCamera = true;

						__result = true;
						return false;
					}
					if (!GC.sessionDataBig.threePlayer)
					{
						vector = GC.playerAgent4.agentCamera.originalCamera.WorldToViewportPoint(v);
						x = vector.x / T_VisionRange.GetZoomLevel(__instance);
						y = vector.y / T_VisionRange.GetZoomLevel(__instance);

						if (x > -0.1f && x < 1.1f &&
							y > -0.1f && y < 1.1f)
						{
							__instance.onCamera = true;

							__result = true;
							return false;
						}
					}
				}
			}

			__instance.onCamera = false;

			__result = false;
			return false;
		}

		/// <summary>
		/// View Distance Agent Activation
		/// </summary>
		/// <param name="__instance"></param>
		[HarmonyPostfix, HarmonyPatch(methodName: "Awake")]
		public static void Awake_Postfix(Agent __instance)
		{
			__instance.wasOnCamera = false;
		}
	}
}
