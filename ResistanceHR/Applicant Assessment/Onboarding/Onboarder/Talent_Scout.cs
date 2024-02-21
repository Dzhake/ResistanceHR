using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Talent_Scout : T_Subcontractor
	{
		public Talent_Scout() : base() { }

		public override List<string> ClassesAffected => new List<string>()
		{
			VanillaAgents.Comedian,
			VanillaAgents.Musician,
		};
		public override string Relationship => VRelationship.Friendly;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Talent_Scout>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Comedians & Musicians are Friendly and hireable."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Talent_Scout)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 1,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 3,
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
						prerequisites = { VanillaItems.Antidote },
						recommendations = {  },
						upgrade = null,
					}
				});
		}
	}
}