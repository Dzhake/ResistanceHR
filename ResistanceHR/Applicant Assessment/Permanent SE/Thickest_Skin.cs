using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Thickest_Skin : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.ResistDamageLarge;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Thickest_Skin>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Divides incoming damage by 2.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Thickest_Skin))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 32,
					IsAvailable = false,
					IsAvailableInCC = false,
					
					UnlockCost = 0,
					Upgrade = nameof(Thickester_Skin),
					Unlock =
					{
						
						categories = { },
						isUpgrade = true,
					}
				});
		}
		
		
	}
}