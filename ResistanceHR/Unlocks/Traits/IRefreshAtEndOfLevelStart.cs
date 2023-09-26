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
	public interface IRefreshAtEndOfLevelStart
	{
		void RefreshAtLevelStart();
		void RefreshAtLevelStart(Agent agent);
		bool RefreshThisLevel(int level);
	}

	[HarmonyPatch(typeof(LoadLevel))]
	internal static class P_LoadLevel_IRefreshAtEndOfLevelStart
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
			MethodInfo refreshAgents = AccessTools.DeclaredMethod(typeof(P_LoadLevel_IRefreshAtEndOfLevelStart), nameof(P_LoadLevel_IRefreshAtEndOfLevelStart.Refresh));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldstr, "SETUPMORE4_7"),
					new CodeInstruction(OpCodes.Call),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, refreshAgents),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static void Refresh()
		{
			foreach (Agent agent in GC.agentList)
			{
				foreach (IRefreshAtEndOfLevelStart trait in agent.GetTraits<IRefreshAtEndOfLevelStart>())
					if (trait.RefreshThisLevel(GC.sessionDataBig.curLevelEndless))
						trait.RefreshAtLevelStart(agent);

				foreach (IRefreshAtEndOfLevelStart disaster in RogueFramework.CustomDisasters.Where(cd => cd.IsActive).OfType<IRefreshAtEndOfLevelStart>())
					if (disaster.RefreshThisLevel(GC.sessionDataBig.curLevelEndless))
						disaster.RefreshAtLevelStart();
			}
		}
	}
}