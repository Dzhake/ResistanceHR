using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Union_Rep : T_Onboarder
	{
		public Union_Rep() : base() { }

		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Worker,
		};

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Worker,
		};

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Union_Rep>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Workers are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Union_Rep)),
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
							CTraitCategory.Tampering,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VItemName.SlaveHelmetRemover },
						recommendations = { },
						upgrade = null, // nameof(Union_Rep_Plus),
					}
				});
		}
	}
}