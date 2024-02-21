using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Security_Consultant : T_Subcontractor
	{
		public Security_Consultant() : base() { }

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Bouncer,
			VanillaAgents.Goon,
			VanillaAgents.Supergoon,
		};
		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Bouncer,
			VanillaAgents.Goon,
			VanillaAgents.Supergoon,
		};

		// TODO: Prevent hiring assigned guards. 
		// agent.oma.GuardTarget ?

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Security_Consultant>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Bouncers, Goons & Supergoons are Friendly and hireable if they aren't currently employed.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Security_Consultant)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
					Unlock =
					{
						cancellations = {

						},
						categories = {
							CTraitCategory.Leadership,
							VTraitCategory.Social,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.KillProfiter },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}