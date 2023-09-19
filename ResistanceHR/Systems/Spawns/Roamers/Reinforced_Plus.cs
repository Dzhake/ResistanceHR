using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace ResistanceHR.Spawns
{
	internal class Reinforced_Plus : T_Roamers
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
			agent.inventory.startingHeadPiece = VanillaItems.SoldierHelmet;
			agent.agentInvDatabase.AddStartingHeadPiece(VanillaItems.SoldierHelmet);
		}

		[RLSetup]
		internal static void Setup()
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
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}