using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Guild_Network_Plus : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Thief };
		internal override string AgentRelationship => nameof(relStatus.Loyal);
		internal override int AgentCount => 3;
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Guild_Network_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your spawned Thieves are now Loyal.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Guild_Network_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = true,
					Unlock =
					{
						cancellations = { VanillaTraits.TheLaw },
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}