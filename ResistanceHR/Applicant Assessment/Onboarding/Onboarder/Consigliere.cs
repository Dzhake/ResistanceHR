using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Subcontractor
{
	public class Consigliere : T_Onboarder, ICopyTraitEffects, IUpgradeVanillaTrait
	{
		public Consigliere() : base() { }

		public override List<string> SquadFollowerClasses => new List<string>()
		{
			VanillaAgents.Mobster,
		};
		public override List<string> SquadLeaderClasses => new List<string>()
		{
			VanillaAgents.Mobster,
		};

		public List<string> BaseTraits => new List<string>() { VanillaTraits.FriendoftheFamily };
		public List<string> TraitsToMimic => new List<string>() { VanillaTraits.FriendoftheFamily };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Consigliere>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "All the effects of Friend of the Family, plus Mobsters are hireable.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Consigliere)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 20,
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
						prerequisites = { VanillaItems.CyanidePill },
						recommendations = 
						{ 
							"ALWAYS take da Cannoli."
						},
						upgrade = null,
					}
				});
		}
	}
}