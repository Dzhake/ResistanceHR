using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;
using System.Linq;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(PlayerControl))]
    public static class P_PlayerControl
    {
        private static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        /// <summary>
        /// Vision Range
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix, HarmonyPatch(methodName: "Update")]
        public static void PlayerControl_Update(PlayerControl __instance)
        {
            if (GC.playerAgent.GetTraits<T_VisionRange>().Any())
            {
                GC.cameraScript.zoomLevel = T_VisionRange.GetZoomLevel(GC.playerAgent);
                __instance.myCamera.zoomLevel = T_VisionRange.GetZoomLevel(GC.playerAgent);
            }
        }
    }
}