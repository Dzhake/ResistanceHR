using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using ResistanceHR.Traits.Experience;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches.Items
{
    [HarmonyPatch(declaringType: typeof(InvInterface))]
    public static class P_InvInterface
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		/// <summary>
		/// Very HardOn Yourself guilty text
		/// </summary>
		/// <param name="codeInstructions"></param>
		/// <returns></returns>
		[HarmonyTranspiler, HarmonyPatch(methodName: nameof(InvInterface.ShowCursorText), argumentTypes: new[] { typeof(string), typeof(string), typeof(PlayfieldObject), typeof(int) })]
		private static IEnumerable<CodeInstruction> ShowCursorText_AllowGuiltyText(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo mainGUI = AccessTools.DeclaredField(typeof(InvInterface), nameof(InvInterface.mainGUI));
			FieldInfo agent = AccessTools.DeclaredField(typeof(MainGUI), nameof(MainGUI.agent));
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

					new CodeInstruction(OpCodes.Call, canSeeGuiltyText),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static bool CanSeeGuiltyText(Agent agent) =>
			agent.enforcer || agent.HasTrait<Guilty_Conscience>();
	}
}
