using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Resistance_Network : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Hacker, VanillaAgents.Thief, VanillaAgents.SlumDweller };
		internal override string AgentRelationship => nameof(relStatus.Loyal);
		internal override int AgentCount => 3;
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Resistance_Network>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance has put agents throughout the city to help you.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Resistance_Network)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = { VanillaTraits.TheLaw },
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Resistance_Network_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}