using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Kissass_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Kissass_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You <i>really</i> must like the taste of boot polish. Good for you, I guess. Extra XP for neutralizing criminals.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Kissass_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = {
							VanillaTraits.FriendoftheCommonFolk,
							nameof(Punkass),
							VanillaTraits.FairGame,
							VanillaTraits.TheLaw,
							VanillaTraits.Wanted,
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
			CAgentGroup.PunkassAffiliated.Contains(otherAgent.agentName);

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.PunkassAffiliated.Contains(otherAgent.agentName)
				|| CAgentGroup.PunkassUnaffiliated.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
			else if (otherAgent.agentName == VanillaAgents.Slavemaster)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (CAgentGroup.LawEnforcers.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}