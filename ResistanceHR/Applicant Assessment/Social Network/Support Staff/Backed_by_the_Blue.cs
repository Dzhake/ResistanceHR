using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Backed_by_the_Blue : T_Bodyguarded
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Cop };
		public override int AgentCount => 1;
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Backed_by_the_Blue>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Cop joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Backed_by_the_Blue)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = {
							nameof(Most_Wanted),
							VanillaTraits.Wanted,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { VanillaItems.WalkieTalkie },
						recommendations = { },
						upgrade = nameof(Backed_by_the_Blue_Plus),
					}
				});
		}
		

	}
}