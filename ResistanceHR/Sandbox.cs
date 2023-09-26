
using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR;
using System.Collections;
using System.Reflection;
using UnityEngine;

[HarmonyPatch(typeof(Relationships))]
static class DebugulationsUponYe
{
	private static readonly ManualLogSource logger = RHRLogger.GetLogger();
	private static GameController GC => GameController.gameController;

	[HarmonyPrefix, HarmonyPatch(typeof(Relationships), nameof(Relationships.SetRel), new[] { typeof(Agent), typeof(string), typeof(bool) })]
	private static bool SetRel(Relationships __instance, Agent otherAgent, string newRel, bool cameFromServer)
	{
		FieldInfo agentField = AccessTools.DeclaredField(typeof(Relationships), "agent");
		Agent agent = (Agent)agentField.GetValue(__instance);

		if (GC.serverPlayer || cameFromServer)
		{
			foreach (Relationship relationship in __instance.RelList)
			{
				if (relationship.agent.agentID == otherAgent.agentID)
				{
					try
					{
						if (newRel == "Hateful" && ((((agent.zombified && (!(agent.agentName == "Custom") || !agent.statusEffects.hasTrait("Zombify"))) || agent.agentName == "Zombie") && ((otherAgent.zombified && (!(otherAgent.agentName == "Custom") || !otherAgent.statusEffects.hasTrait("Zombify"))) || otherAgent.agentName == "Zombie") && !agent.justHitByAgent3) || otherAgent.mechEmpty || otherAgent.butlerBot))
						{
							break;
						}
					}
					catch
					{
					}

					agent.objectMult.SetRel(otherAgent, newRel);

					if (otherAgent.isPlayer > 0 && newRel == "Hateful" && relationship.relType != newRel && GC.loadComplete && !relationship.didHostile && !agent.dead)
					{
						GC.stats.AddToStat(otherAgent, "Hostiled", 1);
						relationship.didHostile = true;
					}

					if (otherAgent.isPlayer > 0 && (newRel == "Hateful" || newRel == "Annoyed") && (relationship.relType != newRel || relationship.initialRelType == newRel) && GC.loadComplete && !relationship.didAnger && !agent.enraged)
						__instance.AddToAngerStat(otherAgent, relationship);

					if (newRel == "Hateful" && relationship.relType != newRel)
					{
						GC.tileInfo.DirtyWalls();

						if (agent.isPlayer == 0)
							__instance.StartCoroutine(JustWentHostileLOS(__instance, agent, otherAgent, relationship));

						relationship.secretHate = false;
						relationship.mechHate = false;
					}

					if ((newRel == "Hateful" || newRel == "Annoyed") && agent.interactingAgent == otherAgent && !otherAgent.interactionHelper.interactingFar && !agent.hasGettingArrestedByAgent && !agent.hasGettingBitByAgent)
						agent.StopInteraction();

					relationship.SetRelType(newRel);

					if (!agent.oma.bodyGuarded)
						__instance.CancelJob(otherAgent, newRel);

					break;
				}
			}
		}

		return false;
	}

	private static IEnumerator JustWentHostileLOS(Relationships __instance, Agent agent, Agent otherAgent, Relationship rel)
	{
		if (!otherAgent.invisible)
		{
			bool flag = false;
			if (rel.hasLOS || rel.hasLOS360)
			{
				flag = true;
			}
			else if (agent.movement.HasLOSAgent360(otherAgent))
			{
				flag = true;
			}
			if (flag)
			{
				rel.justWentHostileLOS = true;
				rel.lastSawPosition = otherAgent.tr.position;
				yield return new WaitForSeconds(0.2f);
				rel.justWentHostileLOS = false;
			}
		}
		yield break;
	}

}