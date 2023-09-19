using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Backed_by_the_Blue_Plus : T_Bodyguarded
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.SuperCop };
		internal override int AgentCount => 1;
		internal override bool AgentsArmed => true;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Backed_by_the_Blue_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Supercop joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Backed_by_the_Blue_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 20,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = true,
					Unlock =
					{
						cancellations = {
							nameof(Most_Wanted),
							VanillaTraits.Wanted,
						},
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