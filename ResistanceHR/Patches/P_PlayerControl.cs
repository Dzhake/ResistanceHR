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
                T_VisionRange trait = GC.playerAgent.GetTrait<T_VisionRange>();

                GC.cameraScript.zoomLevel = trait.ZoomLevel * T_VisionRange.PlayerZoomFactor;
                __instance.myCamera.zoomLevel = trait.ZoomLevel * T_VisionRange.PlayerZoomFactor;
            }
        }
    }
}