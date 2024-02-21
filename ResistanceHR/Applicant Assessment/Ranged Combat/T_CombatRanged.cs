using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RHR.Combat_Ranged
{
	// TODO: IModifyRangedAttack
	public abstract class T_CombatRanged : T_RHR
	{
		public T_CombatRanged() : base() { }
	}

	[HarmonyPatch(typeof(Bullet))]
	public static class P_Bullet_CombatRanged
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		private static void DebugDisShit()
		{
			// get the MethodBase of the original
			var original = typeof(Bullet).GetMethod(nameof(Bullet.LateUpdateBullet));

			// retrieve all patches
			var patches = Harmony.GetPatchInfo(original);
			if (patches is null) return; // not patched

			// get a summary of all different Harmony ids involved
			FileLog.Log("all owners: " + patches.Owners);

			// get info about all Prefixes/Postfixes/Transpilers
			foreach (var patch in patches.Prefixes)
			{
				FileLog.Log("index: " + patch.index);
				FileLog.Log("owner: " + patch.owner);
				FileLog.Log("patch method: " + patch.PatchMethod);
				FileLog.Log("priority: " + patch.priority);
				FileLog.Log("before: " + patch.before);
				FileLog.Log("after: " + patch.after);
			}

		}

		/// <summary>
		/// Bullet Range
		/// </summary>
		/// <param name="__instance"></param>
		/// <param name="___bulletSpriteTr"></param>
		/// <returns></returns>
		[HarmonyTranspiler, HarmonyPatch(nameof(Bullet.LateUpdateBullet))]
		private static IEnumerable<CodeInstruction> LateUpdateBullet_SetRange(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo getBulletRange = AccessTools.DeclaredMethod(typeof(T_BulletModification), nameof(T_BulletModification.GetBulletRange));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 8,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 13f)
				},
				insertInstructions: new List<CodeInstruction>
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
		[HarmonyPostfix, HarmonyPatch(nameof(Bullet.SetupBullet))]
		public static void SetupBullet_Postfix(Bullet __instance)
		{
			foreach (T_BulletModification trait in __instance.agent.GetTraits<T_BulletModification>())
			{
				__instance.speed = T_BulletModification.GetBulletSpeed(__instance);
				__instance.damage = T_BulletModification.GetBulletDamage(__instance);
			}
		}
	}

	[HarmonyPatch(typeof(BulletHitbox))]
	public static class P_BulletHitbox_CombatRanged
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(BulletHitbox.HasLOSBullet), new[] { typeof(PlayfieldObject) })]
		private static IEnumerable<CodeInstruction> HasLOSBullet_SetRange(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo getBulletRange = AccessTools.DeclaredMethod(typeof(T_BulletModification), nameof(T_BulletModification.GetBulletRange));
			FieldInfo myBullet = AccessTools.DeclaredField(typeof(BulletHitbox), nameof(BulletHitbox.myBullet));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 13.44f)
				},
				insertInstructions: new List<CodeInstruction>
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
		//[HarmonyTranspiler, HarmonyPatch(nameof(BulletHitbox.HitObject), new[] { typeof(GameObject), typeof(bool) })]
		private static IEnumerable<CodeInstruction> HitObject_ShootPastCover_1(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
				},
				insertInstructions: new List<CodeInstruction>
				{
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		public static bool IsShootingFromCoverObject(Agent agent, ObjectReal objectReal) =>
			(agent.HasTrait<Sniper_Plus>() &&
			!(agent.hiddenInObject is null) &&
			agent.hiddenInObject == objectReal);
	}

	[HarmonyPatch(typeof(PlayfieldObject))]
	internal static class P_PlayfieldObject_CombatRanged
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		// TODO: Diversify to Headshots with Normal/Head string args to DepleteArmor
		[HarmonyTranspiler, HarmonyPatch(nameof(PlayfieldObject.FindDamage), new[] { typeof(PlayfieldObject), typeof(bool), typeof(bool), typeof(bool) })]
		private static IEnumerable<CodeInstruction> ApplyPenetration_Ranged_Body(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_PlayfieldObject_CombatRanged), nameof(P_PlayfieldObject_CombatRanged.CustomMethod));
			MethodInfo depleteArmor = AccessTools.DeclaredMethod(typeof(InvDatabase), nameof(InvDatabase.DepleteArmor));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 4,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldstr, "Normal"),
					new CodeInstruction(OpCodes.Ldloc_S, 7),				//	num (Net damage)
				},
				targetInstructions: new List<CodeInstruction>
				{
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 6),				//	agent
					new CodeInstruction(OpCodes.Call, customMethod),
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldc_R4, 2),
					new CodeInstruction(OpCodes.Mul),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		private static float CustomMethod(float penetration, Agent shooter)
		{
			logger.LogDebug($"ApplyBulletPenetration ({shooter.agentRealName}): {penetration}");
			foreach (T_BulletModification trait in shooter.GetTraits<T_BulletModification>())
				penetration *= trait.BulletPenetrationMultiplier;

			logger.LogDebug($"Net Penetration: {penetration}");
			return penetration;
		}
	}
} 