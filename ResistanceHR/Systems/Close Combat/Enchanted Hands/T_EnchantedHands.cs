using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace ResistanceHR.Combat_Melee
{
	internal abstract class T_EnchantedHands : T_CombatMelee
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public T_EnchantedHands() : base() { }

		// TODO: Instance.GetStatusEffects().agent could skip getting hitter arg
		internal abstract bool CanHitGhost2(Agent striker, Agent target);
		internal abstract void OnStrike(Agent striker, Agent target);
		internal static bool CanHitGhost(Agent striker, Agent target) =>
			target is null
				? false
				: !target.ghost || striker.GetTraits<T_EnchantedHands>().Any(t => t.CanHitGhost2(striker, target));
	}

	[HarmonyPatch(typeof(MeleeHitbox))]
	internal class P_MeleeHitbox_EnchantedHands
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(MeleeHitbox.HitAftermath))]
		private static IEnumerable<CodeInstruction> AllowGhostHit_01(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo ghost = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.ghost));
			FieldInfo myMelee = AccessTools.DeclaredField(typeof(MeleeHitbox), nameof(MeleeHitbox.myMelee));
			FieldInfo agent = AccessTools.DeclaredField(typeof(Melee), nameof(Melee.agent));
			MethodInfo canHitGhost = AccessTools.DeclaredMethod(typeof(T_EnchantedHands), nameof(T_EnchantedHands.CanHitGhost));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_1),
					new CodeInstruction(OpCodes.Ldfld, ghost),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, myMelee),
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldloc_S, 8),
					new CodeInstruction(OpCodes.Call, canHitGhost),
					new CodeInstruction(OpCodes.Ldc_I4_1), // Bool-inverter
					new CodeInstruction(OpCodes.Xor),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		[HarmonyTranspiler, HarmonyPatch(nameof(MeleeHitbox.HitObject))]
		private static IEnumerable<CodeInstruction> AllowGhostHit_02(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo ghost = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.ghost));
			FieldInfo myMelee = AccessTools.DeclaredField(typeof(MeleeHitbox), nameof(MeleeHitbox.myMelee));
			FieldInfo agent = AccessTools.DeclaredField(typeof(Melee), nameof(Melee.agent));
			MethodInfo canHitGhost = AccessTools.DeclaredMethod(typeof(T_EnchantedHands), nameof(T_EnchantedHands.CanHitGhost));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 8),
					new CodeInstruction(OpCodes.Ldfld, ghost),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, myMelee),
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldloc_S, 8),
					new CodeInstruction(OpCodes.Call, canHitGhost),
					new CodeInstruction(OpCodes.Ldc_I4_1), // Bool-inverter
					new CodeInstruction(OpCodes.Xor),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		[HarmonyTranspiler, HarmonyPatch(nameof(MeleeHitbox.HitObject))]
		private static IEnumerable<CodeInstruction> AllowGhostHit_03(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo ghost = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.ghost));
			FieldInfo myMelee = AccessTools.DeclaredField(typeof(MeleeHitbox), nameof(MeleeHitbox.myMelee));
			FieldInfo agent = AccessTools.DeclaredField(typeof(Melee), nameof(Melee.agent));
			MethodInfo canHitGhost = AccessTools.DeclaredMethod(typeof(T_EnchantedHands), nameof(T_EnchantedHands.CanHitGhost));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 26),
					new CodeInstruction(OpCodes.Ldfld, ghost),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, myMelee),
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldloc_S, 8),
					new CodeInstruction(OpCodes.Call, canHitGhost),
					new CodeInstruction(OpCodes.Ldc_I4_1), // Bool-inverter
					new CodeInstruction(OpCodes.Xor),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}


		[HarmonyTranspiler, HarmonyPatch(nameof(MeleeHitbox.HitObject))]
		private static IEnumerable<CodeInstruction> CallApplyOnStrikeEffects(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo applyOnHitEffects = AccessTools.DeclaredMethod(typeof(P_MeleeHitbox_EnchantedHands), nameof(P_MeleeHitbox_EnchantedHands.ApplyOnStrikeEffects));
			FieldInfo myMelee = AccessTools.DeclaredField(typeof(MeleeHitbox), nameof(MeleeHitbox.myMelee));
			FieldInfo agent = AccessTools.DeclaredField(typeof(Melee), nameof(Melee.agent));
			FieldInfo zombified = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.zombified));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call) // Add
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldarg_1),
					new CodeInstruction(OpCodes.Call, applyOnHitEffects),
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, myMelee),
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldfld, zombified),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		// TODO: Transpiler
		private static void ApplyOnStrikeEffects(MeleeHitbox __instance, GameObject hitObject)
		{
			Agent striker = __instance.myMelee.agent;
			Agent target = hitObject.GetComponent<ObjectSprite>().agent;

			foreach (T_EnchantedHands trait in striker.GetTraits<T_EnchantedHands>())
				trait.OnStrike(striker, target);
		}

		[HarmonyTranspiler, HarmonyPatch(nameof(MeleeHitbox.MeleeHitEffect))]
		private static IEnumerable<CodeInstruction> AllowGhostHit_04(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo ghost = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.ghost));
			FieldInfo myMelee = AccessTools.DeclaredField(typeof(MeleeHitbox), nameof(MeleeHitbox.myMelee));
			FieldInfo agent = AccessTools.DeclaredField(typeof(Melee), nameof(Melee.agent));
			MethodInfo canHitGhost = AccessTools.DeclaredMethod(typeof(T_EnchantedHands), nameof(T_EnchantedHands.CanHitGhost));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_2),
					new CodeInstruction(OpCodes.Ldfld, ghost),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, myMelee),
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldloc_2),
					new CodeInstruction(OpCodes.Call, canHitGhost),
					new CodeInstruction(OpCodes.Ldc_I4_1), // Bool-inverter
					new CodeInstruction(OpCodes.Xor),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}
}