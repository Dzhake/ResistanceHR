using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Ancient_One : T_Onboarder, ICopyTraitEffects, IUpgradeVanillaTrait
	{
		public Ancient_One() : base() { }

		public override List<string> SquadLeaderClasses => new List<string>() { VanillaAgents.Vampire };
		public override List<string> SquadFollowerClasses => new List<string>() { VanillaAgents.Vampire };

		public List<string> BaseTraits => new List<string>() { VanillaTraits.Jugularious };
		public List<string> TraitsToMimic => new List<string>() { VanillaTraits.Jugularious };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Ancient_One>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "All the effects of Jugularious, plus Vampires are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Ancient_One)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cancellations = {

						},
						categories = {
							CTraitCategory.Chthonic,
							CTraitCategory.Leadership,
						},
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { VanillaItems.Necronomicon },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}