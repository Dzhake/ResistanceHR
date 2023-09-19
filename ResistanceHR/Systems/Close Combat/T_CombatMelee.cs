using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Combat_Melee
{
	public abstract class T_CombatMelee : T_RHR
	{
		public T_CombatMelee() : base() { }

		internal abstract bool BonusDamageEligible(Agent striker, Agent target);
		internal abstract float DamageMultiplier { get; }
	}

	[HarmonyPatch(typeof(PlayfieldObject))]
	internal static class P_PlayfieldObject_CombatMelee
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		// Warning: Original notes said this applied to ranged damage too. Verify.
		[HarmonyTranspiler, HarmonyPatch(methodName: nameof(PlayfieldObject.FindDamage), argumentTypes: new[] { typeof(PlayfieldObject), typeof(bool), typeof(bool), typeof(bool) })]
		internal static IEnumerable<CodeInstruction> ModifyMeleeDamage(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo setDamage = AccessTools.DeclaredMethod(typeof(P_PlayfieldObject_CombatMelee), nameof(P_PlayfieldObject_CombatMelee.NetDamageMelee));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldstr, "Melee"),
					new CodeInstruction(OpCodes.Stloc_S, 8),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 7),			// num (total damage)
					new CodeInstruction(OpCodes.Ldloc_S, 6),			// agent2 (damager)
					new CodeInstruction(OpCodes.Ldloc_0),				// agent (damaged)
					new CodeInstruction(OpCodes.Call, setDamage),
					new CodeInstruction(OpCodes.Stloc, 7),				// num
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		internal static float NetDamageMelee(float vanillaValue, Agent damager, Agent damaged)
		{
			if (damager is null || damaged is null)
				return vanillaValue;

			foreach (T_CombatMelee trait in damager.GetTraits<T_CombatMelee>())
				if (trait.BonusDamageEligible(damager, damaged))
					vanillaValue *= trait.DamageMultiplier;

			return vanillaValue;
		}
	}
}