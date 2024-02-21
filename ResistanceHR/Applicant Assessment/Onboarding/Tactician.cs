using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Systems.Social_Network
{
	internal class Tactician : T_RHR
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public Tactician() : base() { }

		public static List<Agent> squadAgents(Agent hirer, Agent leader) => 
			GC.agentList.Where(a =>
				a != hirer && a != leader
				&& a.prisoner == 0 && a.ownerID == 0 && a.isPlayer == 0
				&& !a.oma.shookDown && !a.dead && !a.hasEmployer
				&& (hirer.relationships.GetRel(a) == VRelationship.Aligned || hirer.relationships.GetRel(a) == VRelationship.Loyal)
				&& (a.agentName == leader.agentName || a.agentRealName == leader.agentRealName)
				&& (a.initialStartingChunk == leader.initialStartingChunk && a.ownerID == leader.ownerID)
				&& a.health >= a.healthMax / 2.6f
			).ToList();

		//[RLSetup] 
		// Note: Patches disabled too
		public static void Setup()
		{
			// TODO: MoneySuccess Gate & actual charge

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				Agent gangLeader = h.Object;
				Agent hirer = h.Agent;
				List<Interaction> hireButtons = h.Model.Interactions.Where(i => i.ButtonName == VButtonText.Hire_Expert || i.ButtonName == VButtonText.Hire_Muscle).ToList();

				if (gangLeader.relationships.GetRel(hirer) == VRelationship.Annoyed
					|| !(gangLeader.employer is null)
					|| hireButtons is null 
					|| hireButtons.Count == 0)
					return;

				List<Agent> gangFollowers = squadAgents(hirer, gangLeader);

				logger.LogDebug($"Squad Followers:");
				foreach (Agent agent in gangFollowers)
					logger.LogDebug($"- {agent.agentRealName}");

				if (gangFollowers.Count > 0)
				{
					int baseCost = (int)hireButtons.First().ButtonPrice;
					float discount = gangFollowers.Count * 0.05f;
					int netcost = (int)(baseCost * gangFollowers.Count * (1.0f - discount));

					h.AddButton($"Hire Squad ({(gangFollowers.Count + 1)})x", netcost, m =>
					{
						m.Object.agentInteractions.PressedButton(m.Object, hirer, "Hired_Squad", netcost);
					});
				}
			});

			RogueLibs.CreateCustomTrait<Tactician>()
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "You can hire whole squads at a time, with a bulk discount. Each squad only takes up one follower slot.",
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Tactician)),
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
					cancellations = {

					},
					categories = {
						CTraitCategory.Leadership,
						VTraitCategory.Social,
					},
					cantLose = true,
					cantSwap = false,
					isUpgrade = false,
					prerequisites = {  },
					recommendations = { },
					upgrade = null, // nameof(Tactician_2),
				}
			});
		}
	}

	//[HarmonyPatch(typeof(AgentInteractions))]
	internal static class P_AgentInteractions_Tactician
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(AgentInteractions), nameof(AgentInteractions.PressedButton))]
		internal static bool HireSquad(Agent agent, Agent interactingAgent, string buttonText, int buttonPrice)
		{
			if (buttonText != "Hired_Squad")
				return true;

			List<Agent> followers = Tactician.squadAgents(interactingAgent, agent);
			interactingAgent.agentInteractions.HireAsProtection(interactingAgent, agent);
			AssembleSquad(interactingAgent, agent, followers);
			return false;
		}

		public static void AssembleSquad(Agent hirer, Agent leader, List<Agent> followers)
		{
			Agent.gangCount++;
			leader.gang = Agent.gangCount;
			string hirerRelationship = leader.relationships.GetRel(hirer);

			foreach (Agent follower in followers)
			{
				follower.modLeashes = 0;
				follower.SetDefaultGoal(VAgentGoal.WanderFar);
				follower.gang = Agent.gangCount;
				follower.modVigilant = 0;
				follower.modLeashes = 1;
				follower.specialWalkSpeed = leader.speedMax;
				//agent10.oma.mustBeGuilty = true; // ENTRAPMENT?

				for (int i = 0; i < GC.agentList.Count; i++)
				{
					Agent agent = GC.agentList[i];
					if (agent.gang == follower.gang)
					{
						follower.relationships.SetRelInitial(agent, VRelationship.Aligned);
						follower.relationships.SetRelInitial(hirer, hirerRelationship);
						agent.relationships.SetRelInitial(follower, VRelationship.Aligned);

						if (!agent.gangMembers.Contains(follower))
							agent.gangMembers.Add(follower);

						if (!follower.gangMembers.Contains(agent))
							follower.gangMembers.Add(agent);
					}
				}
			}
		}
	}
} 