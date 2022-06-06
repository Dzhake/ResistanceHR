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
    [HarmonyPatch(declaringType: typeof(InvDatabase))]
    public static class P_InvInterface
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

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
					//	if ((this.mainGUI.agent.enforcer ...
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, mainGUI),
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldfld, enforcer)
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					//	if ((CanSeeGuiltyText(this.mainGUI.agent)

					new CodeInstruction(OpCodes.Ldarg_0),					//	this
					new CodeInstruction(OpCodes.Ldfld, mainGUI),			//	this.mainGUI
					new CodeInstruction(OpCodes.Ldfld, agent),				//	this.mainGUI.agent
					new CodeInstruction(OpCodes.Call, canSeeGuiltyText),	//	bool
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static bool CanSeeGuiltyText(Agent agent) =>
			agent.enforcer || agent.HasTrait<Very_HardOn_Yourself>();
	}
}
