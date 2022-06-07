using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using ResistanceHR.Patches.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(ObjectInfo))]
	public static class P_ObjectInfo
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		/// <summary>
		/// Very HardOn Yourself
		/// </summary>
		/// <param name="codeInstructions"></param>
		/// <returns></returns>
        [HarmonyTranspiler, HarmonyPatch(methodName: "LateUpdate", argumentTypes: new Type[0] )]
		private static IEnumerable<CodeInstruction> LateUpdate_ShowGuiltyText(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo enforcer = AccessTools.DeclaredField(typeof(Agent), "enforcer");
			MethodInfo canSeeGuiltyText = AccessTools.DeclaredMethod(typeof(P_InvInterface), nameof(P_InvInterface.CanSeeGuiltyText));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				targetInstructionSequence: new List<CodeInstruction>
				{
					//	agent.enforcer

					new CodeInstruction(OpCodes.Ldfld, enforcer)
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					//	CanSeeGuiltyText(agent)

					new CodeInstruction(OpCodes.Call, canSeeGuiltyText)
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}
}
