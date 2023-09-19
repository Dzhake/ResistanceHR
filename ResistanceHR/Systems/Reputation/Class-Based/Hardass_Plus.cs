using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Hardass_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Hardass_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You really don't like when people stand up to you. More people are submissive. Extra XP for killing Slaves and Slavemasters.",
					[LanguageCode.Russian] = "Некоротые люди убеждаются, что ваши социальные навыки работают на них. Ты треснешь кнутом. Вы находите все больше и больше подводных камней куда бы вы ни посмотрели.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Hardass_Plus)),
					[LanguageCode.Russian] = "Доминирующий +",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = Core.DebugMode,
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
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Slave
			|| otherAgent.agentName == VanillaAgents.Slavemaster
			|| otherAgent.enslavedByPlayerLight
			|| otherAgent.enslavedByPlayer;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (otherAgent.agentName == VanillaAgents.Slavemaster)
				SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
			else if (otherAgent.agentName == VanillaAgents.Slave
				|| gc.percentChance(5))
				SetRelationshipTo(Owner, otherAgent, VRelationship.Submissive, false);
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}