using BepInEx.Logging;
using BTHarmonyUtils;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using JetBrains.Annotations;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR
{
	public interface IRefreshAtLevelStart
	{
		void RefreshAtLevelStart(Agent agent);
		bool RefreshThisLevel(int level);
	}

	[HarmonyPatch(typeof(LoadLevel))]
	internal static class P_LoadLevel_SetupMore4_2
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyTargetMethod, UsedImplicitly]
		private static MethodInfo Find_MoveNext_MethodInfo() =>
			PatcherUtils.FindIEnumeratorMoveNext(AccessTools.Method(typeof(LoadLevel), "SetupMore4_2"));

		[HarmonyTranspiler, UsedImplicitly]
		private static IEnumerable<CodeInstruction> SetupMore4_2_GeneralLoadouts(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo refreshAgents = AccessTools.DeclaredMethod(typeof(P_LoadLevel_SetupMore4_2), nameof(P_LoadLevel_SetupMore4_2.RefreshAgents));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				prefixInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldstr, "SETUPMORE4_7"),
					new CodeInstruction(OpCodes.Call),
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, refreshAgents),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static void RefreshAgents()
		{
			foreach (Agent agent in GC.agentList)
				foreach (IRefreshAtLevelStart trait in agent.GetTraits<IRefreshAtLevelStart>())
					if (trait.RefreshThisLevel(GC.sessionDataBig.curLevelEndless))
						trait.RefreshAtLevelStart(agent);
		}
	}
}