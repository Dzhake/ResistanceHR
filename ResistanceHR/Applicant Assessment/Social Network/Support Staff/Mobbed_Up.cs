using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Mobbed_Up : T_Bodyguarded
	{
		public override int AgentCount => 1;
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Mobster };
		public override bool AgentsArmed => true;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
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
						prerequisites = { VanillaTraits.FriendoftheFamily },
						recommendations = { },
						upgrade = nameof(Mobbed_Up_Plus),
					}
				});
		}
		

	}
}