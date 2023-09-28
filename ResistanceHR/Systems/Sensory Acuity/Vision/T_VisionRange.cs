using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace ResistanceHR.Vision_Range
{
	internal abstract class T_VisionRange : T_RHR
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal T_VisionRange() : base() { }

		internal abstract float ZoomLevel { get; }
		internal static float PlayerZoomFactor =>
			GC.splitScreen ? 0.8f :
			GC.fourPlayerMode ? 0.6f :
			1.00f;

		internal static float GetZoomLevel(Agent agent)
		{
			float zoom = PlayerZoomFactor;

			foreach (T_VisionRange trait in agent.GetTraits<T_VisionRange>())
				zoom *= trait.ZoomLevel;

			return zoom;
		}
		internal static float ScaleToZoom(float vanilla, Agent agent) =>
			vanilla / GetZoomLevel(agent);
		internal static Vector3 ScaleToZoom(Vector3 vanilla, Agent agent)
		{
			vanilla.x /= GetZoomLevel(agent);
			vanilla.y /= GetZoomLevel(agent);
			return vanilla;
		}
	}

	[HarmonyPatch(typeof(Agent))]
	internal static class P_Agent_VisionRange
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		// The issue appears to be:
		//	Updater.UpdateAgents ~115 is where anim is set active.
		//		One of these is flipped:
		//			wasOnCamera
		//			onCamera		- Seems to be set true no matter what?
		//			onCameraOnce	- 


		// Ultimately I think Agent.AgentOnCamera is missing some camera expansion. That one might not be firing because brain isn't active yet.
		// BrainUpdate.DoObjectChecks - This might be what the NPC uses to check if a player is nearby.
		// The number of... numbers makes me think this is right.

		// This is what triggers when they come onscreen. But it's not the target - AgentOnCamera needs to be patched to make this one work right.
		//[HarmonyPrefix, HarmonyPatch(nameof(Agent.OnCameraFirstTime))] 
		internal static bool test1(Agent __instance)
		{
			logger.LogDebug("=== OnCameraFirstTime: " + __instance.agentRealName);
			logger.LogDebug($"\tCamera shit:\n\twasOnCamera\t{__instance.wasOnCamera}\n\tonCamera\t{__instance.onCamera}\n\tonCameraOnce\t{__instance.onCameraOnce}"); // All true

			return true;
		}
	}

	//[HarmonyPatch(typeof(BrainUpdate))]
	public static class P_BrainUpdate_VisionRange
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		static MethodInfo scaleFloatToZoom = AccessTools.DeclaredMethod(typeof(T_VisionRange), nameof(T_VisionRange.ScaleToZoom), new System.Type[] { typeof(float), typeof(Agent) });
		static FieldInfo gc = AccessTools.DeclaredField(typeof(BrainUpdate), nameof(BrainUpdate.gc));
		static FieldInfo playerAgent = AccessTools.DeclaredField(typeof(GameController), "playerAgent");

		// This one was unsuccessful. No observed difference. :(
		// This one causes SetRel errors.
		//[HarmonyTranspiler, HarmonyPatch(nameof(BrainUpdate.DoObjectChecks))]
		private static IEnumerable<CodeInstruction> ExpandActivationRange_16(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 14,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4),	// Catches 13.44f, 16f and 18f
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, gc),
					new CodeInstruction(OpCodes.Ldfld, playerAgent),
					new CodeInstruction(OpCodes.Call, scaleFloatToZoom),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

	}

	[HarmonyPatch(typeof(Camera))]
	public static class P_Camera_VisionRange
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Camera.WorldToViewportPoint), new[] { typeof(Vector3) })]
		public static void ExpandViewport(ref Vector3 __result)
		{
			__result.x *= T_VisionRange.GetZoomLevel(GC.playerAgent);
			__result.y *= T_VisionRange.GetZoomLevel(GC.playerAgent);
		}
	}

	[HarmonyPatch(typeof(ObjectReal))]
	internal static class P_ObjectReal_VisionRange
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		static MethodInfo scaleFloatToZoom = AccessTools.DeclaredMethod(typeof(T_VisionRange), nameof(T_VisionRange.ScaleToZoom), new System.Type[] { typeof(float), typeof(Agent) });
		static FieldInfo gc = AccessTools.DeclaredField(typeof(PlayfieldObject), nameof(PlayfieldObject.gc));
		static FieldInfo playerAgent = AccessTools.DeclaredField(typeof(GameController), "playerAgent");

		[HarmonyTranspiler, HarmonyPatch(nameof(ObjectReal.ObjectRealOnCamera))]
		private static IEnumerable<CodeInstruction> ExpandObjectRealActivationX(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 13),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, gc),
					new CodeInstruction(OpCodes.Ldfld, playerAgent),
					new CodeInstruction(OpCodes.Call, scaleFloatToZoom),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		[HarmonyTranspiler, HarmonyPatch(nameof(ObjectReal.ObjectRealOnCamera))]
		private static IEnumerable<CodeInstruction> ExpandObjectRealActivationY(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 8),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, gc),
					new CodeInstruction(OpCodes.Ldfld, playerAgent),
					new CodeInstruction(OpCodes.Call, scaleFloatToZoom),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(PlayerControl))]
	public static class P_PlayerControl_VisionRange
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch("Update")]
		public static void SetPlayerZoomLevel(PlayerControl __instance)
		{
			GC.cameraScript.zoomLevel = T_VisionRange.GetZoomLevel(GC.playerAgent);
			__instance.myCamera.zoomLevel = T_VisionRange.GetZoomLevel(GC.playerAgent);
		}
	}
}
