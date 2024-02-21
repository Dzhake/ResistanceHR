using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Backed_by_the_Blue_Plus : T_Bodyguarded
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.SuperCop };
		public override int AgentCount => 1;
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Backed_by_the_Blue_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Supercop joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Backed_by_the_Blue_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 20,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = true,
					Unlock =
					{
						cancellations = {
							nameof(Most_Wanted),
							VanillaTraits.Wanted,
						},
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