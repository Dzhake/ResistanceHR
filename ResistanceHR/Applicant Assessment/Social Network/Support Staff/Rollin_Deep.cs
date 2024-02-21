using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Rollin_Deep : T_Bodyguarded
	{
		public override int AgentCount => 1;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterCrepe };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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
		

	}
}