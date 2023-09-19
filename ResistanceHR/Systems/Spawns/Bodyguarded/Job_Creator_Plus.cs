using BepInEx.Logging;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Job_Creator_Plus : T_Bodyguarded
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal override int AgentCount => 2;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Slave };
		internal override bool AgentsArmed => true;

		// Figure out the base trait code first
		//[RLSetup]
		internal static void Setup()
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
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }

		internal override void ModifySpawnedAgent(Agent spawnedAgent)
		{
			Job_Creator.JobCreatorHelper(Owner, spawnedAgent);
		}
	}
}