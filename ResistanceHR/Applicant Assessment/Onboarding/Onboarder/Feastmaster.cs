using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Feastmaster : T_Onboarder, ICopyTraitEffects, IUpgradeVanillaTrait
	{
		public Feastmaster() : base() { }

		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Cannibal,
		};
		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Cannibal,
		};

		public List<string> BaseTraits => new List<string>() { VanillaTraits.CoolwithCannibals };
		public List<string> TraitsToMimic => new List<string>() { VanillaTraits.CoolwithCannibals };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Feastmaster>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "All the effects of Cool with Cannibals, plus Cannibals are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Feastmaster)),
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
							CTraitCategory.Leadership,
							VTraitCategory.Social,
						},
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { VanillaItems.FoodProcessor },
						recommendations = { },
						upgrade = null,
					}
				});
		}
	}
}