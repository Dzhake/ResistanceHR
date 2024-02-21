using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Subcontractor
{
	/// <summary>
	/// Any mention of Squads is meant to be interfaced with Tactician trait. Otherwise, assume normal hire rules apply.
	/// </summary>
	public abstract class T_Onboarder : T_RHR
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public string HireButtonText => VButtonText.Hire_Expert;
		public string HireCostText => VDetermineMoneyCost.Hire_Hacker;
		public abstract List<string> SquadFollowerClasses { get; }
		public abstract List<string> SquadLeaderClasses { get; }

		//	Some of these checks need to be in Tactician instead
		public virtual bool CanBeHired(Agent hirer, Agent leader) =>
			SquadLeaderClasses.Contains(leader.agentName)
			&& hirer.relationships.GetRel(leader) != VRelationship.Annoyed
			&& leader.employer is null;

		//	Some of these checks need to be in Tactician instead
		public virtual bool CanBeSquadFollower(Agent hirer, Agent leader, Agent follower) =>
			//CanBeSquadLeader(hirer, leader) // Call this in the code
			SquadFollowerClasses.Contains(follower.agentName)
			&& hirer.relationships.GetRel(leader) != VRelationship.Annoyed
			&& hirer.relationships.GetRel(leader) != VRelationship.Hostile
			&& follower.employer is null;

		[RLSetup]
		private static void Setup()
		{
			RogueInteractions.CreateProvider<Agent>(h =>
			{
				Agent squadLeader = h.Object;
				Agent hirer = h.Agent;

				foreach (T_Onboarder trait in hirer.GetTraits<T_Onboarder>())
				{
					if (!trait.CanBeHired(hirer, squadLeader))
						continue;

					int hireCost = squadLeader.determineMoneyCost(trait.HireCostText);

					if (hirer.inventory.HasItem(VItemName.HiringVoucher))
						h.AddButton(trait.HireButtonText + "_Voucher", 6666, m =>
						{
							m.Agent.agentInteractions.QualifyHireAsProtection(squadLeader, hirer, 6666);
						});

					h.AddButton(trait.HireButtonText, hireCost, m =>
					{
						m.Object.agentInteractions.PressedButton(m.Object, hirer, trait.HireButtonText, hireCost);
					});

					break; // Prevents duplicate buttons
				}
			});
		}

		[HarmonyPatch(typeof(Agent))]
		public class P_Agent
		{
			private static readonly ManualLogSource logger = BLLogger.GetLogger();
			public static GameController GC => GameController.gameController;

			[HarmonyPrefix, HarmonyPatch(nameof(Agent.Say), new[] { typeof(string), typeof(bool) })]
			public static bool CatchBrokenDialogue(ref string myMessage)
			{
				if (myMessage == "E_Joined")
					myMessage = "You're the boss!";

				//	TODO: Custom abstract hire dialogue

				return true;
			}
		}
	}
}