using RogueLibsCore;

namespace RHR.Interaction
{
	public class Snitch_Plus : T_Interaction
	{
		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Snitch_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Interact with an NPC to sic them and nearby allies on anyone they're hostile to. People who see you snitching may not approve.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Snitch_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 25,
					Unlock =
					{
						cancellations = {
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = false,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { "Watch your back. Probably a good idea to watch your front too." },
						upgrade = null,
					}
				});
		}
	}
}