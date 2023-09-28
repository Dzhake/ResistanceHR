using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Rollin_Deep : T_Bodyguarded
	{
		internal override int AgentCount => 1;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterCrepe };
		internal override bool AgentsArmed => true;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Rollin_Deep>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Crepe joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Rollin_Deep), "Rollin' Deep"),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = { nameof(Thicker_than_Water), VanillaTraits.CrepeCrusher },
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Rollin_Deep_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}