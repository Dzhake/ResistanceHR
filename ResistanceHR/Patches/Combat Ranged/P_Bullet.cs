using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using ResistanceHR.Traits.Combat_Ranged;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType:typeof(Bullet))]
    public static class P_Bullet
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		/// <summary>
		/// Bullet Range
		/// </summary>
		/// <param name="__instance"></param>
		/// <param name="___bulletSpriteTr"></param>
		/// <returns></returns>
		[HarmonyTranspiler, HarmonyPatch(methodName: nameof(Bullet.LateUpdateBullet))]
		private static IEnumerable<CodeInstruction> LateUpdateBullet_SetRange(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo getBulletRange = AccessTools.DeclaredMethod(typeof(T_BulletModification), nameof(T_BulletModification.GetBulletRange));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 8,
				targetInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 13f)
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),					//	this
					new CodeInstruction(OpCodes.Call, getBulletRange)		//	float
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		/// <summary>
		/// Bullet Speed & Damage
		/// </summary>
		/// <param name="__instance"></param>
		[HarmonyPostfix, HarmonyPatch(methodName: nameof(Bullet.SetupBullet))]
		public static void SetupBullet_Postfix(Bullet __instance)
		{
			foreach (T_BulletModification trait in __instance.agent.GetTraits<T_BulletModification>())
			{
				__instance.speed = T_BulletModification.GetBulletSpeed(__instance);
				__instance.damage = T_BulletModification.GetBulletDamage(__instance);
			}
		}
	}
}