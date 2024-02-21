using BunnyLibs;
using RHR.Systems.Social_Network;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Subcontractor
{
	public class Sergeant_Contractor : T_Onboarder, ICopyTraitEffects, IUpgradeVanillaTrait, IRefreshAtEndOfLevelStart
	{
		public Sergeant_Contractor() : base() { }

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Cop,
			VanillaAgents.CopBot,			//	Can't be hired directly
			VanillaAgents.SuperCop,
		};
		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Cop,
			VanillaAgents.SuperCop,
		};

		public override bool CanBeSquadFollower(Agent hirer, Agent leader, Agent follower) =>
			base.CanBeSquadFollower(hirer, leader, follower)
			&& !(leader.agentName == VanillaAgents.Cop && follower.agentName == VanillaAgents.SuperCop);

		//	ICopyTraitEffects
		public List<string> TraitsToMimic => new List<string>() { VanillaTraits.TheLaw };

		//	IUpgradeVanillaTraits
		public List<string> BaseTraits => new List<string>() { VanillaTraits.TheLaw };

		//	IRefreshAtEndOfLevelStart
		public bool BypassUnlockChecks => false;
		public void Refresh() { }
		public void Refresh(Agent agent) => agent.enforcer = true;
		public bool RunThisLevel() => true;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Sergeant_Contractor>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "All the effects of The Law, plus Cops are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Sergeant_Contractor)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
					Unlock =
					{
						cancellations = {

						},
						categories = {
							CTraitCategory.Leadership,
							VTraitCategory.Social,
						},
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { VanillaItems.WalkieTalkie },
						recommendations = 
						{ 
							"Remember that all human and non-human representatives of Protective Operations & Legal Intervention Contracting Experts are 1099 workers. Please observe all relevant regulations and misfile any appropriate documentation."
						},
						upgrade = null,
					}
				});
		}
	}
}