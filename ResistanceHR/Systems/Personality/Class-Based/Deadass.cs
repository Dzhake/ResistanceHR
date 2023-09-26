using ResistanceHR.Spawns;
using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Deadass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Deadass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "I'm not calling you a lich, but entities from beyond seem to like you. Werewolves don't.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Deadass)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					Unlock =
					{
						cancellations = {
							nameof(Haunted),
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Moisturize" },
						upgrade = nameof(Deadass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;
		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (otherAgent.agentName == VanillaAgents.Werewolf
			|| otherAgent.agentName == VanillaAgents.WerewolfTransformed
			|| otherAgent.specialAbility == VanillaAbilities.WerewolfTransformation)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
			else if (CAgentGroup.Chthonic.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}