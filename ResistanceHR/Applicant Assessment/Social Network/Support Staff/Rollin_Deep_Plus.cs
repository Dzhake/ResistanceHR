using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Rollin_Deep_Plus : T_Bodyguarded
	{
		public override int AgentCount => 2;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterCrepe };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Rollin_Deep_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Two Crepes join you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Rollin_Deep_Plus), "Rollin' Deep +"),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = true,
					Unlock =
					{
						cancellations = { },
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Social },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}