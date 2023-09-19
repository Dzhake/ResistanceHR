using RogueLibsCore;

namespace ResistanceHR.Tampering
{
	internal class Tamper_Tantrum_Plus : T_Tampering
	{
		public override float ToolCostFactor => 0.333f;

		//[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Tamper_Tantrum_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your tools take no wear from use.",
					[LanguageCode.Russian] = "Ваши инструменты не изнашиваются когда вы подделываете что-то.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Tamper_Tantrum_Plus)),
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

	}
}
