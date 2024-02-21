using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Athletic_Recruiter : T_Onboarder
	{
		public Athletic_Recruiter() : base() { }

		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Athlete,
			VanillaAgents.Wrestler,
		};

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Athlete,
			VanillaAgents.Wrestler,
		};

		public override bool CanBeSquadFollower(Agent hirer, Agent leader, Agent follower) =>
			base.CanBeSquadFollower(hirer, leader, follower)
			&& leader.agentName == follower.agentName;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Athletic_Recruiter>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Jocks & Wrestlers are hireable."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Athletic_Recruiter)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cancellations = {

						},
						categories = {
							CTraitCategory.Leadership,
						},
						cantLose = false,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.BraceletOfStrength },
						recommendations = {  },
						upgrade = null,
					}
				});
		}
	}
}