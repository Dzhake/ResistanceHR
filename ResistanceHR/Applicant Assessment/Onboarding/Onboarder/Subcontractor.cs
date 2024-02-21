using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class SUBcontractor : T_Onboarder
	{
		public SUBcontractor() : base() { }

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Slave,
		};
		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Slavemaster,
		};

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<SUBcontractor>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Slavemasters are hireable, and will bring their slaves with them.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(SUBcontractor)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
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
						prerequisites = { VanillaItems.ParalyzerTrap },
						recommendations = { "I'm not trying to judge, but this whole setup doesn't sound healthy to me." },
						upgrade = null,
					}
				});
		}
	}
}