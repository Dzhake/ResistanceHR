using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Hitlisted : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Assassin };
		public override int AgentCount =>
			CurrentLevel > 5
			? CurrentLevel
			: 0;
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override bool AgentsAlwaysRun => true;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent)
		{
			agent.statusEffects.AddStatusEffect(VanillaEffects.InvisiblePermanent);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Hitlisted>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Mayor knows you're coming.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Hitlisted)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						categories = {  },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Remove the trait before level 5." },
						upgrade = null,
					}
				});
		}
		

	}
}