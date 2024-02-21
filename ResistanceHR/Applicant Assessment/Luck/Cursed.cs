using RogueLibsCore;

namespace RHR.Luck
{
	public class Cursed : T_Luck
	{
		public override int LuckBonus => -25;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Cursed>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You built a black cat sanctuary and mirror-breakery under a stepladder on an old Indian graveyard. -25% luck penalty.",
					[LanguageCode.Russian] = "Вы купили старое индийское кладбище и построили там приют для чёрных кошек. Не самый лучший выбор.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Cursed)),
					[LanguageCode.Russian] = "Несчастный",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -1,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {  },
						cancellations = {
							nameof(Charmed),
							nameof(Charmed_Plus) },
						cantLose = false,
						cantSwap = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		

	}
}