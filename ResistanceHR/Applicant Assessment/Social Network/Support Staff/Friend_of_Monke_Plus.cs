using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Friend_of_Monke_Plus : T_Bodyguarded
	{
		public override int AgentCount => 2;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Gorilla };
		public override bool AgentsArmed => false;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Friend_of_Monke_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Two Gorillas join you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Friend_of_Monke_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 16,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = false,
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
		

	}
}