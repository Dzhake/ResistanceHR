using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RHR.Conduct
{
	public class Pyrokinetic_Learning_Style : T_XPModifier
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Pyrokinetic_Learning_Style>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Enables XP penalties for destroying objects with fire.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Pyrokinetic_Learning_Style)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                    },
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});

			RogueLibs.CreateCustomName(WatchBurn, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "BUUURN!!!",
			});
		}

		public const string
			WatchBurn = "WatchBurn";

		

	}

	[HarmonyPatch(typeof(Fire))]
	public static class P_Fire_PyrokineticLearner
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(Fire.DestroyMe))]
		private static IEnumerable<CodeInstruction> AddFirebugXP(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_Fire_PyrokineticLearner), nameof(P_Fire_PyrokineticLearner.FirebugXP));
			FieldInfo objectAgent = AccessTools.DeclaredField(typeof(ObjectReal), nameof(ObjectReal.objectAgent));
			FieldInfo onFireServer = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.onFireServer));
			FieldInfo puttingOutFire = AccessTools.DeclaredField(typeof(Fire), nameof(Fire.puttingOutFire));
			MethodInfo setOnFire = AccessTools.Method(typeof(ObjectMultObject), "set_onFire");
			FieldInfo ora = AccessTools.DeclaredField(typeof(PlayfieldObject), nameof(PlayfieldObject.ora));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 5),
					new CodeInstruction(OpCodes.Ldfld, ora),
					new CodeInstruction(OpCodes.Ldc_I4_0),
					new CodeInstruction(OpCodes.Callvirt, setOnFire)
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 5),
					new CodeInstruction(OpCodes.Ldfld, objectAgent),
					new CodeInstruction(OpCodes.Call, customMethod),
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, puttingOutFire),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		private static void FirebugXP(Agent agent)
		{
			logger.LogDebug("FirebugXP");
			if (agent is null || !agent.HasTrait<Pyrokinetic_Learning_Style>())
				return;
			
			agent.skillPoints.AddPoints(Pyrokinetic_Learning_Style.WatchBurn);
		}
	}
}