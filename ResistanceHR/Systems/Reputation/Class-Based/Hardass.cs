using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Hardass : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Hardass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "There's just something about the way you demand obedience from the weak around you. Kinky!",
					[LanguageCode.Russian] = "Есть что-то в том, как ты себя ведешь. Может быть, что дело в том как вы ходите, а может в том, как вы требуете подчинения от слабых вокруг. Люди иногда будут повиноватся вам, но вы крайне эксцентричны!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Hardass)),
					[LanguageCode.Russian] = "Доминирующий",
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
							VanillaTraits.RandomReverence,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Hardass_Plus),
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Slavemaster;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (otherAgent.agentName == VanillaAgents.Slavemaster)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);
			else if (otherAgent.agentName == VanillaAgents.Slave
				|| gc.percentChance(3))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Submissive, false);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}