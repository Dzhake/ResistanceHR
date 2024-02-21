using RogueLibsCore;

namespace RHR.Reputation
{
	internal class Liberator : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Slavemaster
				? VRelationship.Hostile
				: null;
		public override bool IsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Slavemaster;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Liberator>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Slavemasters will attack on sight. Extra XP for killing Slavemasters.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Liberator)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -2,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cancellations = {
						},
						categories = { },
						cantLose = false,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}