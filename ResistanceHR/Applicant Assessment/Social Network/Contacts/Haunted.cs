using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Haunted : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Ghost };
		public override bool AgentsAlwaysRun => true;
		public override bool AgentsArmed => false;
		public override int AgentCount => CurrentLevel;
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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
		

	}
}