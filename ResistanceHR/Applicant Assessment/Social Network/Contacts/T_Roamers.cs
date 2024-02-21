using BepInEx.Logging;
using BunnyLibs;
using System.Collections.Generic;
using UnityEngine;

namespace RHR.Spawns
{
	public abstract class T_Roamers : T_Spawns
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public T_Roamers() : base() { }

		public abstract string AgentRelationship { get; }
		public abstract bool AgentsAlwaysRun { get; }
		public abstract int GroupSize { get; }

		// Copied from BunnyMod
		//public static void EquipReinforcement(Agent agent)
		//{
		//	InvItem item = new InvItem
		//	{ invItemName = gc.Choose(VItemName.Pistol, VItemName.Knife) };
		//	item.ItemSetup(false);
		//	item.invItemCount = item.rewardCount;

		//	agent.inventory.AddItemAtEmptySlot(item, true, false);
		//	agent.inventory.equippedWeapon = item;

		//	agent.inventory.startingHeadPiece = vArmorHead.HardHat;
		//}

		public static List<Agent> SpawnRoamerSquad(Agent playerAgent, int numberToSpawn, string agentType, string relationship, int splitIntoGroupSize)
		{
			logger.LogDebug("LoadLevel_SpawnRoamerSquad: " + numberToSpawn + " * " + agentType);

			List<Agent> spawnedAgents = new List<Agent>();
			//playerAgent.gangStalking = Agent.gangCount;

			for (int spawnCount = 0; spawnCount < numberToSpawn; spawnCount++)
			{
				if (spawnCount % splitIntoGroupSize == 0)
					Agent.gangCount++; // Splits spawn into groups

				Vector2 spawnLocation;
				int attempts = 0;

				do
				{
					spawnLocation = GC.tileInfo.FindRandLocationGeneral(0.32f);
					attempts++;
				}
				while (attempts < 300 && (Vector2.Distance(spawnLocation, GC.playerAgent.tr.position) < 16f));

				if (attempts == 300)
				{
					logger.LogError("Didn't find valid spawn location: " + agentType);
					continue;
				}

				Agent agent = GC.spawnerMain.SpawnAgent(spawnLocation, null, agentType);
				agent.movement.RotateToAngleTransform((float)Random.Range(0, 360));
				agent.gang = Agent.gangCount;
				agent.modLeashes = 0;
				agent.wontFlee = true;
				agent.agentActive = true;
				agent.oma.mustBeGuilty =
					relationship == nameof(relStatus.Hostile);
				spawnedAgents.Add(agent);

				// Align agents in group to each other
				if (spawnedAgents.Count > 1)
					for (int j = 0; j < spawnedAgents.Count; j++)
						if (spawnedAgents[j] != agent)
						{
							agent.relationships.SetRelInitial(spawnedAgents[j], nameof(relStatus.Aligned));
							spawnedAgents[j].relationships.SetRelInitial(agent, nameof(relStatus.Aligned));
						}

				agent.relationships.SetRel(playerAgent, relationship);
				playerAgent.relationships.SetRel(agent, relationship);

				switch (relationship.ToString())
				{
					case nameof(relStatus.Annoyed):
						agent.relationships.SetRelHate(playerAgent, 1);
						playerAgent.relationships.SetRelHate(agent, 1);

						break;
					case nameof(relStatus.Hostile):
						agent.relationships.SetRelHate(playerAgent, 5);
						playerAgent.relationships.SetRelHate(agent, 5);

						break;
				}

				agent.SetDefaultGoal(VAgentGoal.WanderFar);
			}

			return spawnedAgents;
		}
	}
}