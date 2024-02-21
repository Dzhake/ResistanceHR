using RHR;
using RHR.Spawns;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Resistance_Network : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Hacker, VanillaAgents.Thief, VanillaAgents.SlumDweller, VanillaAgents.Soldier }; // Not rotating?
		public override string AgentRelationship => nameof(relStatus.Loyal);
		public override int AgentCount => 3;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Resistance_Network>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance has sent specialists throughout the city to help you.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Resistance_Network)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
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
						upgrade = null, // nameof(Resistance_Network_Plus),
					}
				});
		}
		

	}
}