using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Thicker_than_Water_Plus : T_Bodyguarded
	{
		public override int AgentCount => 2;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterBlahd };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Thicker_than_Water_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Two Blahds join you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Thicker_than_Water_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = Core.debugMode,
					UnlockCost = 25,
					Unlock =
					{
						cancellations = { },
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Social },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}