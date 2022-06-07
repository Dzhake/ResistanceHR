using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Localization;
using ResistanceHR.Traits.Experience;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(StatsScreen))]
    public static class P_StatsScreen
    {
        private static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        /// <summary>
        /// Very HardOn Yourself
        /// Additional XP Bonuses
        /// </summary>
        /// <param name="agentNum"></param>
        /// <param name="__instance"></param>
        /// <returns></returns>
        [HarmonyPrefix, HarmonyPatch(methodName: nameof(StatsScreen.DoStatsScreenUnlocks), argumentTypes: new[] { typeof(int) })]
        public static bool DoStatsScreenUnlocks_Prefix(int agentNum, StatsScreen __instance)
        {
            Agent agent = __instance.agent;
            bool vhoy = agent.HasTrait<Guilty_Conscience>();
            bool BQFloorComplete = GC.quests.CheckIfBigQuestCompleteFloor(agent);
            bool BQDistrictComplete = GC.quests.CheckIfBigQuestCompleteTheme(agent, false); // NEVER SET TO TRUE? ADDRESS THIS
            bool BQRunComplete = GC.quests.CheckIfBigQuestCompleteRun(agent, false);

            if (vhoy && GC.quests.CanHaveBigQuest(agent))
            {
                if (GC.quests.BigQuestBasedOnTotal(agent))
                {
                    if (!(BQFloorComplete && agent.health > 0f && 
                        (!(agent.bigQuest == "Firefighter") || agent.needArsonist > 1)))
                        agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestFloor);
                }
                else if (agent.oma.bigQuestObjectCountTotal != 0)
                {
                    if (!BQFloorComplete)
                        agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestFloor);
                }
                else if (!BQDistrictComplete)
                    agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestFloor);

                if (!BQDistrictComplete && agent.health > 0f)
                    agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestDistrict);

                if (!BQRunComplete)
                    agent.skillPoints.AddPoints(CustomExperienceAwards.FailedBigQuestGame);
            }

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
