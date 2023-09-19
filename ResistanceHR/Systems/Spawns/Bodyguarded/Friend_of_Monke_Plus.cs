using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Friend_of_Monke_Plus : T_Bodyguarded
	{
		internal override int AgentCount => 2;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Gorilla };
		internal override bool AgentsArmed => false;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
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
					CharacterCreationCost = 20,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}