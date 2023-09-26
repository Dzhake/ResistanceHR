using ResistanceHR.Spawns;
using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Deadass_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Deadass_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Oookay, so you're an actual lich. Thousands of years old. I see here you command undead legions, that's nice. Yeah. We'll call you.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Deadass_Plus)),
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
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Werewolf
			|| otherAgent.agentName == VanillaAgents.WerewolfTransformed
			|| otherAgent.specialAbility == VanillaAbilities.WerewolfTransformation;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (otherAgent.agentName == VanillaAgents.Werewolf
			|| otherAgent.agentName == VanillaAgents.WerewolfTransformed
			|| otherAgent.specialAbility == VanillaAbilities.WerewolfTransformation)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
			else if (CAgentGroup.Chthonic.Contains(otherAgent.agentName))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}