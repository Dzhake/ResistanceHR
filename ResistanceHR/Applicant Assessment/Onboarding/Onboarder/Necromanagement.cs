using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	//	This almost certainly won't work. And why would they want money?
	public class Necromanagement : T_Subcontractor
	{
		public Necromanagement() : base() { }

		public override List<string> ClassesAffected => new List<string>()
		{
			VanillaAgents.Ghost,
			VanillaAgents.Zombie,
		};
		public override string Relationship => VRelationship.Friendly;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Necromanagement>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Ghosts & Zombies are Friendly and hireable.", 
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Necromanagement)),
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
							CTraitCategory.Chthonic,
							CTraitCategory.Leadership,
							VTraitCategory.Social,
							CTraitCategory.Spectral,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VanillaItems.RagePoison },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}