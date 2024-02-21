using BunnyLibs;
using RHR.Systems.Social_Network;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Subcontractor
{
	public class Emergency_Influencer : T_Onboarder, ICopyTraitEffects, IUpgradeVanillaTrait
	{
		public Emergency_Influencer() : base() { }

		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Clerk,
			VanillaAgents.Firefighter,
		};

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Firefighter,
		};

		public override bool CanBeHired(Agent hirer, Agent leader) =>
			base.CanBeHired(hirer, leader)
			&& !(leader.agentName == VanillaAgents.Clerk && !Tactician.squadAgents(hirer, leader).Any(a => a.agentName == VanillaAgents.Firefighter));

		public List<string> BaseTraits => new List<string>() { VanillaTraits.InfernoAssailant };
		public List<string> TraitsToMimic => new List<string>() { VanillaTraits.InfernoAssailant };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Emergency_Influencer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "All the effects of Inferno Assailant, plus Doctors & Firefighters are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Emergency_Influencer)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = {
						},
						categories = {
							CTraitCategory.Leadership,
							VTraitCategory.Social,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = true,
						prerequisites = { VanillaItems.FireExtinguisher },
						recommendations = { "So broke you're thinking of burning down the house so you could claim it was full of presents for your kids? You can get paid TODAY by gigging with MbR!"},
						upgrade = null,
					}
				});
		}
	}
}