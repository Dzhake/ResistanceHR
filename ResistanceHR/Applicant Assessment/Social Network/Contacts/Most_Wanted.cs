using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Most_Wanted : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.SuperCop, VanillaAgents.Cop, VanillaAgents.Cop };
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override int AgentCount => (CurrentDistrict) * 2;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 4;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Most_Wanted>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The police have set up special task forces to take you down.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Most_Wanted)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Backed_by_the_Blue),
						nameof(Backed_by_the_Blue_Plus)
					},
					CharacterCreationCost = -12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						categories = {  },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}