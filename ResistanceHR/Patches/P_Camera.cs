using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;
using System.Linq;
using UnityEngine;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(Camera))]
    public static class P_Camera
    {
        private static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        /// <summary>
        /// Vision Range activation
        /// </summary>
        /// <param name="position"></param> 
        /// <param name="__instance"></param>
        /// <param name="__result"></param>
        //[HarmonyPostfix, HarmonyPatch(methodName: nameof (Camera.WorldToViewportPoint), argumentTypes: new[] { typeof(Vector3) })] 
        public static void WorldToViewportPoint_Postfix(ref Vector3 __result)
        {
            if (GC.playerAgent.GetTraits<T_VisionRange>().Any())
            {
                T_VisionRange trait = GC.playerAgent.GetTrait<T_VisionRange>();

                __result.x *= trait.ZoomLevel * T_VisionRange.PlayerZoomFactor;
                __result.y *= trait.ZoomLevel * T_VisionRange.PlayerZoomFactor;
            }
        }
    }
}
