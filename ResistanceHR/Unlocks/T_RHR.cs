using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

public abstract class T_RHR : CustomTrait
{
	private static readonly ManualLogSource logger = BLLogger.GetLogger();
	private static GameController GC => GameController.gameController;

	//	IRefreshPerLevel
	public bool AlwaysApply => false;

	public static string DisplayName(Type type, string custom = null) =>
		(custom ?? (type.Name)
		.Replace("_Plus", " +")
		.Replace('_', ' '));

	public string TextName => DisplayName(GetType());

	public override void OnAdded() { }
	public override void OnRemoved() { }
}

namespace RHR
{
	[HarmonyPatch(typeof(ScrollingMenu))]
	public static class P_ScrollingMenu_Traits
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(ScrollingMenu.GetTraitsRemoveTrait)), Obsolete]
		private static IEnumerable<CodeInstruction> GetTraitsRemoveTrait_Transpiler(IEnumerable<CodeInstruction> instructionsEnumerable)
		{
			// Removed gate that prevents traits with less than -5 value being removed.

			FieldInfo unlock_cost3 = AccessTools.Field(typeof(Unlock), nameof(Unlock.cost3));
			FieldInfo scrollingMenu_gc = AccessTools.Field(typeof(ScrollingMenu), nameof(ScrollingMenu.gc));
			FieldInfo gameController_challenges = AccessTools.Field(typeof(GameController), nameof(GameController.challenges));

			CodeReplacementPatch patch = new CodeReplacementPatch(
					expectedMatches: 1,
					targetInstructionSequence: new List<CodeInstruction>
					{
							new CodeInstruction(OpCodes.Ldloc_3),
							new CodeInstruction(OpCodes.Ldfld, unlock_cost3),
							new CodeInstruction(OpCodes.Ldc_I4_S, -5),
							new CodeInstruction(OpCodes.Bgt_S),
							new CodeInstruction(OpCodes.Ldarg_0),
							new CodeInstruction(OpCodes.Ldfld, scrollingMenu_gc),
							new CodeInstruction(OpCodes.Ldfld, gameController_challenges),
							new CodeInstruction(OpCodes.Ldstr, VanillaMutators.NoLimits),
							new CodeInstruction(OpCodes.Callvirt),
							new CodeInstruction(OpCodes.Brfalse_S)
					});

			List<CodeInstruction> instructions = instructionsEnumerable.ToList();
			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}
}