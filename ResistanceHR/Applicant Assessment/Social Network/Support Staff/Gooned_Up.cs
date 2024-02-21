using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Gooned_Up : T_Bodyguarded
	{
		public override int AgentCount => 1;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Goon };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Gooned_Up>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Goon joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Gooned_Up)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						cancellations = { },
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.HypnotizerII },
						recommendations = { },
						upgrade = nameof(Gooned_Up_Plus),
					}
				});
		}
		

	}
}