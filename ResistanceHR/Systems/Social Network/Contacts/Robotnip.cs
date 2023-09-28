using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Robotnip : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.KillerRobot };
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override int AgentCount => 3;
		internal override bool AgentsAlwaysRun => true;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Robotnip>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Killer Robots just find you irresistible!",
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}