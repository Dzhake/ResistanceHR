using RogueLibsCore;

namespace ResistanceHR.Tampering
{
	internal class Rust_Buster : T_ToolCost
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Rust_Buster>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your tools take less wear from use.",
					[LanguageCode.Russian] = "Ваши инструменты меньше изнашиваются от подделывания."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Rust_Buster)),
					[LanguageCode.Russian] = "средство от ржавчины",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { },
						cancellations = { VanillaTraits.PoorHandEyeCoordination },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Rust_Buster_Plus),
					}
				});
		}

		internal override int NewToolCost(int vanilla) =>
			(vanilla * 2) / 3;
	}
}