using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace RHR.Spawns
{
	public class Reinforced_Plus : T_Roamers
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
			agent.inventory.startingHeadPiece = VanillaItems.SoldierHelmet;
			agent.agentInvDatabase.AddStartingHeadPiece(VanillaItems.SoldierHelmet);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Reinforced_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your allies now have top-of-the-line equipment.",
					[LanguageCode.Russian] = "Ваши союзники теперь экипированны лучшим снаряжением.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Reinforced_Plus)),
					[LanguageCode.Russian] = "Оснаститель +",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = Core.debugMode,
					IsUnlocked = Core.debugMode,
					UnlockCost = 25,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { VTraitCategory.Social },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}