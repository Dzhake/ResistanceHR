using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Thicker_than_Water : T_Bodyguarded
	{
		internal override int AgentCount => 1;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.GangsterBlahd };
		internal override bool AgentsArmed => true;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}