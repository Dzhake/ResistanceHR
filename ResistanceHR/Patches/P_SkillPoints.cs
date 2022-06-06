using BepInEx.Logging;
using BTHarmonyUtils;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using JetBrains.Annotations;
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
    public static class P_SkillPoints
    {
        private static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        [HarmonyTargetMethod, UsedImplicitly]
        private static MethodInfo Find_MoveNext_MethodInfo() =>
            PatcherUtils.FindIEnumeratorMoveNext(AccessTools.Method(typeof(SkillPoints), nameof(SkillPoints.AddPointsLate), new Type[] { typeof(string), typeof(int) }));

        [HarmonyTranspiler, UsedImplicitly]
        private static IEnumerable<CodeInstruction> MultiplyByLearnRate(IEnumerable<CodeInstruction> codeInstructions)
        {
            List<CodeInstruction> instructions = codeInstructions.ToList();
            FieldInfo agent = AccessTools.DeclaredField(typeof(SkillPoints), "agent");
            MethodInfo getNetExperience = AccessTools.DeclaredMethod(typeof(P_SkillPoints), nameof(GetNetExperience));

            CodeReplacementPatch patch = new CodeReplacementPatch(
                expectedMatches: 1,
                prefixInstructionSequence: new List<CodeInstruction>
                {
                    //  float num3 = 0.075f;
                    
                    new CodeInstruction(OpCodes.Ldc_R4, 0.075),
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
            MethodInfo getNetExperience = AccessTools.DeclaredMethod(typeof(P_SkillPoints), nameof(GetNetExperience));

            CodeReplacementPatch patch = new CodeReplacementPatch(
                expectedMatches: 1,
                prefixInstructionSequence: new List<CodeInstruction>
                {
                },
                insertInstructionSequence: new List<CodeInstruction>
                {
				});

            patch.ApplySafe(instructions, logger);
            return instructions;
        }

        private static int GetNetExperience(Agent agent, int vanilla)
        {
            float value = vanilla;

            if (agent.HasTrait<Very_HardOn_Yourself>() && vanilla < 0)
                value *= 2f;
            else if (vanilla > 0)
                foreach (T_ExperienceRate trait in agent.GetTraits<T_ExperienceRate>())
                    value *= trait.ExperienceRate;

            return (int)value;
        }

        private static int GetNewExperienceAward(int amount, string text)
        {
            if (amount == 0)
            {
                if (CustomExperienceAwards.CustomXPValues.ContainsKey(text))
                    amount = CustomExperienceAwards.CustomXPValues[text];

                // Also do VeryHardOnYourself negatives in here
            }

            return amount;
        }
    }
}
