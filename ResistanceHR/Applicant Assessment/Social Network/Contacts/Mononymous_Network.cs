using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Mononymous_Network : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Hacker };
		public override string AgentRelationship => nameof(relStatus.Friendly);
		public override int AgentCount => 3;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) => 
			MakeMononymous(agent);

		public static void MakeMononymous(Agent agent)
		{
			agent.agentHitboxScript.bodyColor = AgentHitbox.green;
			agent.agentRealName = agent.agentRealName.Replace("Hacker", "Mononymous Hacker");
			agent.AddTrait(VanillaTraits.ModernWarfarer);
			agent.AddTrait(VanillaTraits.CyberNuke);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mononymous_Network>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "3 friendly Mononymous hackers are added to the level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mononymous_Network)),
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
						recommendations = { "Mononymous Hackers have Modern Warfarer and Cyber Nuke." },
						upgrade = nameof(Mononymous_Network_Plus),
					}
				});
		}
	}
}