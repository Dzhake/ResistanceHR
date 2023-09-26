using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Dumbass_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Dumbass_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Hahahaaaa fuck yeah bro",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Dumbass_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = Core.DebugMode,
					Unlock =
					{
						cancellations = {
							nameof(Dumbass_Plus),
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			CAgentGroup.Dumbasses.Contains(otherAgent.agentName);

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Smartasses.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);
			else if (CAgentGroup.Dumbasses.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}