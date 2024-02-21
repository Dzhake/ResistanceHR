using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Thicker_than_Water : T_Bodyguarded
	{
		public override int AgentCount => 1;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterBlahd };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
		{
			_ = RogueLibs.CreateCustomTrait<Thicker_than_Water>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Blahd joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Thicker_than_Water)),
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
						cancellations = { nameof(Rollin_Deep), VanillaTraits.BlahdBasher },
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Thicker_than_Water_Plus),
					}
				});
		}
		

	}
}