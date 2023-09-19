using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Kissass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Kissass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Cops like you, and those on the wrong side of the law don't. Oh, you like Slavemasters too. I'm not gonna ask about that.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Kissass)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
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
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Kissass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.PunkassAffiliated.Contains(otherAgent.agentName)
				|| CAgentGroup.PunkassUnaffiliated.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
			else if (CAgentGroup.LawEnforcers.Contains(otherAgent.agentName)
				|| otherAgent.agentName == VanillaAgents.Slavemaster)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}