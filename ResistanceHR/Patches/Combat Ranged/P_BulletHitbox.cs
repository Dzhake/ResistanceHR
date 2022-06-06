using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using ResistanceHR.Traits.Combat_Ranged;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches.Combat_Ranged
{
    [HarmonyPatch(declaringType: typeof(BulletHitbox))]
    public static class P_BulletHitbox
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(methodName: nameof(BulletHitbox.HasLOSBullet), argumentTypes: new[] { typeof(PlayfieldObject) })]
		private static IEnumerable<CodeInstruction> HasLOSBullet_SetRange(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo getBulletRange = AccessTools.DeclaredMethod(typeof(T_BulletModification), nameof(T_BulletModification.GetBulletRange));
			FieldInfo myBullet = AccessTools.DeclaredField(typeof(BulletHitbox), nameof(BulletHitbox.myBullet));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				targetInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 13.44)
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),					//	this
					new CodeInstruction(OpCodes.Ldfld, myBullet),			//	Bullet
					new CodeInstruction(OpCodes.Call, getBulletRange)		//	float
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		// TODO
		/// <summary>
		/// Sniper + Shooting past Cover
		/// </summary>
		/// <param name="codeInstructions"></param>
		/// <returns></returns>
		//[HarmonyTranspiler, HarmonyPatch(methodName: nameof(BulletHitbox.HitObject), argumentTypes: new[] { typeof(GameObject), typeof(bool) })]
		private static IEnumerable<CodeInstruction> HitObject_ShootPastCover_1 (IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				targetInstructionSequence: new List<CodeInstruction>
				{
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static bool IsShootingFromCoverObject(Agent agent, ObjectReal objectReal) =>
			(agent.HasTrait<Sniper2>() &&
			!(agent.hiddenInObject is null) &&
			agent.hiddenInObject == objectReal);
	}
}
