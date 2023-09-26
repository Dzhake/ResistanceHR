using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Upperclass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Upperclass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You snooty rich fuck and your snooty rich fuckin' friends. Poor folk don't like your vibe.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Upperclass)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
					Unlock =
					{
						cancellations = {
							VanillaTraits.FairGame,
							VanillaTraits.FriendoftheCommonFolk,
							nameof(Underclass),
							VanillaTraits.TheLaw,
							VanillaTraits.Wanted,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Upperclass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (CAgentGroup.Upperclass.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (CAgentGroup.Underclass.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}