using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Most_Wanted : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.SuperCop, VanillaAgents.Cop, VanillaAgents.Cop };
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override int AgentCount => (CurrentDistrict) * 2;
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 4;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Most_Wanted>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The police have set up special task forces to take you down.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Most_Wanted)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Backed_by_the_Blue),
						nameof(Backed_by_the_Blue_Plus)
					},
					CharacterCreationCost = -12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 30,
					Unlock =
					{
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