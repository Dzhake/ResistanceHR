using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Behavior
{
	internal class Extralegal : T_RHR, ISetupAgentStats
	{
		public bool BypassUnlockChecks => false;
		public void SetupAgent(Agent agent)
		{
			agent.noEnforcerAlert = true;
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Extralegal>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = string.Format("Law Enforcers will not protect you."),
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Extralegal)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -5,
					IsAvailable = false,
					IsAvailableInCC = true,
					UnlockCost = 10,
					Unlock =
					{
						categories = { },
					},
				});
		}
	}
}