using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Haunted : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Ghost };
		internal override bool AgentsAlwaysRun => true;
		internal override bool AgentsArmed => false;
		internal override int AgentCount => CurrentLevel;
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Haunted>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You spent too long spelunking in an ancient treasure vault.",
					[LanguageCode.Russian] = "Вы потратили слишком много времени на спелеологию в древней сокровищнице."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Haunted)),
					[LanguageCode.Russian] = "Призраки",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						categories = {  },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}