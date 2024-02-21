using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Mercenary_Network : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Soldier };
		public override string AgentRelationship => nameof(relStatus.Friendly);
		public override int AgentCount => 5;
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 5;

		public override void ModifySpawnedAgent(Agent agent) =>
			MakeMerc(agent);

		public static void MakeMerc(Agent agent)
		{
			agent.oma.bodyType = $"G_{VanillaAgents.Soldier}";
			agent.agentHitboxScript.bodyColor = AgentHitbox.blue;
			agent.agentHitboxScript.legsColor = AgentHitbox.black;
			agent.oma.equippedArmorHead = (agent.oma.convertArmorHeadToInt("Sunglasses"));
			agent.agentRealName = agent.agentRealName.Replace("Soldier", "Umbra Merc");
			agent.agentHitboxScript.MustRefresh();
			agent.agentHitboxScript.UpdateAnim();
			agent.StartCoroutine("NotAddingHeadPiece");

			agent.AddTrait(VanillaTraits.IncreasedCritChance);
			agent.AddTrait(VanillaTraits.UnCrits);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mercenary_Network>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "A friendly squad of Umbra Mercenaries roams each level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mercenary_Network)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = { VanillaTraits.TheLaw },
						cantLose = true,
						cantSwap = false,
						categories = { 
							CTraitCategory.Leadership,
							VTraitCategory.Social 
						},
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Umbra Mercenaries have Increased Crit Chance and Un-Crits."},
						upgrade = null, // nameof(Mercenary_Network_Plus),
					}
				});
		}
		

	}
}