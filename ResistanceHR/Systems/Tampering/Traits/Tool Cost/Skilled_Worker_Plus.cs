using RogueLibsCore;

namespace ResistanceHR.Tampering
{
	internal class Skilled_Worker_Plus : T_ToolCost
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Skilled_Worker_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your tools take very little wear from use.",
					[LanguageCode.Russian] = "Ваши инструменты портятся гораздо меньше, когда вы манипулируете предметами.", // Google Translate for update
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Skilled_Worker_Plus)),
					[LanguageCode.Russian] = "Вспышка Гнева +",
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
						cancellations = { VanillaTraits.PoorHandEyeCoordination },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		internal override int NewToolCost(int vanilla) =>
			vanilla / 3;
	}
}