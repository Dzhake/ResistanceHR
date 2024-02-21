using RogueLibsCore;

namespace RHR.Luck
{
	public class Charmed : T_Luck
	{
		public override int LuckBonus => 5;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Charmed>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You once found a fourteen-leaf clover. +5% luck bonus.",
					[LanguageCode.Russian] = "Как-то раз вы нашли 14 листьев клевера.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Charmed)),
					[LanguageCode.Russian] = "везучий",
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
						categories = {  },
						cancellations = { nameof(Cursed) },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Charmed_Plus),
					}
				});
		}

		

	}
}