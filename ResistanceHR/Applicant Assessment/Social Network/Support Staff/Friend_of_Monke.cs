using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Friend_of_Monke : T_Bodyguarded
	{
		public override int AgentCount => 1;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Gorilla };
		public override bool AgentsArmed => false;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Friend_of_Monke>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Gorilla joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Friend_of_Monke)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = {
							VanillaTraits.Specist,
							nameof(Return_to_Eneme) },
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { VanillaItems.Translator },
						recommendations = { },
						upgrade = nameof(Friend_of_Monke_Plus),
					}
				});
		}
		

	}
}