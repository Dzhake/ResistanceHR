using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Ethics
{
	internal class GuiltyText
	{
		internal static bool CanSeeGuiltyText(Agent agent) =>
			agent.enforcer || agent.HasTrait<Conscientious>() || agent.HasTrait<Malicious>();
	}

	[HarmonyPatch(typeof(InvInterface))]
	internal static class P_InvInterface_GuiltyText
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(InvInterface.ShowCursorText), new[] { typeof(string), typeof(string), typeof(PlayfieldObject), typeof(int) })]
		private static IEnumerable<CodeInstruction> ShowGuiltyText(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo mainGUI = AccessTools.DeclaredField(typeof(InvInterface), nameof(InvInterface.mainGUI));
			FieldInfo agent = AccessTools.DeclaredField(typeof(MainGUI), nameof(MainGUI.agent));
			FieldInfo enforcer = AccessTools.DeclaredField(typeof(Agent), "enforcer");
			MethodInfo canSeeGuiltyText = AccessTools.DeclaredMethod(typeof(GuiltyText), nameof(GuiltyText.CanSeeGuiltyText));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
						new CodeInstruction(OpCodes.Ldfld, enforcer)
				},
				insertInstructions: new List<CodeInstruction>
				{
						new CodeInstruction(OpCodes.Call, canSeeGuiltyText),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(ObjectInfo))]
	internal static class P_ObjectInfo_GuiltyText
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(methodName: "LateUpdate", argumentTypes: new Type[0])]
		private static IEnumerable<CodeInstruction> ShowGuiltyText(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo enforcer = AccessTools.DeclaredField(typeof(Agent), "enforcer");
			MethodInfo canSeeGuiltyText = AccessTools.DeclaredMethod(typeof(GuiltyText), nameof(GuiltyText.CanSeeGuiltyText));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, enforcer)
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, canSeeGuiltyText)
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(StatusEffects))]
	internal static class P_StatusEffects_GuiltyText
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		internal static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(methodName: nameof(StatusEffects.IsInnocent), argumentTypes: new[] { typeof(Agent) })]
		private static IEnumerable<CodeInstruction> ShowGuiltyText(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo agent = AccessTools.DeclaredField(typeof(StatusEffects), nameof(StatusEffects.agent));
			FieldInfo enforcer = AccessTools.DeclaredField(typeof(Agent), "enforcer");
			MethodInfo canSeeGuiltyText = AccessTools.DeclaredMethod(typeof(GuiltyText), nameof(GuiltyText.CanSeeGuiltyText));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 2,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, enforcer)
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, canSeeGuiltyText)
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(SkillPoints))]
	internal static class P_SkillPoints_GuiltyText
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		internal static GameController GC => GameController.gameController;

		[HarmonyPatch(typeof(Door))]
		public static class P_Door_ExperienceRate
		{
			[HarmonyPostfix, HarmonyPatch("FreePrisonerPointsIfNotDead", new[] { typeof(Agent), typeof(List<Agent>) })]
			public static void Door_FreePrisonerPointsIfNotDead(Agent myAgent, List<Agent> myFreedAgents)
			{
				if (myAgent.HasTrait<Conscientious>())
				{
					for (int i = 0; i < myFreedAgents.Count; i++)
						if (!myFreedAgents[i].dead || myFreedAgents[i].teleporting)
							return;

					myAgent.skillPoints.AddPoints(CustomExperienceAwards.FreePrisonerFailure);
				}
			}
		}
	}
}
