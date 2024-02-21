using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Return_to_Eneme : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Gorilla };
		public override int AgentCount => (CurrentDistrict + 1) * 2;
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override bool AgentsAlwaysRun => true;
		public override bool AgentsArmed => true;
		public override int GroupSize => 3;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Return_to_Eneme>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You made prolonged eye contact with King Hammurambe, sovereign of all Monkekind.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Return_to_Eneme)),
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
						cancellations = { nameof(Friend_of_Monke) },
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