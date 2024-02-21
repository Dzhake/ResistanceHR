using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Task_Force_Alpha : T_Subcontractor
	{
		public Task_Force_Alpha() : base() { }

		public override List<string> ClassesAffected => new List<string>()
		{
			VanillaAgents.SuperCop,
		};
		public override string Relationship => VRelationship.Friendly;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Task_Force_Alpha>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Supercops are Friendly and hireable."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Task_Force_Alpha)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 16,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 30,
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
						prerequisites = { VanillaItems.Revolver },
						recommendations = { "That's not the team name, that's your job title... buncha fucking dorks." },
						upgrade = null,
					}
				});
		}
	}
}