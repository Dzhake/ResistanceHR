using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Robait : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.KillerRobot };
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override int AgentCount => 1;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Robait>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Killer Robots just find you irresistible!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Robait)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = { nameof(Robotnip) },
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