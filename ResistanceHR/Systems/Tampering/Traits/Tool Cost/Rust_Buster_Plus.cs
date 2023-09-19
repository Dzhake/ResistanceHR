using RogueLibsCore;

namespace ResistanceHR.Tampering
{
	internal class Rust_Buster_Plus : T_ToolCost
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Rust_Buster_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your tools take very little wear from use.",
					[LanguageCode.Russian] = "Ваши инструменты портятся гораздо меньше, когда вы манипулируете предметами.", // Google Translate for update
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Rust_Buster_Plus)),
					[LanguageCode.Russian] = "средство от ржавчины +",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
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