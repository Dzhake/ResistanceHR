using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Thickester_Skin : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.NumbtoPain;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Thickester_Skin>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Divides incoming damage by 3.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Thickester_Skin))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 48,
					IsAvailable = false,
					IsAvailableInCC = false,
					
					UnlockCost = 0,
					Upgrade = null,
					Unlock =
					{
						
						categories = { },
						isUpgrade = true,
					}
				});
		}
		
		
	}
}