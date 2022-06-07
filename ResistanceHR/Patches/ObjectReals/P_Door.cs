using HarmonyLib;
using ResistanceHR.Localization;
using ResistanceHR.Traits.Experience;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Patches
{
    [HarmonyPatch(declaringType: typeof(Door))]
    public static class P_Door
    {
		[HarmonyPostfix, HarmonyPatch(methodName: "FreePrisonerPointsIfNotDead", argumentTypes: new[] { typeof(Agent), typeof(List<Agent>) })]
		public static void Door_FreePrisonerPointsIfNotDead(Agent myAgent, List<Agent> myFreedAgents) // Postfix
		{
			if (myAgent.HasTrait<Guilty_Conscience>())
			{
				for (int i = 0; i < myFreedAgents.Count; i++)
					if (!myFreedAgents[i].dead || myFreedAgents[i].teleporting)
						return;

				myAgent.skillPoints.AddPoints(CustomExperienceAwards.FreePrisonerFailure);
			}
		}
	}
}