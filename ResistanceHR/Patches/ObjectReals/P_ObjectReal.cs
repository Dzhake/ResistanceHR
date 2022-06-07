using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Traits.Vision_Range;
using UnityEngine;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(ObjectReal))]
    public static class P_ObjectReal
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		// TODO: Transpilerize
		/// <summary>
		/// View Distance Object Activation Range
		/// </summary>
		/// <param name="__instance"></param>
		/// <param name="__result"></param>
		/// <returns></returns>
		[HarmonyPrefix, HarmonyPatch(methodName: nameof(ObjectReal.ObjectRealOnCamera))]
		public static bool ObjectReal_ObjectRealOnCamera(ObjectReal __instance, ref bool __result)
		{
			// Eagle Eye activation range

			if (!__instance.activeObject || __instance.notRealObject)
			{
				__instance.onCamera = false;

				__result = false;
				return false;
			}

			if ((!GC.coopMode && !GC.fourPlayerMode) || GC.splitScreen)
			{
				float cameraWidth = 13f / T_VisionRange.GetZoomLevel(GC.playerAgent);
				float cameraHeight = 8f / T_VisionRange.GetZoomLevel(GC.playerAgent);
				Vector2 curPosition = GC.playerAgent.agentCamera.curPosition;

				if (curPosition.x > __instance.curPosition.x - cameraWidth &&
					curPosition.x < __instance.curPosition.x + cameraWidth &&
					curPosition.y > __instance.curPosition.y - cameraHeight &&
					curPosition.y < __instance.curPosition.y + cameraHeight)
				{
					__instance.onCamera = true;

					__result = true;
					return false;
				}

				if (GC.coopMode || GC.fourPlayerMode)
				{
					curPosition = GC.playerAgent2.agentCamera.curPosition;

					if (curPosition.x > __instance.curPosition.x - cameraWidth &&
						curPosition.x < __instance.curPosition.x + cameraWidth &&
						curPosition.y > __instance.curPosition.y - cameraHeight &&
						curPosition.y < __instance.curPosition.y + cameraHeight)
					{
						__instance.onCamera = true;

						__result = true;
						return false;
					}

					if (GC.fourPlayerMode)
					{
						curPosition = GC.playerAgent3.agentCamera.curPosition;

						if (curPosition.x > __instance.curPosition.x - cameraWidth &&
							curPosition.x < __instance.curPosition.x + cameraWidth &&
							curPosition.y > __instance.curPosition.y - cameraHeight &&
							curPosition.y < __instance.curPosition.y + cameraHeight)
						{
							__instance.onCamera = true;

							__result = true;
							return false;
						}

						if (!GC.sessionDataBig.threePlayer)
						{
							curPosition = GC.playerAgent4.agentCamera.curPosition;

							if (curPosition.x > __instance.curPosition.x - cameraWidth &&
								curPosition.x < __instance.curPosition.x + cameraWidth &&
								curPosition.y > __instance.curPosition.y - cameraHeight &&
								curPosition.y < __instance.curPosition.y + cameraHeight)
							{
								__instance.onCamera = true;

								__result = true;
								return false;
							}
						}
					}
				}
			}
			else
			{
				Vector2 vector = GC.playerAgent.agentCamera.originalCamera.WorldToViewportPoint(__instance.curPosition);

				if (vector.x > -0.1f &&
					vector.x < 1.1f &&
					vector.y > -0.1f &&
					vector.y < 1.1f)
				{
					__instance.onCamera = true;

					__result = true;
					return false;
				}

				if (GC.coopMode || GC.fourPlayerMode)
				{
					vector = GC.playerAgent2.agentCamera.originalCamera.WorldToViewportPoint(__instance.curPosition);
					if (vector.x > -0.1f &&
						vector.x < 1.1f &&
						vector.y > -0.1f &&
						vector.y < 1.1f)
					{
						__instance.onCamera = true;

						__result = true;
						return false;
					}

					if (GC.fourPlayerMode)
					{
						vector = GC.playerAgent3.agentCamera.originalCamera.WorldToViewportPoint(__instance.curPosition);
						if (vector.x > -0.1f &&
							vector.x < 1.1f &&
							vector.y > -0.1f &&
							vector.y < 1.1f)
						{
							__instance.onCamera = true;

							__result = true;
							return false;
						}

						if (!GC.sessionDataBig.threePlayer)
						{
							vector = GC.playerAgent4.agentCamera.originalCamera.WorldToViewportPoint(__instance.curPosition);
							if (vector.x > -0.1f &&
								vector.x < 1.1f &&
								vector.y > -0.1f &&
								vector.y < 1.1f)
							{
								__instance.onCamera = true;

								__result = true;
								return false;
							}
						}
					}
				}
			}

			__instance.onCamera = false;

			__result = false;
			return false;
		}
	}
}
