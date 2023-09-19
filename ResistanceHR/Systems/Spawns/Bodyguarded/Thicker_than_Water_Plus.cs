using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Thicker_than_Water_Plus : T_Bodyguarded
	{
		internal override int AgentCount => 2;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterBlahd };
		internal override bool AgentsArmed => true;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
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
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}