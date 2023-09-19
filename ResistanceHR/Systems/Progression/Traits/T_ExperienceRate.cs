using BepInEx.Logging;
using BTHarmonyUtils;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using JetBrains.Annotations;
using ResistanceHR.Conduct;
using ResistanceHR.Ethics;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Progression
{
	internal abstract class T_ExperienceRate : T_RHR
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal T_ExperienceRate() : base() { }

		internal abstract float ExperienceRate { get; }

		internal static bool CopMalusEligible(Agent agent) =>
			agent.HasTrait(VanillaTraits.TheLaw)
				|| agent.HasTrait<Conscientious>()
				|| GC.challenges.Contains(nameof(Conscience_Configurator));

		internal static int GetNetExperience(Agent agent, int vanilla)
		{
			float value = vanilla;

			if (vanilla > 0)
				foreach (T_ExperienceRate trait in agent.GetTraits<T_ExperienceRate>())
					value *= trait.ExperienceRate;

			return (int)value;
		}

		internal static int GetNewExperienceAward(string text)
		{
			int amount = 0;

			if (CustomExperienceAwards.CustomXPValues.ContainsKey(text))
				amount = CustomExperienceAwards.CustomXPValues[text];

			return amount;
		}
	}

	[HarmonyPatch(typeof(InvDatabase))]
	internal static class P_InvDatabase_Experience
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(InvDatabase.stoleFromInnocent))]
		private static IEnumerable<CodeInstruction> StealingMalus(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo agent = AccessTools.DeclaredField(typeof(InvDatabase), nameof(InvDatabase.agent));
			MethodInfo hasTrait = AccessTools.DeclaredMethod(typeof(StatusEffects), nameof(StatusEffects.hasTrait));
			MethodInfo copMalusEligible = AccessTools.DeclaredMethod(typeof(T_ExperienceRate), nameof(T_ExperienceRate.CopMalusEligible));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldfld),
					new CodeInstruction(OpCodes.Ldstr, VanillaTraits.TheLaw),
					new CodeInstruction(OpCodes.Callvirt, hasTrait),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Call, copMalusEligible),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(InvItem))]
	internal static class P_InvItem_Experience
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(InvItem.StealFromInnocent))]
		private static IEnumerable<CodeInstruction> StealingMalus(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo agent = AccessTools.DeclaredField(typeof(InvItem), nameof(InvItem.agent));
			MethodInfo copMalusEligible = AccessTools.DeclaredMethod(typeof(T_ExperienceRate), nameof(T_ExperienceRate.CopMalusEligible));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Ldfld),
					new CodeInstruction(OpCodes.Ldstr, VanillaTraits.TheLaw),
					new CodeInstruction(OpCodes.Callvirt),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, agent),
					new CodeInstruction(OpCodes.Call, copMalusEligible),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(SkillPoints))]
	internal static class P_SkillPoints_AddPointsLate_ExperienceRate
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTargetMethod, UsedImplicitly]
		internal static MethodInfo Find_MoveNext_MethodInfo() =>
			PatcherUtils.FindIEnumeratorMoveNext(AccessTools.Method(typeof(SkillPoints), nameof(SkillPoints.AddPointsLate), new[] { typeof(string), typeof(int) }));

		[HarmonyTranspiler, UsedImplicitly]
		internal static IEnumerable<CodeInstruction> AddPointsLate_ApplyXPMali(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo copMalusEligible = AccessTools.DeclaredMethod(typeof(T_ExperienceRate), nameof(T_ExperienceRate.CopMalusEligible));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 18,
				targetInstructions: new List<CodeInstruction>
				{
                    //  this.agent.statusEffects.hasTrait("TheLaw")

                    new CodeInstruction(OpCodes.Ldfld),
					new CodeInstruction(OpCodes.Ldstr, "TheLaw"),
					new CodeInstruction(OpCodes.Callvirt),
				},
				insertInstructions: new List<CodeInstruction>
				{
                    //  CopMalusEligible(this.agent)

                    new CodeInstruction(OpCodes.Call, copMalusEligible),

				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		[HarmonyTranspiler, UsedImplicitly]
		internal static IEnumerable<CodeInstruction> MultiplyExperience(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo agent = AccessTools.DeclaredField(typeof(SkillPoints), "agent");
			MethodInfo getNetExperience = AccessTools.DeclaredMethod(typeof(T_ExperienceRate), nameof(T_ExperienceRate.GetNetExperience));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
                    //  float num3 = 0.075f;
                    
                    new CodeInstruction(OpCodes.Ldc_R4, 0.075f),
					new CodeInstruction(OpCodes.Stloc_S, 6),
				},
				insertInstructions: new List<CodeInstruction>
				{
                    //  num = GetNetExperience(this.agent, num);
                                                                            
                    new CodeInstruction(OpCodes.Ldloc_1),                   //  this
                    new CodeInstruction(OpCodes.Ldfld, agent),              //  this.agent
                    new CodeInstruction(OpCodes.Ldloc_2),                   //  this.agent, int num
                    new CodeInstruction(OpCodes.Call, getNetExperience),    //  int
                    new CodeInstruction(OpCodes.Stloc_2)                    //  clear
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		[HarmonyTranspiler, UsedImplicitly]
		internal static IEnumerable<CodeInstruction> DetectNewExperienceTypes(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo agent = AccessTools.DeclaredField(typeof(SkillPoints), "agent");
			MethodInfo getNewExperienceAward = AccessTools.DeclaredMethod(typeof(T_ExperienceRate), nameof(T_ExperienceRate.GetNewExperienceAward));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
                    //  string text = pointsType;

                    new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld),
					new CodeInstruction(OpCodes.Stloc_S, 4),

				},
				insertInstructions: new List<CodeInstruction>
				{
                    //  num = GetNewExperienceAward(text);

                    new CodeInstruction(OpCodes.Ldloc_S, 4),                    //  text
                    new CodeInstruction(OpCodes.Call, getNewExperienceAward),   //  int
                    new CodeInstruction(OpCodes.Stloc_2),                       //  num =
                });

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
	}

	[HarmonyPatch(typeof(StatsScreen))]
	public static class P_StatsScreen_ExperienceRate
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(StatsScreen.DoStatsScreenUnlocks), argumentTypes: new[] { typeof(int) })]
		public static bool EndOfFloorSummary(int agentNum, StatsScreen __instance)
		{
			logger.LogDebug("EndOfFloorSummary");
			Agent agent = __instance.agent;

			bool BQFloorComplete = GC.quests.CheckIfBigQuestCompleteFloor(agent);
			logger.LogDebug($"BQFloorComplete:    {BQFloorComplete}");
			bool BQDistrictComplete = GC.quests.CheckIfBigQuestCompleteTheme(agent, false);
			logger.LogDebug($"BQDistrictComplete: {BQDistrictComplete}");
			bool BQRunComplete = GC.quests.CheckIfBigQuestCompleteRun(agent, false);
			logger.LogDebug($"BQRunComplete:      {BQRunComplete}");

			// This fits more of a "Perfectionist" trait
			//if (agent.HasTrait<Guilty_Conscience>() && GC.quests.CanHaveBigQuest(agent))
			//{
			//    if (GC.quests.BigQuestBasedOnTotal(agent))
			//    {
			//        if (!(BQFloorComplete && agent.health > 0f &&
			//            (!(agent.bigQuest == "Firefighter") || agent.needArsonist > 1)))
			//            agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestFloor);
			//    }
			//    else if (agent.oma.bigQuestObjectCountTotal != 0)
			//    {
			//        if (!BQFloorComplete)
			//            agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestFloor);
			//    }
			//    else if (!BQDistrictComplete)
			//        agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestFloor);

			//    if (!BQDistrictComplete && agent.health > 0f)
			//        agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestDistrict);

			//    if (!BQRunComplete)
			//        agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestGame);
			//}

			if (agent.health > 0f)
			{
				if (GC.stats.angered[agentNum] >= (GC.agentCount / 4))
					agent.skillPoints.AddPoints(CustomExperienceAwards.AngeredMany);

				if (GC.stats.stoleItems[agentNum] == 0)
					agent.skillPoints.AddPoints(CustomExperienceAwards.StoleNone);

				if (GC.stats.damageTaken[agentNum] >= 200)
					agent.skillPoints.AddPoints(CustomExperienceAwards.TookLotsOfDamage);
			}

			return true;
		}
	}
}