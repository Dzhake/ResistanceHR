using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using ResistanceHR.Challenges.Quest_Count;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches.Questicles
{
    [HarmonyPatch(declaringType: typeof(LoadLevel))]
    public static class P_LoadLevel
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public static void SetQuestTriesTotal() =>
			GC.quests.questTriesTotal = RogueFramework.Unlocks.OfType<C_QuestCount>().Where(c => c.IsEnabled).FirstOrDefault().QuestCount;

		[HarmonyTranspiler, HarmonyPatch(methodName: "CreateInitialMap")]
		private static IEnumerable<CodeInstruction> CreateInitialMap_Transpiler_QuestCount(IEnumerable<CodeInstruction> instructionsEnumerable, ILGenerator generator)
		{
			List<CodeInstruction> instructions = instructionsEnumerable.ToList();

			FieldInfo loadLevel_squareMap = AccessTools.Field(typeof(LoadLevel), nameof(LoadLevel.squareMap));
			MethodInfo levelGenTools_SetQuestTriesTotal = AccessTools.Method(typeof(P_LoadLevel), nameof(SetQuestTriesTotal));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				postfixInstructionSequence: new List<CodeInstruction>
				{
					// Line 391

					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, loadLevel_squareMap),
					new CodeInstruction(OpCodes.Brfalse),
					new CodeInstruction(OpCodes.Ldarg_0),
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					// SetQuestTriesTotal();

					new CodeInstruction(OpCodes.Call, levelGenTools_SetQuestTriesTotal), // Clear
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}
}