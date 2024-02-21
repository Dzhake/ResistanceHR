using RogueLibsCore;

namespace RHR.Reputation
{
	internal class Drone_Downsizer : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.OfficeDrone
				? VRelationship.Hostile
				: null;
		public override bool IsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.OfficeDrone;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Drone_Downsizer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Office Drones will attack on sight. Extra XP for killing Office Drones.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Drone_Downsizer)),
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
