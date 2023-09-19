using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal abstract class T_Reputation : T_RHR
	{
		internal abstract void ApplyOriginalRelationship(Agent otherAgent);
		internal abstract bool AgentIsRival(Agent otherAgent);
		//internal abstract int ApplicationOrder { get; }

		internal static void SetRelationshipTo(Agent agent, Agent otherAgent, string relationship, bool mutual)
		{
			Relationships relationships = agent.relationships;

			switch (relationship)
			{
				case "":
					break;
				case VRelationship.Aligned:
					relationships.SetRel(otherAgent, VRelationship.Aligned);
					relationships.SetRelInitial(otherAgent, VRelationship.Aligned);
					relationships.SetRelHate(otherAgent, 0);
					relationships.SetSecretHate(otherAgent, false);
					break;
				case VRelationship.Annoyed:
					relationships.SetRel(otherAgent, VRelationship.Annoyed);
					relationships.SetRelInitial(otherAgent, VRelationship.Annoyed);
					relationships.SetStrikes(otherAgent, 2);
					break;
				case VRelationship.Friendly:
					relationships.SetRel(otherAgent, VRelationship.Friendly);
					relationships.SetRelInitial(otherAgent, VRelationship.Friendly);
					relationships.SetSecretHate(otherAgent, false);
					break;
				case VRelationship.Hostile:
					relationships.SetRel(otherAgent, VRelationship.Hostile);
					relationships.SetRelInitial(otherAgent, VRelationship.Hostile);
					relationships.SetRelHate(otherAgent, 5);
					relationships.GetRelationship(otherAgent).mechHate = true;
					break;
				case VRelationship.Loyal:
					relationships.SetRel(otherAgent, VRelationship.Loyal);
					relationships.SetRelInitial(otherAgent, VRelationship.Loyal);
					relationships.SetSecretHate(otherAgent, false);
					relationships.SetRelHate(otherAgent, 0);
					break;
				case VRelationship.Neutral:
					relationships.SetRel(otherAgent, VRelationship.Neutral);
					relationships.SetRelHate(otherAgent, 0);
					relationships.SetRelInitial(otherAgent, VRelationship.Neutral);
					relationships.SetSecretHate(otherAgent, false);
					break;
				case VRelationship.Submissive:
					relationships.SetRel(otherAgent, VRelationship.Submissive);
					relationships.SetRelInitial(otherAgent, VRelationship.Submissive);
					relationships.SetSecretHate(otherAgent, false);
					mutual = false;
					break;
			}

			if (mutual)
				SetRelationshipTo(otherAgent, agent, relationship, false);
		}
	}

	[HarmonyPatch(typeof(Relationships))]
	internal static class P_Relationships_Reputation
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Relationships.SetupRelationshipOriginal))]
		private static void SetupRelationshipOriginal_Postfix(ref Agent otherAgent, ref Agent ___agent)
		{
			if (GC.levelType == "HomeBase")
				return;

			//Need a way to detect original relationship and occasionally bypass this

			foreach (T_Reputation trait in ___agent.GetTraits<T_Reputation>())
				trait.ApplyOriginalRelationship(otherAgent);
		}
	}

	[HarmonyPatch(typeof(StatusEffects))]
	internal static class P_StatusEffects_Reputation
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(StatusEffects.AgentIsRival))]
		private static void AgentIsRival_Postfix(Agent myAgent, StatusEffects __instance, ref bool __result)
		{
			Agent killedAgent = __instance.agent;

			foreach (T_Reputation trait in myAgent.GetTraits<T_Reputation>())
				if (trait.AgentIsRival(killedAgent))
					__result = true;
		}
	}
}