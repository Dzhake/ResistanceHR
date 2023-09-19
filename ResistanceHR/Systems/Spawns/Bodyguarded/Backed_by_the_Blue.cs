using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Backed_by_the_Blue : T_Bodyguarded
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Cop };
		internal override int AgentCount => 1;
		internal override bool AgentsArmed => true;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}