using RogueLibsCore;

namespace RHR.Reputation
{
	internal class Cannibal_Crusher : T_Reputation
	{
		public override string GetRelationshipTo(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Cannibal
				? VRelationship.Hostile
				: null;
		public override bool IsRival(Agent otherAgent) =>
			otherAgent.agentName == VanillaAgents.Cannibal;
		public override int Priority => 1000;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Cannibal_Crusher>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Extra XP for killing Cannibals.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Cannibal_Crusher)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
							VanillaTraits.CoolwithCannibals,
					},
					CharacterCreationCost = 1,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 3,
					Unlock =
					{
						categories = { },
						cantLose = true,
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
