using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Union_Rep_2 : T_Subcontractor
	{
		public Union_Rep_2() : base() { }

		public override List<string> ClassesAffected => new List<string>()
		{
			VanillaAgents.Worker,
		};
		public override string Relationship => VRelationship.Loyal;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Union_Rep_2>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"Workers are Friendly and hireable. All Workers are Aligned to each other.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Union_Rep_2), "Union Boss"),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = true,
					UnlockCost = 0,
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
						cantSwap = true,
						isUpgrade = true,
						prerequisites = {  },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}