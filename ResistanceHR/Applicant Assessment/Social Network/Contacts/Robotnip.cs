using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Robotnip : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.KillerRobot };
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override int AgentCount => 3;
		public override bool AgentsAlwaysRun => true;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Robotnip>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Three adorable killer robots just wanna cuddle!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Robotnip)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
					Unlock =
					{
						cancellations = { nameof(Robait) },
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