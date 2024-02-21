using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Thicker_Skin : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.ResistDamageMedium;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Thicker_Skin>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Divides incoming damage by 1.5.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Thicker_Skin))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 24,
					IsAvailable = false,
					IsAvailableInCC = false,
					
					UnlockCost = 0,
					Upgrade = nameof(Thickest_Skin),
					Unlock =
					{
						
						categories = { },
						isUpgrade = true,
					}
				});
		}
		
		
	}
}