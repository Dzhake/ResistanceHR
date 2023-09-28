using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Friend_of_Monke : T_Bodyguarded
	{
		internal override int AgentCount => 1;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Gorilla };
		internal override bool AgentsArmed => false;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}