using BunnyLibs;
using RogueLibsCore;

namespace RHR.Tampering
{
	public class Rust_Buster : T_ToolCost
	{
		public override int NewToolCost(int vanillaCost) =>
			(vanillaCost * 2) / 3;

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

		

	}
}