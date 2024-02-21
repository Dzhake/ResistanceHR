using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Guild_Network_Plus : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Thief };
		public override string AgentRelationship => nameof(relStatus.Loyal);
		public override int AgentCount => 3;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) =>
			Guild_Network.MakeGuildThief(agent);

		[RLSetup]
		public static void Setup()
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
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = true,
					Unlock =
					{
						cancellations = { VanillaTraits.TheLaw },
						cantLose = true,
						cantSwap = true,
						categories = {
							CTraitCategory.Leadership,
							VTraitCategory.Social
						},
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Guild Thieves have Modern Warfarer and Sneaky Fingers." },
						upgrade = null,
					}
				});
		}
		

	}
}