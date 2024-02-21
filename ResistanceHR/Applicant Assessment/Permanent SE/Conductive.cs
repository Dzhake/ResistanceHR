using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Conductive : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.ElectroTouch;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Conductive>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Permanent Electro Touch.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Conductive))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 10,
					IsAvailable = false,
					IsAvailableInCC = true,
					
					UnlockCost = 0,
					Upgrade = null,
					Unlock =
					{
						
						categories = { }
					}
				});
		}
		
		
	}
}