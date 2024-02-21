using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Alpha_Dog : T_Subcontractor
	{
		public Alpha_Dog() : base() { }

		public override List<string> ClassesAffected => new List<string>()
		{
			VanillaAgents.Werewolf,
			VanillaAgents.WerewolfTransformed,
		};
		public override string Relationship => VRelationship.Friendly;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Alpha_Dog>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Werewolves are Friendly and hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Alpha_Dog)),
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
							VTraitCategory.Melee,
							VTraitCategory.Social,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.EarWarpWhistle },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}