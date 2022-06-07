using BepInEx.Logging;
using BTHarmonyUtils;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using JetBrains.Annotations;
using ResistanceHR.Localization;
using ResistanceHR.Traits.Experience;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(SkillPoints))]
    public static class P_SkillPoints_AddPointsLate
    {
        private static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        [HarmonyTargetMethod, UsedImplicitly]
        private static MethodInfo Find_MoveNext_MethodInfo() =>
            PatcherUtils.FindIEnumeratorMoveNext(AccessTools.Method(typeof(SkillPoints), nameof(SkillPoints.AddPointsLate), new[] { typeof(string), typeof(int) }));

        /// <summary>
        /// Very HardOn Yourself experience mali
        /// </summary>
        /// <param name="codeInstructions"></param>
        /// <returns></returns>
        [HarmonyTranspiler, UsedImplicitly]
        private static IEnumerable<CodeInstruction> AddPointsLate_ApplyXPMali(IEnumerable<CodeInstruction> codeInstructions)
        {
            List<CodeInstruction> instructions = codeInstructions.ToList();
            MethodInfo copMalusEligible = AccessTools.DeclaredMethod(typeof(P_SkillPoints_AddPointsLate), nameof(CopMalusEligible));

            CodeReplacementPatch patch = new CodeReplacementPatch(
                expectedMatches: 18,
                targetInstructionSequence: new List<CodeInstruction>
                {
                    //  this.agent.statusEffects.hasTrait("TheLaw")

                    new CodeInstruction(OpCodes.Ldfld),
                    new CodeInstruction(OpCodes.Ldstr, "TheLaw"),
                    new CodeInstruction(OpCodes.Callvirt),
                },
                insertInstructionSequence: new List<CodeInstruction>
                {
                    //  CopMalusEligible(this.agent)

                    new CodeInstruction(OpCodes.Call, copMalusEligible),

				});

            patch.ApplySafe(instructions, logger);
            return instructions;
        }

        public static bool CopMalusEligible(Agent agent) =>
            agent.HasTrait(VanillaTraits.TheLaw) || 
            agent.HasTrait<Guilty_Conscience>();

        /// <summary>
        /// Experience Rate
        /// </summary>
        /// <param name="codeInstructions"></param>
        /// <returns></returns>
        [HarmonyTranspiler, UsedImplicitly]
        private static IEnumerable<CodeInstruction> AddPointsLate_MultiplyExperience(IEnumerable<CodeInstruction> codeInstructions)
        {
            List<CodeInstruction> instructions = codeInstructions.ToList();
            FieldInfo agent = AccessTools.DeclaredField(typeof(SkillPoints), "agent");
            MethodInfo getNetExperience = AccessTools.DeclaredMethod(typeof(P_SkillPoints_AddPointsLate), nameof(GetNetExperience));

            CodeReplacementPatch patch = new CodeReplacementPatch(
                expectedMatches: 1,
                prefixInstructionSequence: new List<CodeInstruction>
                {
                    //  float num3 = 0.075f;
                    
                    new CodeInstruction(OpCodes.Ldc_R4, 0.075f),
                    new CodeInstruction(OpCodes.Stloc_S, 6),
                },
                insertInstructionSequence: new List<CodeInstruction>
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
        private static IEnumerable<CodeInstruction> DetectNewExperienceTypes(IEnumerable<CodeInstruction> codeInstructions)
        {
            List<CodeInstruction> instructions = codeInstructions.ToList();
            FieldInfo agent = AccessTools.DeclaredField(typeof(SkillPoints), "agent");
            MethodInfo getNewExperienceAward = AccessTools.DeclaredMethod(typeof(P_SkillPoints_AddPointsLate), nameof(GetNewExperienceAward));

            CodeReplacementPatch patch = new CodeReplacementPatch(
                expectedMatches: 1,
                prefixInstructionSequence: new List<CodeInstruction>
                {
                    //  string text = pointsType;

                    new CodeInstruction(OpCodes.Ldarg_0),
                    new CodeInstruction(OpCodes.Ldfld),
                    new CodeInstruction(OpCodes.Stloc_S, 4),
                    
                },
                insertInstructionSequence: new List<CodeInstruction>
                {
                    //  num = GetNewExperienceAward(text);

                    new CodeInstruction(OpCodes.Ldloc_S, 4),                    //  text
                    new CodeInstruction(OpCodes.Call, getNewExperienceAward),   //  int
                    new CodeInstruction(OpCodes.Stloc_2),                       //  num =
                });

            patch.ApplySafe(instructions, logger);
            return instructions;
        }

        private static int GetNetExperience(Agent agent, int vanilla)
        {
            float value = vanilla;

            if (agent.HasTrait<Guilty_Conscience>() && vanilla < 0)
                value *= 2f;
            else if (vanilla > 0)
                foreach (T_ExperienceRate trait in agent.GetTraits<T_ExperienceRate>())
                    value *= trait.ExperienceRate;

            return (int)value;
        }

        private static int GetNewExperienceAward(string text)
        {
            int amount = 0;

            if (CustomExperienceAwards.CustomXPValues.ContainsKey(text))
                amount = CustomExperienceAwards.CustomXPValues[text];

            // Also do VeryHardOnYourself negatives in here

            return amount;
        }
    }
}
