using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Mobbed_Up : T_Bodyguarded
	{
		internal override int AgentCount => 1;
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Mobster };
		internal override bool AgentsArmed => throw new System.NotImplementedException();

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mobbed_Up>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A Mobster joins you on every level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mobbed_Up)),
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
							nameof(Loansharked)
						},
						cantLose = true,
						cantSwap = false,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { VanillaTraits.FriendoftheFamily },
						recommendations = { },
						upgrade = nameof(Mobbed_Up_Plus),
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}