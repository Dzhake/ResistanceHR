using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using ResistanceHR.Traits.Combat_Melee;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(PlayfieldObject))]
    public static class P_PlayfieldObject
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		/// <summary>
		/// Ranged & Melee damage modifiers
		/// </summary>
		/// <param name="damagerObject"></param>
		/// <param name="generic"></param>
		/// <param name="testOnly"></param>
		/// <param name="fromClient"></param>
		/// <param name="__instance"></param>
		/// <param name="__result"></param>
		/// <returns></returns>
		//[HarmonyTranspiler, HarmonyPatch(methodName: nameof(PlayfieldObject.FindDamage), argumentTypes: new[] { typeof(PlayfieldObject), typeof(bool), typeof(bool), typeof(bool) })]
		private static IEnumerable<CodeInstruction> FindDamage_SetMeleeDamage(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				postfixInstructionSequence: new List<CodeInstruction>
				{
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static float SetDamageMelee(float vanillaValue, Agent damager, Agent damaged)
        {
			foreach(T_SpecialStrikes trait in damager.GetTraits<T_SpecialStrikes>())
				if (trait.CanHit(damaged))
					vanillaValue *= trait.DamageMultiplier;

			return vanillaValue;
		}
		public static bool IsSniperShot()
        {
			return true;
        }
		public static bool IsWetworkerShot()
        {
			return true;
        }
	}
}