using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public abstract class T_Spawns : T_RHR
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public T_Spawns() : base() { }

		public abstract List<string> AgentClasses { get; }
		public abstract int AgentCount { get; }
		public abstract bool AgentsArmed { get; }

		public abstract void ModifySpawnedAgent(Agent spawnedAgent);

		public static int CurrentDistrict => GC.levelTheme;
		public static int CurrentLevel => GC.sessionDataBig.curLevel;
		public static int OpenFollowerSlots(Agent employer)
		{
			int curFollowers = employer.FindNumFollowing(employer);
			int maxFollowers = 1
				+ (employer.HasTrait(VanillaTraits.TeamBuildingExpert) ? 2 : 0)
				+ (employer.HasTrait(VanillaTraits.ArmyofFive) ? 4 : 0)
				* (employer.HasTrait(VanillaTraits.Antisocial) ? 0 : 1);

			return Math.Max(maxFollowers - curFollowers, 0);
		}
	}

	[HarmonyPatch(typeof(LoadLevel))]
	public static class P_LoadLevel
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch("SetupMore3_3")]
		public static IEnumerator SetupMore3_3_Postfix(IEnumerator __result, LoadLevel __instance)
		{
			while (__result.MoveNext())
				yield return __result.Current;

			logger.LogDebug("T_Spawns.CurrentLevel: " + T_Spawns.CurrentLevel);

			if (GC.levelType != "HomeBase")
			{
				for (int agentSearch = 0; agentSearch < GC.agentList.Count; agentSearch++) // Test as a foreach. Might be intended to avoid modifying series.
				{
					Agent agent = GC.agentList[agentSearch];
					List<Agent> spawnedAgents;
					string agentClass;

					foreach (T_Bodyguarded trait in agent.GetTraits<T_Bodyguarded>())
					{
						int classRotator = 0;
						agentClass = trait.AgentClasses[classRotator++ % trait.AgentClasses.Count];
						spawnedAgents = T_Bodyguarded.SpawnBodyguards(agent, trait.AgentCount, agentClass);

						foreach (Agent spawnedAgent in spawnedAgents)
						{
							trait.ModifySpawnedAgent(spawnedAgent);

							if (trait.AgentsArmed)
							{
								agent.inventory.DontPlayPickupSounds(true);
								agent.inventory.AddRandWeapon();
								agent.inventory.DontPlayPickupSounds(false);
							}
						}
					}

					foreach (T_Roamers trait in agent.GetTraits<T_Roamers>())
					{
						int classRotator = 0;
						agentClass = trait.AgentClasses[classRotator++ % trait.AgentClasses.Count];
						spawnedAgents = T_Roamers.SpawnRoamerSquad(agent, trait.AgentCount, agentClass, trait.AgentRelationship, trait.GroupSize);

						foreach (Agent spawnedAgent in spawnedAgents)
						{
							trait.ModifySpawnedAgent(spawnedAgent);

							spawnedAgent.alwaysRun = trait.AgentsAlwaysRun;

							if (trait.AgentsArmed)
							{
								agent.inventory.DontPlayPickupSounds(true);
								agent.inventory.AddRandWeapon();
								agent.inventory.DontPlayPickupSounds(false);
							}
						}
					}
				}
			}
		}
	}
}