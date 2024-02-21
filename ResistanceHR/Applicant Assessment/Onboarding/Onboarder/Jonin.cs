using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Jonin : T_Subcontractor
	{
		public Jonin() : base() { }

		public override List<string> ClassesAffected => new List<string>()
		{
			VanillaAgents.Assassin,
		};
		public override string Relationship => VRelationship.Friendly;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Jonin>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Assassins are Friendly and hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Jonin)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 2,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cancellations = {

						},
						categories = {
							CTraitCategory.Leadership,
							VTraitCategory.Social,
							VTraitCategory.Stealth,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.SkeletonKey },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}