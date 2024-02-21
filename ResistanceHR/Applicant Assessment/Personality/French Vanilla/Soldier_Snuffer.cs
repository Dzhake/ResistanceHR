using RogueLibsCore;

namespace RHR.Reputation
{
	internal class Soldier_Snuffer : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Soldier
				? VRelationship.Hostile
				: null;
		public override bool IsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Soldier;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Soldier_Snuffer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Soldiers will attack on sight. Extra XP for killing Soldiers.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Soldier_Snuffer)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -4,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
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
