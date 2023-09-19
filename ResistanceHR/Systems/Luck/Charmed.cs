using RogueLibsCore;

namespace ResistanceHR.Luck
{
	internal class Charmed : T_Luck
	{
		internal override int LuckBonus => 5;

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}