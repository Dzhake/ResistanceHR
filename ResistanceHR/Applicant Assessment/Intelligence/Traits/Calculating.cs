using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Progression
{
	public class Calculating : T_ExperienceRate, IUpgradeVanillaTrait
	{
		public override float ExperienceRate => 2.00f;

		public List<string> BaseTraits => new List<string>() { VanillaTraits.Studious2 };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Calculating>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "XP gain rate set to 200%",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Calculating)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Studious,
						VanillaTraits.Studious2,
						nameof(Dim_Bulb),
						nameof(Moron_the_Merrier),
						nameof(Numskulled),
						nameof(Smooth_Brained),
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 25,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { VanillaTraits.Studious2 },
						recommendations = { },
						upgrade = nameof(Brainiac),
					}
				});
		}
	}
}