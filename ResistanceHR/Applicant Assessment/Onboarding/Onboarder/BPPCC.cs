using RHR.Systems.Social_Network;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Subcontractor
{
	public class BPPCC : T_Onboarder
	{
		public BPPCC() : base() { }

		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Clerk,
			VanillaAgents.OfficeDrone,
		};
		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.OfficeDrone,
		};

		public override bool CanBeHired(Agent hirer, Agent leader) =>
			base.CanBeHired(hirer, leader)
			&& (leader.agentName == VanillaAgents.OfficeDrone
				|| !Tactician.squadAgents(hirer, leader).Any(a => a.agentName == VanillaAgents.Firefighter));

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<BPPCC>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The position of Birthday Party Planning Committee Chair wields massive and unaccountable power. Clerks & Office Drones are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(BPPCC)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 1,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 3,
					Unlock =
					{
						cancellations = {

						},
						categories = {
							CTraitCategory.Leadership,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.FriendPhone },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}