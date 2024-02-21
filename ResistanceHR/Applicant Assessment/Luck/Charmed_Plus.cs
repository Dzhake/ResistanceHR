using RogueLibsCore;

namespace RHR.Luck
{
	public class Charmed_Plus : T_Luck
	{
		public override int LuckBonus => 10;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Charmed_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You are *really* lucky, as anyone at the next urinal can attest. +10% luck bonus.",
					[LanguageCode.Russian] = "Вам действительно повезло. Любой кто был у туалета рядом с вами это подтвердит.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Charmed_Plus)),
					[LanguageCode.Russian] = "везучий +",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {  },
						cancellations = { nameof(Cursed) },
						cantLose = true,
						cantSwap = false,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		

	}
}