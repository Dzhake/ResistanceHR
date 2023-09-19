﻿using BepInEx.Logging;
using System.Collections.Generic;
using UnityEngine;

namespace ResistanceHR.Spawns
{
	internal abstract class T_Bodyguarded : T_Spawns
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal T_Bodyguarded() : base() { }

		internal static List<Agent> SpawnBodyguards(Agent employer, int numberToSpawn, string agentType)
		{
			numberToSpawn = Mathf.Clamp(numberToSpawn, 0, OpenFollowerSlots(employer));

			logger.LogDebug("SpawnBodyguards: " + numberToSpawn + " * " + agentType);

			List<Agent> spawnedAgents = new List<Agent>();

			for (int i = 0; i < numberToSpawn; i++)
			{
				Agent agent = GC.spawnerMain.SpawnAgent(GC.tileInfo.FindLocationNearLocation(employer.tr.position, employer, 0.96f, 1.8f, true, false),
					employer, agentType, "", employer);
				spawnedAgents.Add(agent);

				//if (enslaveAgents)
				//	employer.agentInteractions.EnslaveAgent(agent);
				//else
				agent.agentInteractions.HireUnofficially(agent, employer);

				agent.canGoBetweenLevels = true;
			}

			return spawnedAgents;
		}
	}
}