using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Return_to_Eneme : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Gorilla };
		internal override int AgentCount => (CurrentDistrict + 1) * 2;
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override bool AgentsAlwaysRun => true;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 3;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}