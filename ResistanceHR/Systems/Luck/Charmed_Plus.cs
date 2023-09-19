using RogueLibsCore;

namespace ResistanceHR.Luck
{
	internal class Charmed_Plus : T_Luck
	{
		internal override int LuckBonus => 10;

		[RLSetup]
		internal static void Setup()
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
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
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

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}