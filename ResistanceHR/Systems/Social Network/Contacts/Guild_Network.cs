using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Guild_Network : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Thief };
		internal override string AgentRelationship => nameof(relStatus.Friendly);
		internal override int AgentCount => 3;
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Guild_Network>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You've pulled some strings to get your scumbag friends into the city. 3 friendly Thieves are added to each level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Guild_Network)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = { VanillaTraits.TheLaw },
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Guild_Network_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}