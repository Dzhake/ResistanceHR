using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace ResistanceHR.Systems.Laws.Mutators
{
	public abstract class M_NewRegime : M_RHR
	{
		public M_NewRegime() : base() { }

		public abstract string EnforcerClass { get; }
	}

	[HarmonyPatch(typeof(LevelTransition))]
	internal static class P_LevelTransition_NewRegime
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(typeof(LevelTransition), nameof(LevelTransition.ChangeLevel))]
		private static void ApplyNewRegime()
		{
			if (RogueFramework.Unlocks.OfType<M_NewRegime>().Where(m => m.IsEnabled).Any())
				GC.loadLevel.replaceCopWithGangbanger = true;
		}
	}

	[HarmonyPatch(typeof(BasicAgent))]
	internal static class P_BasicAgent_NewRegime
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		//	For some reason it only applies to Supercops here. Just replace it further up in the method.
		[HarmonyTranspiler, HarmonyPatch(nameof(BasicAgent.Spawn), new[] { typeof(Agent) })]
		private static IEnumerable<CodeInstruction> ShowGuiltyText(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
				},
				targetInstructions: new List<CodeInstruction>
				{
				},
				insertInstructions: new List<CodeInstruction>
				{
				},
				postfixInstructions: new List<CodeInstruction>
				{
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}
}
