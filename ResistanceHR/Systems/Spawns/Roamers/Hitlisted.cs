using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Hitlisted : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Assassin };
		internal override int AgentCount =>
			CurrentLevel > 5
			? CurrentLevel
			: 0;
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override bool AgentsAlwaysRun => true;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent)
		{
			agent.statusEffects.AddStatusEffect(VanillaEffects.InvisiblePermanent);
		}

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}