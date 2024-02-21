using BepInEx.Logging;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Job_Creator_Plus : T_Bodyguarded
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public override int AgentCount => 2;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Slave };
		public override bool AgentsArmed => true;

		// Figure out the base trait code first
		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Job_Creator_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Two Slaves join you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Job_Creator_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 25,
					Unlock =
					{
						cancellations = { },
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		


		public override void ModifySpawnedAgent(Agent spawnedAgent)
		{
			Job_Creator.JobCreatorHelper(Owner, spawnedAgent);
		}
	}
}