using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace ResistanceHR.Spawns
{
	internal class Reinforced : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.ResistanceLeader };
		internal override int AgentCount => Mathf.Max((CurrentLevel) / 2, 1);
		internal override string AgentRelationship => nameof(relStatus.Aligned);
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 1;

		internal override void ModifySpawnedAgent(Agent agent)
		{
			agent.SetStrength(2);
			agent.SetEndurance(2);
		}

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}