using RogueLibsCore;

namespace RHR.Reputation
{
	internal class Werewolf_Wrecker : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Werewolf
				? VRelationship.Hostile
				: null;
		public override bool IsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Werewolf;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Werewolf_Wrecker>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Werewolves will attack on sight. Extra XP for killing Werewolves.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Werewolf_Wrecker)),
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
