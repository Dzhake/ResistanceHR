using RogueLibsCore;

namespace RHR.Reputation
{
	internal class Mobster_Mutilator : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Mobster
				? VRelationship.Hostile
				: null;
		public override bool IsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Mobster;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mobster_Mutilator>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Mobsters will attack on sight. Extra XP for killing Mobsters.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mobster_Mutilator)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -4,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 7,
					Unlock =
					{
						cancellations = {
						},
						categories = { },
						cantLose = false,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}
