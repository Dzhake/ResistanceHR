using BepInEx.Logging;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Job_Creator : T_Bodyguarded
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal override int AgentCount => 1;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Slave };
		internal override bool AgentsArmed => false;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Job_Creator>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Slave joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Job_Creator)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = { },
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.SlaveHelmetRemover },
						recommendations = { },
						upgrade = nameof(Job_Creator_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }

		internal override void ModifySpawnedAgent(Agent spawnedAgent)
		{
			// Didn't work: 
			//Owner.agentInteractions.GetSlave(spawnedAgent, Owner);
			//Owner.agentInteractions.EnslaveAgent(spawnedAgent);
			//Owner.EnslaveAnnoy(spawnedAgent, Owner, true);

			JobCreatorHelper(Owner, spawnedAgent);
		}

		internal static void JobCreatorHelper(Agent employer, Agent spawnedAgent)
		{
			logger.LogDebug("JobCreatorHelper:  " + spawnedAgent.agentRealName);

			spawnedAgent.inventory.DestroyItem(employer.inventory.FindItem(VanillaItems.SlaveHelmet));
			//Owner.agentInteractions.EnslaveAgent(spawnedAgent);
			employer.agentInteractions.GetSlave(spawnedAgent, employer);

			logger.LogDebug("Enslaved?              " + employer.slavesOwned.Count);

			InvItem remote = employer.inventory.FindItem(VanillaItems.SlaveHelmetRemote);

			logger.LogDebug("Remote Null?:         " + (remote is null).ToString());

			if (!(remote is null))
				remote.invItemCount++;
			else
			{
				logger.LogDebug("Making Remote");

				remote = new InvItem();
				remote.invItemName = VanillaItems.SlaveHelmetRemote;
				remote.invItemCount = 1;
				remote.SetupDetails(false);
				employer.inventory.AddItem(remote);
			}

			logger.LogDebug("Remote.InvItemCount:  " + remote.invItemCount);

			int ID = spawnedAgent.agentID;
			employer.agentInteractions.TieSlaveHelmetToRemote(spawnedAgent, employer, ID);
			remote.tiedToItemCode = ID;

			logger.LogDebug("Remote.tiedToItemCode:" + remote.tiedToItemCode);
		}
	}
}