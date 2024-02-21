using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Unlucky_Duck : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.FeelingUnlucky;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Unlucky_Duck>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You are unlucky. That's... unlucky.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Unlucky_Duck))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -1,
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