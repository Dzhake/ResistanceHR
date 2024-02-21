using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Guild_Network : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Thief };
		public override string AgentRelationship => nameof(relStatus.Friendly);
		public override int AgentCount => 3;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) =>
			MakeGuildThief(agent);

		public static void MakeGuildThief(Agent agent)
		{
			agent.agentHitboxScript.bodyColor = AgentHitbox.purple;
			agent.agentRealName = agent.agentRealName.Replace("Thief", "Guild Thief");
			agent.AddTrait(VanillaTraits.ModernWarfarer);
			agent.AddTrait(VanillaTraits.SneakyFingers);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Guild_Network>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "3 Guild Thieves roam each level.",
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
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = { VanillaTraits.TheLaw },
						cantLose = true,
						cantSwap = false,
						categories = {
							CTraitCategory.Leadership,
							VTraitCategory.Social
						},
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Guild Thieves have Modern Warfarer and Sneaky Fingers." },
						upgrade = nameof(Guild_Network_Plus),
					}
				});
		}
		

	}
}