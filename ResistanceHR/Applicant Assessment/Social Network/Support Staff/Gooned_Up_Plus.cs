using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Gooned_Up_Plus : T_Bodyguarded
	{
		public override int AgentCount => 1;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Supergoon };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Gooned_Up_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Supergoon joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Gooned_Up_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = true,
					UnlockCost = 15,
					Unlock =
					{
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