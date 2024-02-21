using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Mobbed_Up_Plus : T_Bodyguarded
	{
		public override int AgentCount => 2;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Mobster };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mobbed_Up_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Two Mobsters join you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mobbed_Up_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 16,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = {
							nameof(Loansharked)
						},
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}