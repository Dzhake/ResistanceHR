using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace RHR.Spawns
{
	public class Reinforced : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.ResistanceLeader };
		public override int AgentCount => Mathf.Max((CurrentLevel) / 2, 1);
		public override string AgentRelationship => nameof(relStatus.Aligned);
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 1;

		public override void ModifySpawnedAgent(Agent agent)
		{
			agent.SetStrength(2);
			agent.SetEndurance(2);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Reinforced>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your work for the resistance is paying off. You have allies roaming the city, looking for a chance to help.",
					[LanguageCode.Russian] = "Вы работали над созданием армии для Сопротивления. На данный момент эта армия тайно патрулирует город, постоянно ищя возможность, чтобы помочь вашему общему делу."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Reinforced)),
					[LanguageCode.Russian] = "Оснаститель",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Social },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Reinforced_Plus),
					}
				});
		}
		

	}
}